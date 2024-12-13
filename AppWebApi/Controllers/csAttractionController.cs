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
                _logger.LogInformation("Endpoint GetAllAttractions executed");

                if (!string.IsNullOrWhiteSpace(count) && !int.TryParse(count, out var _count))
                {
                    _logger.LogWarning("Invalid count value provided: {count}", count);
                    return BadRequest("Count must be a valid integer.");
                }

                _logger.LogInformation("Fetching attractions from service...");
                var attractions = await _service.GetAllAttractionsAsync();
                _logger.LogInformation("Successfully fetched {count} attractions", attractions.Count);

                if (!string.IsNullOrWhiteSpace(count))
                {
                    attractions = attractions.Take(int.Parse(count)).ToList();
                    _logger.LogInformation("Returning first {count} attractions", count);
                }

                return Ok(attractions);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in GetAllAttractions: {message}", ex.Message);
                return BadRequest("Error retrieving attractions: " + ex.Message);
            }
    }


        // GET: api/csAttraction/Seed
        [HttpGet("Seed")]
        [ActionName("Seed")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> Seed(string count = "1000")
        {
            try
            {
                _logger.LogInformation("Endpoint Seed executed with count: {count}", count);
                int _count = int.Parse(count);

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
        [HttpGet("GetSingleAttraction")]
        [ActionName("GetSingleAttraction")]
        [ProducesResponseType(200, Type = typeof(List<IAttraction>))]
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
        [HttpGet("GetAttractionsWithoutComments")]
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

                 //DELETE: api/attractions/deleteone/id
        [HttpDelete("{id}")]
        [ActionName("DeleteAttraction")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> DeleteAttraction(string id)
        {
            try
            {
                Guid _id = Guid.Parse(id);
                
                var attraction = await _service.DeleteAttractionAsync(_id);

                if (attraction == null) 
                {
                    return BadRequest($"The Attraction with {id} does not exist!");
                }
                _logger.LogInformation($"One Attraction with {id} has been deleted!");

                return Ok($"The attraction with {_id} is deleted from the database.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete()]
        [ActionName("DeleteAllSeededData")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> DeleteAllSeededData(bool seeded)
        {
            try
            {
                _logger.LogInformation("Endpoint Delete all data executed");

                await _service.DeleteAllSeededData(seeded);
                return Ok("Data has been deleted");

                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
