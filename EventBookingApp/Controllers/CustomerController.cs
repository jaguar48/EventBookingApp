using EventBookingApp_BLL.Interface;
using EventBookingApp_DAL.Dtos.Request;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EventBookingApp_PLL.Controllers
{
    [ApiController]
    [Route("api/eventbooking")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerServices;


        public CustomerController(ICustomerService customerServices)
        {
            _customerServices = customerServices;

        }
        [HttpPost("customer-register")]

        [SwaggerOperation("New customer registration.")]
        [SwaggerResponse(200, "The customer has been successfully registered.", typeof(CustomerRegistrationRequest ))]
        public async Task<IActionResult> RegisterCustomer([FromBody] CustomerRegistrationRequest customerRegistrationRequest)
        {

            var result = await _customerServices.RegisterCustomer(customerRegistrationRequest);
            return Ok(result);
        }
    }
}


