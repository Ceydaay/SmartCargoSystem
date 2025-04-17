using MediatR;
using SmartCargo.Application.DTOs;

namespace SmartCargo.Application.Features.Shipments.Queries
{
    public class GetShipmentByIdQuery : IRequest<ShipmentDto>
    {
        public Guid Id { get; set; }
    }
}
