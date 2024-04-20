using MassTransit;
using TaskNinjaGub.NotificationService.Application.Entities.Email.Consumer;
using TaskNinjaHub.NotificationService.WebApi.Subdomain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<CreateConsumer>();
    x.AddConsumer<UpdateConsumer>();
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("54.39.207.182", 5673,"/",c =>
        {
            c.Username("guest");
            c.Password("guest");
        });

        cfg.ReceiveEndpoint("CreateEmailQueue", e =>
        {
            e.ConfigureConsumer<CreateConsumer>(context);
        });
        cfg.ReceiveEndpoint("UpdateEmailQueue", e =>
        {
            e.ConfigureConsumer<UpdateConsumer>(context);
        });
        cfg.ClearSerialization();
        cfg.UseRawJsonSerializer();
        cfg.ConfigureEndpoints(context);
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
{
#if RELEASE
    o.DocumentFilter<SubdomainRouteAttribute>();
#endif
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
