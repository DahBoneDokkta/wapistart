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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppWebApi.Controllers
{
    public class csWapiInfo
    {
        public string Environment { get; set; }
        public string DbConnection { get; set; }
        public DbSetDetail DbSetActive { get; set; }
    }

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class csAdminController : Controller
    {
        private ILogger<csAdminController> _logger = null;
        private csSeedGenerator _seeder = null;
        private readonly ICountryService _countryService;
        private readonly ICityService _cityService;
        private readonly IAttractionService _attractionService;
        private readonly IUserService _userService;
        private readonly ICommentService _commentService;

        public csAdminController(
            ILogger<csAdminController> logger,
            csSeedGenerator seeder,
            ICountryService countryService,
            ICityService cityService,
            IAttractionService attractionService,
            IUserService userService,
            ICommentService commentService)
        {
            _logger = logger;
            _seeder = seeder;
            _countryService = countryService;
            _cityService = cityService;
            _attractionService = attractionService;
            _userService = userService;
            _commentService = commentService;
        }
        // public csAdminController(ILogger<csAdminController> logger)
        // {
        //     _logger = logger;
        //     _seeder = new csSeedGenerator();
        // }



        //GET: api/csAdmin/Info
        [HttpGet()]
        [ActionName("Info")]
        [ProducesResponseType(200, Type = typeof(csWapiInfo))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> Info()
        {
            try
            {
                _logger.LogInformation("Endpoint Info executed");
                var _info = new csWapiInfo {
                    Environment = csAppConfig.ASPNETCOREEnvironment,
                    DbSetActive = csAppConfig.DbSetActive
                };
                
                return Ok(_info);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Info endpoint");
                return BadRequest("An error occured while processing your request.");
            }           
        }

        //GET: api/csAdmin/Seed
        [HttpGet()]
        [ActionName("Seed")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> Seed(string count = "10")
        {
            try
            {
                _logger.LogInformation("Endpoint Seed executed");
                int _count = int.Parse(count);

                await _countryService.SeedCountriesAsync(_count);
                await _cityService.SeedCitiesAsync(_count);
                await _attractionService.SeedAttractionsAsync(_count);
                await _userService.SeedUsersAsync(_count);
                await _commentService.SeedCommentsAsync(_count);

                return Ok("Seeding completed");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Seed endpoint");
                return BadRequest("An error occured while processing your request.");
            }
           
        }

        //GET: api/csAdmin/ClearTestData
        [HttpGet()]
        [ActionName("ClearTestData")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> ClearTestData()
        {
            try
            {
                _logger.LogInformation("Endpoint ClearTestData executed");
                
                await _countryService.ClearTestDataAsync();
                await _cityService.ClearTestDataAsync();
                await _countryService.ClearTestDataAsync();
                await _countryService.ClearTestDataAsync();
                await _countryService.ClearTestDataAsync();

                return Ok("Test data cleared");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }           
        }

        //GET: api/csAdmin/log
        [HttpGet()]
        [ActionName("Log")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<csLogMessage>))]
        public async Task<IActionResult> Log([FromServices] ILoggerProvider _loggerProvider)
        {
            //Note the way to get the LoggerProvider, not the logger from Services via DI
            if (_loggerProvider is csInMemoryLoggerProvider cl)
            {
                return Ok(await cl.MessagesAsync);
            }
            return Ok("No messages in log");
        }
 
    }
}

