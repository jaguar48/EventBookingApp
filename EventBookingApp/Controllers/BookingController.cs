using EventBookingApp_BLL.Implementation;
using EventBookingApp_BLL.Interface;
using EventBookingApp_DAL.Dtos.Request;
using EventBookingApp_DAL.Dtos.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Data;

namespace EventBookingApp_PLL.Controllers
{

    [ApiController]
    [Route("api/eventbooking")]
    public class BookingController:ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;

        }
        [Authorize(Roles = "Customer")]
        [HttpPost("booking")]
        [SwaggerOperation("Booking an event.")]
        [SwaggerResponse(200, "The event has been successfully booked.", typeof(CreateEventRequest))]
        public async Task<IActionResult> BookEvent(int eventId, int numberOfTickets)
        {
            try
            {
                var result = await _bookingService.BookEventAsync(eventId, numberOfTickets);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Customer")]
        [HttpPost("cancel/{bookingId}")]
        [SwaggerOperation("cancellation of an event.")]
        [SwaggerResponse(200, "The event has been successfully cancelled.")]
        public async Task<IActionResult> CancelBooking(int bookingId)
        {
            try
            {
                string result = await _bookingService.CancelBookingAsync(bookingId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

    }
}
