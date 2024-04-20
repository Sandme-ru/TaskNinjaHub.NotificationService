using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TaskNinjaGub.NotificationService.Application.Entities.Authors.Enums;
using TaskNinjaGub.NotificationService.Application.Entities.Tasks.Domain;

namespace TaskNinjaGub.NotificationService.Application.Entities.Authors.Domain;

public class Author
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? ShortName { get; set; }

    public string? RoleName { get; set; }

    public string? AuthGuid { get; set; }

    [JsonIgnore]
    public virtual List<CatalogTask>? ExecutableTasks { get; set; }

    [JsonIgnore]
    public virtual List<CatalogTask>? AssignedTasks { get; set; }

    public LocalizationType? LocalizationType { get; set; }

    [NotMapped]
    public int? CountPerformedTasks { get; set; }

    [NotMapped] 
    public string? FullName => ShortName == null ? null : $"{ShortName} [{CountPerformedTasks}]";
}