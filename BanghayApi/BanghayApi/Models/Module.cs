namespace BanghayApi.Models;

public class Module {
    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public string CreatedBy { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public DateTime LastModifiedDateTime { get; }
    public List<string> Tags { get; }

    public Module (
        Guid id,
        string name,
        string description,
        string createdBy,
        DateTime startDateTime,
        DateTime endDateTime,
        DateTime lastModifiedDateTime,
        List<string> tags)

        {
            // enforce invariants
            // referencing the public classes above
            Id = id;
            Name = name;
            Description = description;
            CreatedBy = createdBy;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            LastModifiedDateTime = lastModifiedDateTime;
            Tags = tags;
        }

}