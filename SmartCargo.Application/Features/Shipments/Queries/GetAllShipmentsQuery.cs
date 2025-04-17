using MediatR;
using SmartCargo.Application.DTOs;

namespace SmartCargo.Application.Features.Shipments.Queries
{
    public class GetAllShipmentsQuery : IRequest<List<ShipmentDto>>
    {
    }
}
