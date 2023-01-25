namespace BanghayApi.Controllers;

using System;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;


[ApiController]
[Route("[controller]")] // the .net framework allows us to use the controller name as route. In this case, we used "modules"
public class ApiController : ControllerBase
{
    protected IActionResult Problem(List<Error> errors)
    {
        if (errors.All(e => e.Type == ErrorType.Validation)) //if we had validation error, return bad request with all the details

        {
            var modelStateDictionary = new ModelStateDictionary();

            foreach (var error in errors)
            {
                modelStateDictionary.AddModelError(error.Code, error.Description);
            }

            return ValidationProblem(modelStateDictionary); //converts error to error-response which contains all the details about the error.
        }

        if (errors.Any(e => e.Type == ErrorType.Unexpected))
        {
            return Problem();
        }
        
        var firstError = errors [0];

        var statusCode = firstError.Type switch
        {
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            _ =>StatusCodes.Status500InternalServerError //otherwise
            
        };

        return Problem(statusCode: statusCode, title: firstError.Description);
    }

}