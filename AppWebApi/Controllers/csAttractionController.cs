using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Models;
using Services;
using Configuration;
using Seido.Utilities.SeedGenerator;

namespace AppWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class csAttractionController : Controller
    {
        private readonly IAttractionService _service = null;
        private readonly ILogger<csAttractionController> _logger = null;

        public csAttractionController(IAttractionService service  ,ILogger<csAttractionController> logger)
        {
            _service = service;
            _logger = logger;
        }

        // GET: api/csAttraction
        [HttpGet("GetAllAttractions")]
        [ActionName("GetAttractions")]
        [ProducesResponseType(200, Type = typeof(List<csAttraction>))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> GetAllAttractions([FromQuery] string count)
        {
            try
            {
                _logger.LogInformation("Endpoint All Attraction executed");

                if (!int.TryParse(count, out var _count))
                {
                    _logger.LogWarning("Invalid count value provided: {count}", count);
                    return BadRequest("Count must be a valid integer.");
                }
                
                // var _count = int.Parse(count);

                var attractions = await _service.GetFilteredAttractionsAsync(_count);
                return Ok(attractions);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in GettAllAttractions: {message}", ex.Message);
                return BadRequest(ex.Message);
            }
        }

    [HttpGet()]
    [ActionName("Seed")]
    [ProducesResponseType(200, Type = typeof(string))]
    [ProducesResponseType(400, Type = typeof(string))]

    public async Task<IActionResult> Seed(string count = "1000")
        {
            try
            {
                _logger.LogInformation("Endpoint Seed executed");
                int _count = int.Parse(count);


                await _service.Seed(_count);
                return Ok("Seeded Attractions");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

    }
}