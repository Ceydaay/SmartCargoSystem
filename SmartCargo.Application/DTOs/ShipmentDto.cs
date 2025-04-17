namespace SmartCargo.Application.DTOs
{
    public class ShipmentDto
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public string Address { get; set; } = string.Empty;
        public double Weight { get; set; }
        public string DeliveryTimePreference { get; set; } = string.Empty;
        public string AssignedCarrier { get; set; } = string.Empty;

        public string? OrderNumber { get; set; }
        public string? Description { get; set; }
        public string? DestinationAddress { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CarrierId { get; set; }
    }
}
