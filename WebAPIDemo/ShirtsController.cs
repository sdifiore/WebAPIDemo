using Microsoft.AspNetCore.Mvc;

namespace WebAPIDemo
{
    [ApiController]
    public class ShirtsController : ControllerBase
    {
        public string GetShirt()
        {
            return "Reading all the shirt";
        }

        public string GetShirtById(int id)
        {
            return $"Reading shirt with ID: {id}";
        }

        public string CreateShirt()
        {
            return "Creating a new shirt.";
        }

        public string UpdateShirt(int id)
        {
            return $"Updating shirt with ID: {id}";
        }

        public string DeleteShirt(int id)
        {
            return $"Deleting shirt with ID: {id}";
        }
    }
}