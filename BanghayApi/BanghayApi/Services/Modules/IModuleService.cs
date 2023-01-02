using ErrorOr;

using BanghayApi.Models;

namespace BanghayApi.Services.Modules;

public interface IModuleService
{
    ErrorOr<Created> CreateModule(Models.Module module);
    ErrorOr<Deleted> DeleteModule(Guid id);
    ErrorOr<Module> GetModule(Guid id);
    ErrorOr<UpsertedModule> UpsertModule(Module module);

}