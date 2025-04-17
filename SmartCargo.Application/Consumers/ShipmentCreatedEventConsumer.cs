using MassTransit;
using SmartCargo.Application.Events;

namespace SmartCargo.Application.Consumers
{
    public class ShipmentCreatedEventConsumer : IConsumer<ShipmentCreatedEvent>
    {
        public Task Consume(ConsumeContext<ShipmentCreatedEvent> context)
        {
            var shipment = context.Message;

            Console.WriteLine($"📦 Yeni gönderi oluşturuldu: {shipment.OrderNumber} → {shipment.DestinationAddress}");

            
            return Task.CompletedTask;
        }
    }
}
