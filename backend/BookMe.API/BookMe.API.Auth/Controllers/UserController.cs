using AutoMapper;
using BookMe.API.Auth.Models;
using BookMe.API.Auth.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace BookMe.API.Auth.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IMapper mapper, IUserService userService)
        {
            _logger = logger;
            _mapper = mapper;
            _userService = userService;
        }

        /// <summary>
        /// Get a list of users.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ListAsync()
        {
            try
            {
                var users = await _userService.ListAsync();

                if(users ==null)
                {
                    return NotFound("No Users");
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"UserController/ListAsync");
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Gets a specific user based on its ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult>GetAsync(Guid id)
        {
            try
            {
                var user =await _userService.GetAsync(id);

                if(user == null)
                {
                    return NotFound("User not found");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                _logger.LogError(ex, $"UserController/GetAsync/{id}");
                return StatusCode(500, "Something went wrong");
            }
        }
        /// <summary>
        /// Gets a specific user based on its email
        /// </summary>
        //[HttpGet("{email}")]
        //public async Task<IActionResult> GetByEmailAsync(string email)
        //{
        //    try
        //    {
        //        var user = await _userService.GetByEmailAsync(email);

        //        if (user == null)
        //        {
        //            return NotFound("User not found");
        //        }
        //        return Ok(user);
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.StatusCode = 500;
        //        _logger.LogError(ex, $"UserController/GetEmailAsync/{email}");
        //        return StatusCode(500, "Something went wrong");
        //    }
        //}

        /// <summary>
        /// Creates a new user
        /// </summary>
        [HttpPost()]
        public async Task<IActionResult> CreateAsync([FromBody] CreationViewModel userView)
        {
            try
            {
                if(userView == null)
                {
                    return BadRequest();
                }

                var Id = await _userService.AddAsync(userView);
                return Created($"GET api/users/{Id}",userView);
            }
            catch (Exception ex)
            {
                
                _logger.LogError(ex, "UserController/Post");
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Updates a user details
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UserViewModel userView)
        {
            try
            {
                
                var user = _mapper.Map<Entities.User>(userView);
                if(user == null)
                {
                    return BadRequest();
                }

                if(!await _userService.UpdateAsync(user))
                {
                    return BadRequest();
                }

                return Ok(user) ;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "UserController/UpdateAsync");
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Deletes a user
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                if (! await _userService.DeleteAsync(id))
                {
                    return BadRequest();
                }
                return Ok($"User {id} Deleted");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "UserController/DeleteAsync");
                return StatusCode(500, "Something went wrong");
            }
        }
    }
}
