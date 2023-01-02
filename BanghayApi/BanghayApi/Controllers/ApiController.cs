namespace BanghayApi.Controllers;

using System;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")] // the .net framework allows us to use the controller name as route. In this case, we used "modules"
public class ApiController : ControllerBase
{
    protected IActionResult Problem(List<Error> errors)
    {
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