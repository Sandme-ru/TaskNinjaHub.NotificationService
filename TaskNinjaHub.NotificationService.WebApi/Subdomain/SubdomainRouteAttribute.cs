using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TaskNinjaHub.NotificationService.WebApi.Subdomain;

public class SubdomainRouteAttribute : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        foreach (var path in swaggerDoc.Paths.ToList())
        {
            swaggerDoc.Paths.Remove(path.Key);
            var newPathKey = "/notify" + path.Key;
            swaggerDoc.Paths.Add(newPathKey, path.Value);
        }
    }
}