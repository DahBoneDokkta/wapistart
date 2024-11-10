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
    [ApiController]
    [Route("api/[controller]")]
    public class csUserController : ControllerBase
    {
        private IUserService _userService = null;
        private ILogger<csAdminController> _logger = null;

        public csUserController(IUserService userService, ILogger<csAdminController>logger)
        {
            _userService = userService;
            _logger = logger;
        }

        // [HttpGet]
        // public async Task<ActionResult<List<IUser>>> GetUsers(int count)
        // {
        //     var users = await _userService.GetUsersAsync(count);
        //     return Ok(users);
        // }

        //GET: api/csAdmin/Users
        // [HttpGet()]
        // [ActionName("GetAllUsers")]
        // [ProducesResponseType(200, Type = typeof(List<IUser>))]
        // [ProducesResponseType(400, Type = typeof(string))]
        // public async Task<IActionResult> GetAllUsers(string count)
        // {
        //     try
        //     {
        //         _logger.LogInformation("Endpoint Users executed");
        //         var _count = int.Parse(count);

        //         var users = await _userService.GetAllUsers(_count);

        //         return Ok(users);
        //     }
        //     catch (Exception ex)
        //     {
        //         _logger.LogError(ex.Message);
        //         return BadRequest(ex.Message);
        //     }
        // }


    }
}