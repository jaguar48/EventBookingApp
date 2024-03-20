using EventBookingApp_BLL.Implementation;
using EventBookingApp_BLL.Interface;
using EventBookingApp_DAL.Dtos.Request;
using EventBookingApp_DAL.Dtos.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EventBookingApp_PLL.Controllers
{
    [ApiController]
    [Route("api/eventbooking")]
    public class EventController: ControllerBase
    {
        private readonly IEventService _eventService;


        public EventController(IEventService eventServices)
        {
            _eventService = eventServices;

        }

        [Authorize(Roles = "Admin")]
        [HttpPost("create")]
        [SwaggerOperation("New event creation.")]
        [SwaggerResponse(200, "The event has been successfully created.", typeof(CreateEventRequest))]
        public async Task<IActionResult> CreateEvent([FromBody] CreateEventRequest eventRequest)
        {
            try
            {
                var result = await _eventService.CreateEventAsync(eventRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{eventId}")]
        [SwaggerOperation("Get a single event")]
        [SwaggerResponse(200, "The event has retrieved successfully.", typeof(GetEventResponse))]
        public async Task<IActionResult> GetEventById(int eventId)
        {
            try
            {
                var eventDto = await _eventService.GetEventByIdAsync(eventId);
                return Ok(eventDto);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{eventId}")]
        [SwaggerOperation("Update a single event")]
        [SwaggerResponse(200, "The event has updated successfully.", typeof(UpdateEventRequest))]
        public async Task<IActionResult> UpdateEvent(int eventId, [FromBody] UpdateEventRequest eventRequest)
        {
            try
            {
                var result = await _eventService.UpdateEventAsync(eventId, eventRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{eventId}/events")]
        [SwaggerOperation("retrieve an event")]
        [SwaggerResponse(200, "The event has retrieved successfully.", typeof(BookingResponse))]
        public async Task<IActionResult> GetBookingsForEvent(int eventId)
        {
            try
            {
                var bookings = await _eventService.GetBookingsForEventAsync(eventId);
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [Authorize(Roles = "Admin")]

        [HttpDelete("{eventId}")]
        [SwaggerOperation("Delete an existing event")]
        [SwaggerResponse(200, "The event has been deleted successfully.")]
      
        public async Task<IActionResult> DeleteEvent(int eventId)
        {
            try
            {
                var result = await _eventService.DeleteEventAsync(eventId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
