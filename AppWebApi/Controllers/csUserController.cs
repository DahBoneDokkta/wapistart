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


    }
}