using BanghayApi.Models;
using ErrorOr;
using BanghayApi.ServiceErrors;


namespace BanghayApi.Services.Modules;

public class ModuleService : IModuleService
{
    private static readonly Dictionary<Guid, Module> _modules = new(); // a dictionary contains a collection of key/value pairs

    public ErrorOr<Created> CreateModule(Module module)
    {
        _modules.Add(module.Id, module);

        return Result.Created;
    }

    public ErrorOr<Deleted> DeleteModule(Guid id)
    {
        _modules.Remove(id);

        return Result.Deleted;
    }

    public ErrorOr<Module> GetModule(Guid id)
    {
        if (_modules.TryGetValue(id, out var module))
        {
            return module;
        }

        return Errors.Module.NotFound;
    }

    public ErrorOr<UpsertedModule> UpsertModule(Module module)
    {
        var IsNewlyCreated = !_modules.ContainsKey(module.Id); // if the modules dictionary doesn't contain the given ID, then create a new one.
        _modules[module.Id] = module;

        return new UpsertedModule(IsNewlyCreated);
    }
}
