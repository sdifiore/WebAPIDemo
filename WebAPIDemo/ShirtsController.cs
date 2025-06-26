using Microsoft.AspNetCore.Mvc;

using WebAPIDemo.Models;
using WebAPIDemo.Models.Repositories;

namespace WebAPIDemo
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetShirt()
        {
            return Ok("Reading all the shirt");
        }

        [HttpGet("{id}")]
        public IActionResult GetShirtById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid shirt ID.");

            Shirt? shirt = ShirtRepository.GetShirtById(id);

            if (shirt == null)
                return NotFound();

            return Ok(shirt);
        }

        [HttpPost]
        public IActionResult CreateShirt([FromBody] Shirt shirt)
        {
            return Ok("Creating a new shirt.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateShirt(int id)
        {
            return Ok($"Updating shirt with ID: {id}");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteShirt(int id)
        {
            return Ok($"Deleting shirt with ID: {id}");
        }
    }
}