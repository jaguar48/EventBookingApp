using EventBookingApp_DAL.Dtos.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBookingApp_BLL.Interface
{
    public interface IAdminService
    {
        Task<string> RegisterAdmin(AdminRegistrationRequest request);
    }
}
