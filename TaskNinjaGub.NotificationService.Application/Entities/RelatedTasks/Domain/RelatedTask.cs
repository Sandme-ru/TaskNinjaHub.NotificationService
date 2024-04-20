using TaskNinjaGub.NotificationService.Application.Entities.Tasks.Domain;

namespace TaskNinjaGub.NotificationService.Application.Entities.RelatedTasks.Domain;

public class RelatedTask
{
    public int Id { get; set; }

    public int MainTaskId { get; set; }

    public virtual CatalogTask? MainTask { get; set; }

    public int SubordinateTaskId { get; set; }

    public virtual CatalogTask? SubordinateTask { get; set; }
}