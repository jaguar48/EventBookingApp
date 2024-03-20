using EventBookingApp_BLL.Interface;
using EventBookingApp_DAL.Dtos.Request;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EventBookingApp_PLL.Controllers
{
   
    [ApiController]
    [Route("api/eventbooking")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminServices;


        public AdminController(IAdminService adminServices)
        {
            _adminServices = adminServices;

        }
        [HttpPost("admin-register")]

        [SwaggerOperation("New Admin registration.")]
        [SwaggerResponse(200, "The admin has been successfully registered.", typeof(AdminRegistrationRequest))]
        public async Task<IActionResult> RegisterAdmin([FromBody] AdminRegistrationRequest adminRegistrationRequest)
        {

            var result = await _adminServices.RegisterAdmin(adminRegistrationRequest);
            return Ok(result);
        }
    }
}
