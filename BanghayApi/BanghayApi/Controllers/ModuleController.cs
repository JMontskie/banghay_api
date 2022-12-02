using BanghayApi.Contracts.Modules;
using Microsoft.AspNetCore.Mvc;

namespace BanghayApi.Controllers;

[ApiController]
[Route("[controller]")] // the .net framework allows us to use the controller name as route. In this case, we used "modules"

public class ModulesController : ControllerBase {
    [HttpPost()]

    public IActionResult CreateModule(CreateModuleRequest request)
    {
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



