namespace BanghayApi.Contracts.Modules;

public record ModuleResponse (
    Guid Id,
    string Name,
    string Description,
    string CreatedBy,
    DateTime StartDateTime,
    DateTime EndDateTime,
    DateTime LastModifiedDateTime,
    List<string> Tags);


