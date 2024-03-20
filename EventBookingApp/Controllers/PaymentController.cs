using EventBookingApp_BLL.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EventBookingApp_PLL.Controllers
{
    [ApiController]
    [Route("api/eventbooking")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("fundwallet")]
        public async Task<IActionResult> FundWallet(decimal amount)
        {
            try
            {
                var authorizationUrl = await _paymentService.FundWallet(amount);
                // Redirect the user to the Paystack authorization URL to complete the payment
                return Redirect(authorizationUrl);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while funding the wallet: {ex.Message}");
            }
        }
    }
}
