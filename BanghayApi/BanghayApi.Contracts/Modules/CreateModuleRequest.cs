namespace BanghayApi.Contracts.Modules
{
public record CreateModuleRequest (
    string Name,
    string Description,
    string CreatedBy,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> Tags);
}