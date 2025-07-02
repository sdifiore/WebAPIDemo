using Microsoft.AspNetCore.Mvc;

using WebAPIDemo.Filters;
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
            return Ok(ShirtRepository.GetAllShirts());
        }

        [HttpGet("{id}")]
        [ShirtValidateShirtIdFilter]
        public IActionResult GetShirtById(int id)
        {
            return Ok(ShirtRepository.GetShirtById(id));
        }

        [HttpPost]
        [ShirtValidateCreateFilter]
        public IActionResult CreateShirt([FromBody] Shirt shirt)
        {
            ShirtRepository.AddShirt(shirt);

            return CreatedAtAction(nameof(GetShirtById),
                new { id = shirt.ShirtId }, shirt);
            // WebApi Convention: Returns 201 Created with the location of the new resource
        }

        [HttpPut("{id}")]
        [ShirtValidateUpdateFilter]
        [ShirtValidateShirtIdFilter]
        public IActionResult UpdateShirt(int id, Shirt shirt)
        {
            try
            {
                ShirtRepository.UpdateShirt(shirt);
            }

            catch
            {
                if (!ShirtRepository.ShirtExists(id))
                    return NotFound($"Shirt with ID {id} not found.");

                throw; // http 500 Internal Server Error
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteShirt(int id)
        {
            return Ok($"Deleting shirt with ID: {id}");
        }
    }
}