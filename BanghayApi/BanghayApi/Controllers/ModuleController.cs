using BanghayApi.Contracts.Modules;
using BanghayApi.Services.Modules;
using BanghayApi.Models;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;

namespace BanghayApi.Controllers;

public class ModulesController : ApiController {
    
    private readonly IModuleService _moduleService;

    public ModulesController(IModuleService moduleService)
    {
        _moduleService = moduleService;
    }

    [HttpPost()]
    public IActionResult CreateModule(CreateModuleRequest request)
    {
        ErrorOr<Module> requestToModuleResult = Module.Create( // Map data from our API to whichever language our application on the client uses.
            request.Name,
            request.Description,
            request.CreatedBy,
            request.StartDateTime,
            request.EndDateTime,
            request.Tags);

        if (requestToModuleResult.IsError){
            return Problem(requestToModuleResult.Errors);
        }
        
        var module = requestToModuleResult.Value;
        ErrorOr<Created> createModuleResult = _moduleService.CreateModule(module);

        return createModuleResult.Match(
            created => CreatedAtGetModule(module),
            errors => Problem(errors)
        );
    
    }

   

    [HttpGet("{id:guid}")]

    public IActionResult GetModule(Guid id)
    {
        ErrorOr<Module> getModuleResult = _moduleService.GetModule(id);

        return getModuleResult.Match(
            module => Ok(MapModuleResponse(module)),
            errors => Problem(errors)
        );


    }

    [HttpPut("{id:guid}")]

    public IActionResult UpsertModule(Guid id, UpsertModuleRequest request)
    {
        ErrorOr<Module> requestToModuleResult = Module.Create(
            request.Name,
            request.Description,
            request.CreatedBy,
            request.StartDateTime,
            request.EndDateTime,
            request.Tags,
            id);

        if (requestToModuleResult.IsError){
            return Problem(requestToModuleResult.Errors);
        }

        var module = requestToModuleResult.Value;
        
        ErrorOr<UpsertedModule> upsertModuleResult = _moduleService.UpsertModule(module);

        //return 201 if a new module is created
        
        return upsertModuleResult.Match(
            upserted => upserted.IsNewlyCreated ? CreatedAtGetModule(module) : NoContent(),
            errors => Problem(errors)
        ); 
    }
    
    [HttpDelete("{id:guid}")]

    public IActionResult DeleteModule(Guid id)
    {
        ErrorOr<Deleted> deleteModuleResult = _moduleService.DeleteModule(id);

        return deleteModuleResult.Match(
            deleted => NoContent(), // if deleted, return no content.
            errors => Problem(errors) // otherwise, return an error.
        );
        // return NoContent();
    }


    private static ModuleResponse MapModuleResponse(Module module)
    {
        return new ModuleResponse (
            module.Id,
            module.Name,
            module.Description,
            module.CreatedBy,
            module.StartDateTime,
            module.EndDateTime,
            module.LastModifiedDateTime,
            module.Tags
        );
    }

     private CreatedAtActionResult CreatedAtGetModule(Module module) {
        
        return CreatedAtAction( // CreatedAtAction is a method that that returns status 201 created.
            actionName: nameof(GetModule), // where will be getting our resource from. e.g., if we created a module where will we access it? on the GetModule method.
            routeValues: new { id = module.Id },  // because the GetModule endpoint has a parameter of ID, we need to pass a parameter here.
            value: MapModuleResponse(module)); // the response content
    }
}



