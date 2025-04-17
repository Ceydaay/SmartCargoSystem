using MediatR;
using SmartCargo.Application.DTOs;
using SmartCargo.Application.Features.Shipments.Queries;
using SmartCargo.Application.Interfaces;

namespace SmartCargo.Application.Handlers.Shipments
{
    // Belirli bir gönderiyi ID'ye göre getiren handler
    public class GetShipmentByIdQueryHandler : IRequestHandler<GetShipmentByIdQuery, ShipmentDto>
    {
        private readonly IShipmentRepository _shipmentRepository;

        public GetShipmentByIdQueryHandler(IShipmentRepository shipmentRepository)
        {
            _shipmentRepository = shipmentRepository;
        }

        public async Task<ShipmentDto> Handle(GetShipmentByIdQuery request, CancellationToken cancellationToken)
        {
            // Shipment veritabanından alınır
            var shipment = await _shipmentRepository.GetByIdAsync(request.Id);

            // Eğer bulunamazsa null döner (404 için controller'da kontrol edilir)
            if (shipment == null)
                return null;

            // Shipment entity'si DTO'ya dönüştürülür
            return new ShipmentDto
            {
                Id = shipment.Id,
                OrderId = shipment.OrderId,
                Address = shipment.Address,
                Weight = shipment.Weight,
                DeliveryTimePreference = shipment.DeliveryTimePreference,
                AssignedCarrier = shipment.AssignedCarrier,
                CreatedAt = shipment.CreatedAt,
                CarrierId = shipment.CarrierId
            };
        }
    }
}
