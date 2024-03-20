using EventBookingApp_BLL.Interface;
using EventBookingApp_Contracts;
using EventBookingApp_DAL.Dtos.Request;
using EventBookingApp_DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace EventBookingApp_BLL.Implementation
{
    public sealed class AdminService : IAdminService
    {
        private readonly IRepository<Admin> _adminRepo;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IUserService _userServices;
        private readonly UserManager<User> _userManager;


        private readonly IRepository<Wallet> _walletRepo;

        public AdminService(IUnitOfWork unitOfWork, UserManager<User> userManager, IUserService userServices)
        {

            _unitOfWork = unitOfWork;
            _userManager = userManager;

            _userServices = userServices;
            _adminRepo = _unitOfWork.GetRepository<Admin>();
            _walletRepo = _unitOfWork.GetRepository<Wallet>();
        }

        public async Task<string> RegisterAdmin(AdminRegistrationRequest request)
        {


            var user = await _userServices.RegisterUser(new UserRegistrationRequest
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
                UserName = request.UserName,

            });


            await _userManager.AddToRoleAsync(user, "Admin");

            var admin = new Admin
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                UserName = request.UserName,

                UserId = user.Id
            };

            await _adminRepo.AddAsync(admin);



            var result = new { success = true, message = "Registration Successful! Please login." };
            return JsonConvert.SerializeObject(result);


        }
    }
}