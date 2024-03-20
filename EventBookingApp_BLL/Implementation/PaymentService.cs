using AutoMapper;
using EventBookingApp_BLL.Interface;
using EventBookingApp_Contracts;
using EventBookingApp_DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PayStack.Net;
using System.Security.Claims;

namespace EventBookingApp_BLL.Implementation
{
    public class PaymentService : IPaymentService
    {


        private readonly IRepository<Customer> _customerRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        private readonly IRepository<Wallet> _walletRepo;
        private readonly IMapper _mapper;

        public PaymentService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _mapper = mapper;

            _customerRepo = _unitOfWork.GetRepository<Customer>();

            _walletRepo = _unitOfWork.GetRepository<Wallet>();
        }



        public async Task<string> FundWallet(decimal paymentAmount)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                throw new Exception("User not found");
            }

            var customer = await _customerRepo.GetSingleByAsync(x => x.UserId == userId, include: x => x.Include(x => x.Wallet));
            if (customer == null || customer.Wallet == null)
            {
                throw new Exception("Customer or wallet not found");
            }

            string secret = _configuration.GetSection("ApiSecret")["SecretKey"];
            if (string.IsNullOrEmpty(secret))
            {
                throw new Exception("PayStack API secret key not found in configuration");
            }

            string reference = Guid.NewGuid().ToString("N");

            string callbackUrl = "https://localhost:7258/api/eventbooking/verifypayment";

            var paystackApi = new PayStackApi(secret);

            var transactionInitializeRequest = new TransactionInitializeRequest
            {
                Email = customer.Email,
                AmountInKobo = (int)(paymentAmount * 100),
                Reference = reference,
                CallbackUrl = callbackUrl
            };

            var transactionInitializeResponse = paystackApi.Transactions.Initialize(transactionInitializeRequest);

            if (!transactionInitializeResponse.Status)
            {
                throw new Exception($"PayStack API error: {transactionInitializeResponse.Message}");
            }


            customer.Wallet.Balance += paymentAmount;


            await _walletRepo.UpdateAsync(customer.Wallet);


            await _unitOfWork.SaveChangesAsync();

            var authorizationUrl = transactionInitializeResponse.Data.AuthorizationUrl;
            var trimmedAuthorizationUrl = authorizationUrl.Split('?')[0];
            return trimmedAuthorizationUrl;
        }




    }
}
