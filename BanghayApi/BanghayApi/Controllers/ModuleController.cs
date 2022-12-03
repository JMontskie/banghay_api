using BanghayApi.Contracts.Modules;
using BanghayApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BanghayApi.Controllers;

[ApiController]
[Route("[controller]")] // the .net framework allows us to use the controller name as route. In this case, we used "modules"

public class ModulesController : ControllerBase {
    
    [HttpPost()]
    public IActionResult CreateModule(CreateModuleRequest request)
    {
        var module = new Module (
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.CreatedBy,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Tags);

        // TODO: save breakfast to database

        var response = new ModuleResponse (
            module.Id,
            module.Name,
            module.Description,
            module.CreatedBy,
            module.StartDateTime,
            module.EndDateTime,
            module.LastModifiedDateTime,
            module.Tags);

        return Ok(request);
    }

    [HttpGet("{id:guid}")]

    public IActionResult GetModule(Guid id)
    {
        return Ok(id);
    }

    [HttpPut("{id:guid}")]

    public IActionResult UpsertModule(Guid id, UpsertModuleRequest request)
    {
        return Ok(request);
    }
    
    [HttpDelete("{id:guid}")]

    public IActionResult DeleteModule(Guid id)
    {
        return Ok(id);
    }
}



