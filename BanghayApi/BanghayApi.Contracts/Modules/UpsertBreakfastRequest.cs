namespace BanghayApi.Contracts.Modules
{
public record UpsertModuleRequest (
    string Name,
    string Description,
    string CreatedBy,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> Tags);
}