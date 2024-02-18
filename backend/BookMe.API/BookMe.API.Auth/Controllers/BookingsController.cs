using BookMe.API.Auth.Models.Booking;
using BookMe.API.Auth.Models.Service;
using BookMe.API.Auth.Services.Booking;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BookMe.API.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly ILogger<BookingsController> _logger;
        private readonly IBookingService _bookingService;

        public BookingsController(ILogger<BookingsController> logger, IBookingService bookingService)
        {
            _logger = logger;
            _bookingService = bookingService;
        }

        [HttpGet("{serviceId}")]
        public async Task<IActionResult> ListAsync(Guid serviceId)
        {
            try
            {
                var bookings = await _bookingService.ListAsync(serviceId);

                if (bookings == null)
                {
                    return NotFound();
                }
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Bookings/ListAsync + {ex.Message}");
                return StatusCode(500, "Something went wrong");
            }
        }

        [HttpPost("{serviceId}")]
        public async Task<IActionResult> CreateAsync(Guid serviceId, [FromBody] BookingCreationViewModel bookingCreation)
        {
            try
            {
                var createdBooking = await _bookingService.CreateAsync(serviceId, bookingCreation);

                if(createdBooking == null)
                {
                    return BadRequest();
                }
                return Ok(createdBooking);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Bookings/CreateAsync + {ex.Message}");
                return StatusCode(500, "Something went wrong");
            }
        }

    }
}
