using BanghayApi.Contracts.Modules;
using BanghayApi.Services.Modules;
using BanghayApi.Models;
using Microsoft.AspNetCore.Mvc; //
using ErrorOr;
using BanghayApi.ServiceErrors;

namespace BanghayApi.Controllers;

[ApiController]
[Route("[controller]")] // the .net framework allows us to use the controller name as route. In this case, we used "modules"

public class ModulesController : ControllerBase {
    
    private readonly IModuleService _moduleService;

    public ModulesController(IModuleService moduleService)
    {
        _moduleService = moduleService;
    }

    [HttpPost()]
    public IActionResult CreateModule(CreateModuleRequest request)
    {
        var module = new Module ( // Map data from our API to whichever language our application on the client uses.
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.CreatedBy,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Tags);

        // TODO: save module to database

        _moduleService.CreateModule(module);

        var response = new ModuleResponse ( // Take data from the system and convert it back to our API definition.
            module.Id,
            module.Name,
            module.Description,
            module.CreatedBy,
            module.StartDateTime,
            module.EndDateTime,
            module.LastModifiedDateTime,
            module.Tags);

         // return Ok(response); will only return 200 Ok

        return CreatedAtAction( // CreatedAtAction is a method that that returns status 201 created.
            actionName: nameof(GetModule), // where will be getting our resource from. e.g., if we created a module where will we access it? on the GetModule method.
            routeValues: new { id = module.Id },  // because the GetModule endpoint has a parameter of ID, we need to pass a parameter here.
            value: response); // the response content
    }

    [HttpGet("{id:guid}")]

    public IActionResult GetModule(Guid id)
    {
        ErrorOr<Module> getModuleResult = _moduleService.GetModule(id);

        if (getModuleResult.IsError && getModuleResult.FirstError == Errors.Module.NotFound)
        {
            return NotFound();
        }

        var module = getModuleResult.Value;

        var response = new ModuleResponse (
            module.Id,
            module.Name,
            module.Description,
            module.CreatedBy,
            module.StartDateTime,
            module.EndDateTime,
            module.LastModifiedDateTime,
            module.Tags
        );
        return Ok(response);
    }

    [HttpPut("{id:guid}")]

    public IActionResult UpsertModule(Guid id, UpsertModuleRequest request)
    {
        var module = new Module(
            id, //USES ID from route
            request.Name,
            request.Description,
            request.CreatedBy,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Tags
        );
        _moduleService.UpsertModule(module);

        //return 201 if a new module is created
        
        return NoContent(); //returns no content if there is an existing ID of a data in the database, otherwise, if ID = none and details is 
                            // valid, return similar response just like the create endpoint.
    }
    
    [HttpDelete("{id:guid}")]

    public IActionResult DeleteModule(Guid id)
    {
        _moduleService.DeleteModule(id);
        return NoContent();
    }
}



