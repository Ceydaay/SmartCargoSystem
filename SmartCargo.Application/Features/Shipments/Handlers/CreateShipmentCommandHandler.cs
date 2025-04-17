using MediatR;
using SmartCargo.Application.DTOs;
using SmartCargo.Application.Features.Shipments.Commands;
using SmartCargo.Domain.Entities;
using SmartCargo.Application.Interfaces;
using MassTransit;
using SmartCargo.Application.Events;

namespace SmartCargo.Application.Features.Shipments.Handlers
{
    public class CreateShipmentCommandHandler : IRequestHandler<CreateShipmentCommand, Guid>
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IPublishEndpoint _publishEndpoint;

        public CreateShipmentCommandHandler(IShipmentRepository shipmentRepository, IPublishEndpoint publishEndpoint)
        {
            _shipmentRepository = shipmentRepository;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<Guid> Handle(CreateShipmentCommand request, CancellationToken cancellationToken)
        {
            // Yeni shipment nesnesi oluşturuluyor
            var entity = new Shipment
            {
                Id = Guid.NewGuid(),
                OrderNumber = request.Shipment.OrderNumber,
                Description = request.Shipment.Description,
                DestinationAddress = request.Shipment.DestinationAddress,
                CarrierId = request.Shipment.CarrierId,
                Address = request.Shipment.Address,
                DeliveryTimePreference = request.Shipment.DeliveryTimePreference,
                AssignedCarrier = request.Shipment.AssignedCarrier,
                Weight = request.Shipment.Weight,
            };

            // Veritabanına kayıt ediliyor
            await _shipmentRepository.AddAsync(entity);

            // ShipmentCreatedEvent tetikleniyor (MassTransit ile RabbitMQ'ya publish edilir)
            var shipmentEvent = new ShipmentCreatedEvent
            {
                ShipmentId = entity.Id,
                OrderNumber = entity.OrderNumber,
                DestinationAddress = entity.DestinationAddress
            };

            await _publishEndpoint.Publish(shipmentEvent);

            // Oluşturulan shipment'ın ID'si geri dönülüyor
            return entity.Id;
        }
    }
}
