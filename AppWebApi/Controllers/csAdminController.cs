using Microsoft.AspNetCore.Mvc;
using Seido.Utilities.SeedGenerator;
using Models;
using Services;
using Configuration;


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
        private readonly ICityService _cityService;
        private readonly IAttractionService _attractionService;
        private readonly IUserService _userService;
        public csSeedGenerator _seeder = null;

        public csAdminController(ICityService cityService, IAttractionService attractionService, IUserService userService, ILogger<csAdminController> logger, csSeedGenerator seeder)
        {
            _seeder = seeder;
            _cityService = cityService;
            _attractionService = attractionService;
            _userService = userService;
            _logger = logger;
        }

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

        // POST: api/csAdmin/seed
        [HttpPost("seed")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> Seed(string countAttractions = "", string countCities = "", string countUsers = "")
        {
            try
            {
                _logger.LogInformation("Endpoint Seed executed");

                // Kontrollera och konvertera parametrar
                if (!int.TryParse(countAttractions, out var cAttractions) ||
                    !int.TryParse(countCities, out var cCities) ||
                    !int.TryParse(countUsers, out var cUsers))
                {
                    _logger.LogWarning("Invalid count values provided.");
                    return BadRequest("Count values must be valid integers.");
                }

                // Seed städer
                await _cityService.Seed(cCities);

                // Seed attraktioner
                await _attractionService.Seed(cAttractions);

                // Seed användare
                await _userService.Seed(cUsers);

                return Ok("Seeded attractions, cities, and users successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}