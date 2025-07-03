using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using WebAPIDemo.Models.Repositories;

namespace WebAPIDemo.Filters.ExceptionFilters
{
    public class ShirtHandleUpdateExceptionsFilterAttribute : ExceptionFilterAttribute

    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            string? strShirtId = context.RouteData.Values["id"]?.ToString();

            if (int.TryParse(strShirtId, out int shirtId))
            {
                if (!ShirtRepository.ShirtExists(shirtId))
                {
                    context.ModelState.AddModelError("ShirtId", $"Shirt no longer exists.");
                    ValidationProblemDetails problemDetails = new(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound,
                        Title = "Shirt Not Found",
                        Detail = $"Shirt with ID {shirtId} does not exist."
                    };

                    context.Result = new NotFoundObjectResult(problemDetails);
                }

            }
        }
    }
}
