using EventBookingApp_BLL.Interface;
using EventBookingApp_Contracts;
using EventBookingApp_DAL.Dtos.Request;
using EventBookingApp_DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace EventBookingApp_BLL.Implementation
{

    public sealed class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepo;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IUserService _userServices;
        private readonly UserManager<User> _userManager;
        /* private readonly IAuthService _authService;*/

        private readonly IRepository<Wallet> _walletRepo;

        public CustomerService(IUnitOfWork unitOfWork, UserManager<User> userManager, IUserService userServices)
        {
            /*_logger = logger;*/
            _unitOfWork = unitOfWork;
            _userManager = userManager;
           /* _authService = authService;*/
            _userServices = userServices;
            _customerRepo = _unitOfWork.GetRepository<Customer>();
            _walletRepo = _unitOfWork.GetRepository<Wallet>();
        }

        public async Task<string> RegisterCustomer(CustomerRegistrationRequest request)
        {

            /* _logger.LogInfo("Creating the Seller as a user first, before assigning the seller role to them and adding them to the Sellers table.");*/

            var user = await _userServices.RegisterUser(new UserRegistrationRequest
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
                UserName = request.UserName,
   
            });


            await _userManager.AddToRoleAsync(user, "Customer");

            var customer = new Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                UserName = request.UserName,
                Address = request.Address,
                UserId = user.Id
            };

            await _customerRepo.AddAsync(customer);
            await CreateCustomerAccount(customer);

            /* var verificationToken = Guid.NewGuid().ToString();
             var emailSent = await _authService.SendVerificationEmail(request.Email, verificationToken);*/

            /* if (emailSent)
             {

                 user.VerificationToken = verificationToken;
                 await _userManager.UpdateAsync(user);
    */

            var result = new { success = true, message = "Registration Successful! Please login." };
            return JsonConvert.SerializeObject(result);

          
        }



        private async Task CreateCustomerAccount(Customer customer)
        {

            Wallet wallet = new()
            {
                WalletNo = WalletIdGenerator.GenerateWalletId(),
                Balance = 5033330,
                IsActive = true,
                CustomerId = customer.Id,
            };
            await _walletRepo.AddAsync(wallet);
        }
    }
}

