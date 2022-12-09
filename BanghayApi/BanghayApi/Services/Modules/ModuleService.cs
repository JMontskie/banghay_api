using BanghayApi.Models;
using ErrorOr;
using BanghayApi.ServiceErrors;


namespace BanghayApi.Services.Modules;

public class ModuleService : IModuleService
{
    private static readonly Dictionary<Guid, Module> _modules = new(); // a dictionary contains a collection of key/value pairs

    public void CreateModule(Module module)
    {
        _modules.Add(module.Id, module);
    }

    public void DeleteModule(Guid id)
    {
        _modules.Remove(id);
    }

    public ErrorOr<Module> GetModule(Guid id)
    {
        if (_modules.TryGetValue(id, out var module))
        {
            return module;
        }

        return Errors.Module.NotFound;
    }

    public void UpsertModule(Module module)
    {
        _modules[module.Id] = module;
    }
}
