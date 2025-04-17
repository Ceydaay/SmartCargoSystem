using MediatR;
using SmartCargo.Application.DTOs;

namespace SmartCargo.Application.Features.Shipments.Commands
{
    public class CreateShipmentCommand : IRequest<Guid>
    {
        public CreateShipmentDto Shipment { get; set; }

        public CreateShipmentCommand(CreateShipmentDto shipment)
        {
            Shipment = shipment;
        }
    }
}
