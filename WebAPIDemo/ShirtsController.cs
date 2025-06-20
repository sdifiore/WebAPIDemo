using Microsoft.AspNetCore.Mvc;

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
        public string GetShirtById(int id, [FromHeader(Name = "Color")] string color)
        {
            return $"Reading shirt with ID: {id}, color: {color}";
        }

        [HttpPost]
        public string CreateShirt()
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