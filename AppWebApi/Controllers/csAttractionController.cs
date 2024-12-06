using System;
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
        private readonly IAttractionService _service;
        private readonly ILogger<csAttractionController> _logger;

        public csAttractionController(IAttractionService service, ILogger<csAttractionController> logger)
        {
            _service = service;
            _logger = logger;
        }

        // GET: api/csAttraction/GetAllAttractions
        [HttpGet("GetAllAttractions")]
        [ProducesResponseType(200, Type = typeof(List<csAttraction>))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> GetAllAttractions(string count)
        {
            try
            {
                _logger.LogInformation("Endpoint All Attraction executed");

                if (!int.TryParse(count, out var _count))
                {
                    _logger.LogWarning("Invalid count value provided: {count}", count);
                    return BadRequest("Count must be a valid integer.");
                }

                var attractions = await _service.GetFilteredAttractionsAsync(_count);
                return Ok(attractions);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in GetAllAttractions: {message}", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        // GET: api/csAttraction/Seed
        [HttpGet("Seed")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> Seed(string count = "10")
        {
            try
            {
                _logger.LogInformation("Endpoint Seed executed");
                int _count = int.Parse(count);

                // if (!int.TryParse(count, out var _count))
                // {
                //     _logger.LogWarning("Invalid count value provided: {count}", count);
                //     return BadRequest("Count must be a valid integer.");
                // }

                await _service.Seed(_count);
                return Ok("Seeded Attractions");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in Seed: {message}", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        // GET: api/csAttraction/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(csAttraction))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> GetSingleAttraction(Guid id)
        {
            try
            {
                _logger.LogInformation($"Fetching attraction with ID: {id}");
                var attraction = await _service.GetSingleAttractionAsync(id);
                if (attraction == null)
                {
                    return NotFound();
                }
                return Ok(attraction);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in GetSingleAttraction: {message}", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        // GET: api/csAttraction/nocomments
        [HttpGet("nocomments")]
        [ProducesResponseType(200, Type = typeof(List<csAttraction>))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> GetAttractionsWithoutComments()
        {
            try
            {
                _logger.LogInformation("Fetching attractions without comments.");
                var attractions = await _service.GetAttractionsWithoutCommentsAsync();
                return Ok(attractions);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in GetAttractionsWithoutComments: {message}", ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
