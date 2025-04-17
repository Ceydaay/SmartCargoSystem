using System.Threading;

namespace SmartCargo.Domain.Entities
{
    public class Shipment
    {
        public Guid Id { get; set; } // Benzersiz ID

        public string? OrderNumber { get; set; } // Sipariş numarası

        public string? Description { get; set; } // Açıklama

        public string? DestinationAddress { get; set; } // Varış adresi

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Oluşturulma tarihi

        public Guid CarrierId { get; set; } // Foreign key

        public Carrier? Carrier { get; set; } // Navigation Property

        public Guid OrderId { get; set; }
       
        public string Address { get; set; }
        public double Weight { get; set; }
        public string DeliveryTimePreference { get; set; }
        public string AssignedCarrier { get; set; }
       

    }
}
