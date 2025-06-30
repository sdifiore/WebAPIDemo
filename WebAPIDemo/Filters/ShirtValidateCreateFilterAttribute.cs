using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using WebAPIDemo.Models;
using WebAPIDemo.Models.Repositories;

namespace WebAPIDemo.Filters
{
    public class ShirtValidateCreateFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            Shirt? shirt = context.ActionArguments["shirt"] as Models.Shirt;

            if (shirt is null)
            {
                context.ModelState.AddModelError("Shirt", "Invalid shirt object.");
                ValidationProblemDetails problemDetails = new(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };

                context.Result = new BadRequestObjectResult(problemDetails);
            }

            else
            {
                Shirt? existingShirt = ShirtRepository.GetShirtByProperties(
                shirt.Brand,
                shirt.Gender,
                shirt.Color,
                shirt.Size
            );

                if (existingShirt != null)
                {
                    context.ModelState.AddModelError("Shirt", "Shirt already exists.");
                    ValidationProblemDetails problemDetails = new(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest,
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
            }
        }
    }
}
