public class CreateShipmentDto
{
    public string OrderNumber { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string DestinationAddress { get; set; } = null!;
    public string Address { get; set; } = null!;
    public Guid CarrierId { get; set; }

    public string DeliveryTimePreference { get; set; } = null!;
    public string AssignedCarrier { get; set; } = null!;
    public double Weight { get; set; }
}
