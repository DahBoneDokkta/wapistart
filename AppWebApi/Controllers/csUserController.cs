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

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class csAttractionController : ControllerBase
    {
        private readonly IAttractionService _attractionService;

        public csAttractionController(IAttractionService attractionService)
        {
            _attractionService = attractionService;
        }

        [HttpGet]
        public async Task<ActionResult<List<IAttraction>>> GetAttractions(int count)
        {
            var attractions = await _attractionService.GetAttractionsAsync(count);
            return Ok(attractions);
        }

        [HttpPost("seed")]
        public async Task<IActionResult> SeedAttractions(int count)
        {
            await _attractionService.SeedAttractionsAsync(count);
            return Ok();
        }

        [HttpDelete("clear")]
        public async Task<IActionResult> ClearTestData()
        {
            await _attractionService.ClearTestDataAsync();
            return Ok("Test data cleared");
        }
    }
}