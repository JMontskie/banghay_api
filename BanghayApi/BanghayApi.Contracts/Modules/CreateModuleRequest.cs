namespace BanghayApi.Contracts.Modules;

public record CreateModuleRequest (
    string Name,
    string Description,
    string CreatedBy,
    // string Subject,
    // string GradeLevel,
    // Byte[] file,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> Tags);
