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