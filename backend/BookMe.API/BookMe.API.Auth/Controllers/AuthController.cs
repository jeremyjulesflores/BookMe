using BookMe.API.Auth.Entities;
using BookMe.API.Auth.Models;
using BookMe.API.Auth.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookMe.API.Auth.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;
        
        public AuthController(ILogger<AuthController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        [HttpPost()]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] AuthenticationViewModel authView)
        {
            try
            {
                if (authView == null)
                {
                    return BadRequest("AuthenticationViewModel cannot be null.");
                }

                if (string.IsNullOrEmpty(authView.Email))
                {
                    return BadRequest("Email cannot be null or empty.");
                }

                if (string.IsNullOrEmpty(authView.Password))
                {
                    return BadRequest("Password cannot be null or empty.");
                }

                string token = await _authService.Authenticate(authView.Email, authView.Password);
              

                if (token != null)
                {
                    return Ok(token);
                }
                else
                {
                    return BadRequest("Invalid Credentials");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "AuthController/Post");
                return StatusCode(500, "Something went wrong");
            }
        }



        //[HttpPost("password")]
        //public void Password([FromBody] AuthenticationViewModel authView)
        //{
        //    try
        //    {
        //        Claim idClaim = User.Claims.FirstOrDefault(i => i.Type == "Id");
        //        Response.StatusCode = 200;
        //        _authService.ChangePassword(Guid.Parse(idClaim.Value), authView.Password);
        //    }
        //    catch(Exception ex)
        //    {
        //        Response.StatusCode=500;
        //        _logger.LogError(ex, "AuthController/Patch");
        //    }
        //}
       
    }
}
