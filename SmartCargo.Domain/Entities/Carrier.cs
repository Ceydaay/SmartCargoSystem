namespace SmartCargo.Domain.Entities
{
    public class Carrier
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public List<Shipment> Shipments { get; set; } = new();
    }
}

