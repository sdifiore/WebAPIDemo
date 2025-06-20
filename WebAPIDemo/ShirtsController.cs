using Microsoft.AspNetCore.Mvc;

namespace WebAPIDemo
{
    [ApiController]
    public class ShirtsController : ControllerBase
    {
        [HttpGet]
        [Route("/shirts")]
        public string GetShirt()
        {
            return "Reading all the shirt";
        }

        [HttpGet]
        [Route("/shirts/{id}")]
        public string GetShirtById(int id)
        {
            return $"Reading shirt with ID: {id}";
        }

        [HttpPost]
        [Route("/shirts")]
        public string CreateShirt()
        {
            return "Creating a new shirt.";
        }

        [HttpPut]
        [Route("/shirts/{id}")]
        public string UpdateShirt(int id)
        {
            return $"Updating shirt with ID: {id}";
        }

        [HttpDelete]
        [Route("/shirts/{id}")]
        public string DeleteShirt(int id)
        {
            return $"Deleting shirt with ID: {id}";
        }
    }
}