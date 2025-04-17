namespace SmartCargo.Application.Events
{
    public class ShipmentCreatedEvent
    {
        public Guid ShipmentId { get; set; }
        public string OrderNumber { get; set; }
        public string DestinationAddress { get; set; }
    }
}
