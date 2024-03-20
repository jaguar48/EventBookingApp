using EventBookingApp_DAL.Dtos.Request;
using EventBookingApp_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBookingApp_BLL.Interface
{
    public interface IUserService
    {
        Task<User> RegisterUser(UserRegistrationRequest Request);
    }
}
