using BookMe.API.Auth.Models.Service;
using BookMe.API.Auth.Services;
using BookMe.API.Auth.Services.Interfaces;
using BookMe.API.Auth.Services.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMe.API.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ILogger<ServicesController> _logger;
        private readonly IServiceService _serviceService;

        public ServicesController(ILogger<ServicesController> logger, IServiceService serviceService)
        {
            _logger = logger;
            _serviceService = serviceService;
        }


        [HttpGet("/{userId}")]
        public async Task<IActionResult> ListAsync(Guid userId)
        {
            try
            {
                var services = await _serviceService.ListAsync(userId);

                if (services == null)
                {
                    return NotFound("No Services");
                }
                return Ok(services);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Services/ListAsync + {ex.Message}");
                return StatusCode(500, "Something went wrong");
            }
        }

        [HttpPost("/{userId}")]
        public async Task<IActionResult> CreateAsync(Guid userId, [FromBody]ServiceCreationViewModel serviceCreation)
        {
            try
            {
                var createdService = await _serviceService.CreateAsync(userId, serviceCreation);

                if (createdService == null)
                {
                    return BadRequest();
                }
                return Ok(createdService);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Services/CreateAsync + {ex.Message}");
                return StatusCode(500, "Something went wrong");
            }
        }

    }
}
