using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using Configuration;
using Seido.Utilities.SeedGenerator;
using AppWebApi.Controllers;

namespace Controllers
{
    public class csApiCUser
    {
        public string Environment {get; set;}
        public string DbConnection {get; set;}
        public DbSetDetail DbSetActive {get; set;}
    }
    [ApiController]
    [Route("api/users")]
    public class csUserController : ControllerBase
    {
        private IUserService _userService = null;
        private ILogger<csUserController> _logger = null;

        public csUserController(IUserService userService, ILogger<csUserController>logger)
        {
            _userService = userService;
            _logger = logger;
        }

    // GET: api/users
        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync([FromQuery] int count)
        {
            try
            {
                _logger.LogInformation("Fetching all users.");
                var users = await _userService.GetAllUsersAsync(count);
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

                // POST: api/users/seed
        [HttpPost("seed")]
        public async Task<IActionResult> SeedUsers([FromQuery] int count)
        {
            try
            {
                _logger.LogInformation("Seeding users.");
                await _userService.Seed(count);
                return Ok("Users seeded successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}