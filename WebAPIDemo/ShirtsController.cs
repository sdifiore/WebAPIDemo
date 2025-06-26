using Microsoft.AspNetCore.Mvc;

using WebAPIDemo.Models;

namespace WebAPIDemo
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {
        private readonly List<Shirt> shirts =
        [
            new Shirt { ShirtId = 1, Brand = "T-Shirt", Color = "Blue", Gender = "Men", Size = 10, Price = 30 },
            new Shirt { ShirtId = 3, Brand = "T-Shirt", Color = "Black", Gender = "Men", Size = 12, Price = 35 },
            new Shirt { ShirtId = 3, Brand = "Z-Shirt", Color = "Pink", Gender = "Women", Size = 8, Price = 28 },
            new Shirt { ShirtId = 4, Brand = "Z-Shirt", Color = "Yellow", Gender = "Women", Size = 9, Price = 30 },
        ];

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

            Shirt? shirt = shirts.FirstOrDefault(s => s.ShirtId == id);

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