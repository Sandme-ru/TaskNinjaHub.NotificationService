using TaskNinjaGub.NotificationService.Application.Entities.Tasks.Domain;

namespace TaskNinjaGub.NotificationService.Application.Entities.Tasks.Dto;

public class CatalogTaskRequestModel
{
    public CatalogTask Task { get; set; }

    public bool IsUpdated { get; set; }
}