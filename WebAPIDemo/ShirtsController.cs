using Microsoft.AspNetCore.Mvc;

using WebAPIDemo.Models;

namespace WebAPIDemo
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {
        [HttpGet]
        public string GetShirt()
        {
            return "Reading all the shirt";
        }

        [HttpGet("{id}")]
        public string GetShirtById(int id)
        {
            return $"Reading shirt with ID: {id}";
        }

        [HttpPost]
        public string CreateShirt([FromBody] Shirt shirt)
        {
            return "Creating a new shirt.";
        }

        [HttpPut("{id}")]
        public string UpdateShirt(int id)
        {
            return $"Updating shirt with ID: {id}";
        }

        [HttpDelete("{id}")]
        public string DeleteShirt(int id)
        {
            return $"Deleting shirt with ID: {id}";
        }
    }
}