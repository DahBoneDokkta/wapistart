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


        private csSeedGenerator _seeder = null;

        public csAdminController(ILogger<csAdminController> logger)
        {
            _logger = logger;
            _seeder = new csSeedGenerator();
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
    }
}