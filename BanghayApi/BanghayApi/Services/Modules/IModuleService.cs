using ErrorOr;

using BanghayApi.Models;

namespace BanghayApi.Services.Modules;

public interface IModuleService
{
    void CreateModule(Models.Module module);
    void DeleteModule(Guid id);
    ErrorOr<Module> GetModule(Guid id);
    void UpsertModule(Module module);

    /* ModuleResponse GetModule(Guid id);

    ModuleResponse UpdateModule( Guid id, UpsertModuleRequest request);

    ModuleResponse DeleteModule(Guid id); */
}