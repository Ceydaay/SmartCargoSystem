using MediatR;
using Microsoft.EntityFrameworkCore;
using MassTransit;
using SmartCargo.Application.Features.Shipments.Commands;
using SmartCargo.Application.Interfaces;
using SmartCargo.Persistence.Contexts;
using SmartCargo.Persistence.Repositories;
using SmartCargo.Application.Consumers;
using SmartCargo.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// ?? PostgreSQL baðlantý dizesi okunuyor (appsettings.json)
var connectionString = builder.Configuration.GetConnectionString("Postgres");

// ?? DbContext konfigürasyonu
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// ?? Shipment için repository dependency injection ile baðlanýyor
builder.Services.AddScoped<IShipmentRepository, ShipmentRepository>();

// ?? MediatR, CQRS desenine uygun yapýlandýrýlýyor
builder.Services.AddMediatR(typeof(CreateShipmentCommand).Assembly);

// ?? MassTransit + RabbitMQ yapýlandýrmasý
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<ShipmentCreatedEventConsumer>(); // Event consumer tanýmý

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("shipment-created-event-queue", e =>
        {
            e.ConfigureConsumer<ShipmentCreatedEventConsumer>(context);
        });
    });
});

// ?? Swagger ve Controller servisi ekleniyor
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ?? Global hata yakalama middleware'i
app.UseMiddleware<ExceptionMiddleware>();

// ?? Swagger sadece development ortamýnda aktif
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

// ?? API endpoint'
