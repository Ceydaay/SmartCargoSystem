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

// ?? PostgreSQL ba�lant� dizesi okunuyor (appsettings.json)
var connectionString = builder.Configuration.GetConnectionString("Postgres");

// ?? DbContext konfig�rasyonu
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// ?? Shipment i�in repository dependency injection ile ba�lan�yor
builder.Services.AddScoped<IShipmentRepository, ShipmentRepository>();

// ?? MediatR, CQRS desenine uygun yap�land�r�l�yor
builder.Services.AddMediatR(typeof(CreateShipmentCommand).Assembly);

// ?? MassTransit + RabbitMQ yap�land�rmas�
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<ShipmentCreatedEventConsumer>(); // Event consumer tan�m�

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

// ?? Swagger sadece development ortam�nda aktif
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

// ?? API endpoint'
