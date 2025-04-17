using Microsoft.AspNetCore.Mvc;
using MediatR;
using SmartCargo.Application.DTOs;
using SmartCargo.Application.Features.Shipments.Commands;
using SmartCargo.Application.Features.Shipments.Queries;

namespace SmartCargo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShipmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Yeni bir gönderi oluşturur
        [HttpPost]
        public async Task<IActionResult> CreateShipment([FromBody] CreateShipmentDto dto)
        {
            var command = new CreateShipmentCommand(dto);
            var result = await _mediator.Send(command);
            return Ok(new { ShipmentId = result }); // Oluşturulan shipment ID'sini döner
        }

        // Tüm gönderileri listeler
        [HttpGet]
        public async Task<IActionResult> GetAllShipments()
        {
            var result = await _mediator.Send(new GetAllShipmentsQuery());
            return Ok(result);
        }

        // Belirli bir gönderiyi ID ile getirir
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShipmentById(Guid id)
        {
            var result = await _mediator.Send(new GetShipmentByIdQuery { Id = id });

            if (result == null)
                return NotFound(); // Gönderi yoksa 404

            return Ok(result); // Varsa 200 ve veri
        }
    }
}
