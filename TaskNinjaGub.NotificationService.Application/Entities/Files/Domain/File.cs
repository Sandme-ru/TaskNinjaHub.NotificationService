using System.Text.Json.Serialization;
using TaskNinjaGub.NotificationService.Application.Entities.Tasks.Domain;

namespace TaskNinjaGub.NotificationService.Application.Entities.Files.Domain;

public class File
{
    public int Id { get; set; }
    
    public string? Name { get; set; }

    public DateTime? DateCreated { get; set; }
    
    public int? TaskId { get; set; }

    [JsonIgnore]
    public virtual CatalogTask? Task { get; set; }
}