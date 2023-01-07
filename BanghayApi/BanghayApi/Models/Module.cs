using BanghayApi.ServiceErrors;
using ErrorOr;

namespace BanghayApi.Models;

public class Module {
    public const int MinNameLength = 3;
    public const int MaxNameLength = 50;
    public const int MinDescriptionLength = 50;
    public const int MaxDescriptionLength = 150;
    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public string CreatedBy { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public DateTime LastModifiedDateTime { get; }
    public List<string> Tags { get; }

    private Module ( //only the admin can call it
        Guid id,
        string name,
        string description,
        string createdBy,
        DateTime startDateTime,
        DateTime endDateTime,
        DateTime lastModifiedDateTime,
        List<string> tags)

    {
        Id = id;
        Name = name;
        Description = description;
        CreatedBy = createdBy;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        LastModifiedDateTime = lastModifiedDateTime;
        Tags = tags;
    }

    public static ErrorOr<Module> Create(
        string name,
        string description,
        string createdBy,
        DateTime startDateTime,
        DateTime endDateTime,
        List<string> tags,
        Guid ? id = null)

    {

        // enforce invariants
        List<Error> errors = new ();

        if (name.Length is < MinNameLength or > MaxNameLength)
        {
            errors.Add(Errors.Module.InvalidName);
        }

        if (description.Length is < MinDescriptionLength or > MaxDescriptionLength)
        {
            errors.Add(Errors.Module.InvalidDescription);
        }

        if (errors.Count > 0) {
            return errors;
        }
        
        return new Module(
            id ?? Guid.NewGuid(),
            name,
            description,
            createdBy,
            startDateTime,
            endDateTime,
            DateTime.UtcNow,
            tags
        );
    }

}