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

namespace AppWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class csAttractionController : Controller
    {
        private IAttractionService _service = null;
        private ILogger<csAdminController> _logger = null;

        public csAttractionController(IAttractionService service  ,ILogger<csAdminController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet()]
        [ActionName("GetAttractions")]
        [ProducesResponseType(200, Type = typeof(List<IAttraction>))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> GetAllAttractions(string count)
        {
            try
            {
                _logger.LogInformation("Endpoint All Attraction executed");
                var _count = int.Parse(count);

                var attractions = await _service.RetrieveAttractionsAsync(_count);
                return Ok(attractions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
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