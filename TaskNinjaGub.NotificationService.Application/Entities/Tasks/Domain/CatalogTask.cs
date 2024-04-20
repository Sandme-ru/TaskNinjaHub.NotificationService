using System.ComponentModel.DataAnnotations;
using TaskNinjaGub.NotificationService.Application.Entities.Authors.Domain;
using TaskNinjaGub.NotificationService.Application.Entities.InformationSystems.Domain;
using TaskNinjaGub.NotificationService.Application.Entities.Priorities.Domain;
using TaskNinjaGub.NotificationService.Application.Entities.TaskStatuses.Domain;
using TaskNinjaGub.NotificationService.Application.Entities.TaskTypes.Domain;
using File = TaskNinjaGub.NotificationService.Application.Entities.Files.Domain.File;

namespace TaskNinjaGub.NotificationService.Application.Entities.Tasks.Domain;

public class CatalogTask
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string? Description { get; set; }
    public int TaskAuthorId { get; set; }

    public virtual Author? TaskAuthor { get; set; }

    public int TaskExecutorId { get; set; }

    public virtual Author? TaskExecutor { get; set; }

    public int InformationSystemId { get; set; }

    public virtual InformationSystem? InformationSystem { get; set; }
    public int PriorityId { get; set; }

    public virtual Priority? Priority { get; set; }
    public int TaskStatusId { get; set; }

    public virtual CatalogTaskStatus? TaskStatus { get; set; }

    public virtual List<File>? Files { get; set; }

    public int? OriginalTaskId { get; set; }

    public virtual CatalogTask? OriginalTask { get; set; }

    public DateTime? DateStart { get; set; }

    public DateTime? DateEnd { get; set; }
    public int TaskTypeId { get; set; }

    public virtual CatalogTaskType? TaskType { get; set; }
}