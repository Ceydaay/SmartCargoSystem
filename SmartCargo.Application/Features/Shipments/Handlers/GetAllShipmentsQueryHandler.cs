using MediatR;
using SmartCargo.Application.DTOs;
using SmartCargo.Application.Features.Shipments.Queries;
using SmartCargo.Application.Interfaces;

namespace SmartCargo.Application.Features.Shipments.Handlers
{
    // Tüm gönderileri listeleyen sorgu handler'ı
    public class GetAllShipmentsQueryHandler : IRequestHandler<GetAllShipmentsQuery, List<ShipmentDto>>
    {
        private readonly IShipmentRepository _shipmentRepository;

        public GetAllShipmentsQueryHandler(IShipmentRepository shipmentRepository)
        {
            _shipmentRepository = shipmentRepository;
        }

        public async Task<List<ShipmentDto>> Handle(GetAllShipmentsQuery request, CancellationToken cancellationToken)
        {
            // Veritabanından shipment'lar çekilir
            var shipments = await _shipmentRepository.GetAllAsync();

            // Entity listesi DTO listesine dönüştürülerek geri döner
            return shipments.Select(s => new ShipmentDto
            {
                Id = s.Id,
                OrderNumber = s.OrderNumber,
                Description = s.Description,
                DestinationAddress = s.DestinationAddress,
                CreatedAt = s.CreatedAt,
                CarrierId = s.CarrierId
            }).ToList();
        }
    }
}
