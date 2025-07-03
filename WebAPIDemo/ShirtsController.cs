using Microsoft.AspNetCore.Mvc;

using WebAPIDemo.Filters.ActionFilters;
using WebAPIDemo.Filters.ExceptionFilters;
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
        [ShirtHandleUpdateExceptionsFilter]
        public IActionResult UpdateShirt(int id, Shirt shirt)
        {
            ShirtRepository.UpdateShirt(shirt);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteShirt(int id)
        {
            Shirt? shirt = ShirtRepository.GetShirtById(id);
            ShirtRepository.DeleteShirt(id);

            return Ok(shirt);
        }
    }
}