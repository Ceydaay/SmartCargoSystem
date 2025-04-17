using Microsoft.EntityFrameworkCore;
using SmartCargo.Application.Interfaces;
using SmartCargo.Domain.Entities;
using SmartCargo.Persistence.Contexts;

namespace SmartCargo.Persistence.Repositories
{
    // Shipment ile ilgili veritabanı işlemlerini gerçekleştiren repository sınıfı
    public class ShipmentRepository : IShipmentRepository
    {
        private readonly AppDbContext _context;

        public ShipmentRepository(AppDbContext context)
        {
            _context = context;
        }

        // Yeni shipment ekler
        public async Task AddAsync(Shipment shipment)
        {
            await _context.Shipments.AddAsync(shipment);
            await _context.SaveChangesAsync();
        }

        // Belirtilen ID'ye göre shipment siler
        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Shipments.FindAsync(id);
            if (entity is not null)
            {
                _context.Shipments.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        // Tüm shipment'ları getirir (ilgili Carrier'ları dahil eder)
        public async Task<List<Shipment>> GetAllAsync()
        {
            return await _context.Shipments.Include(s => s.Carrier).ToListAsync();
        }

        // Belirli bir shipment'ı ID ile getirir (Carrier dahil)
        public async Task<Shipment?> GetByIdAsync(Guid id)
        {
            return await _context.Shipments
                .Include(s => s.Carrier)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        // Shipment günceller
        public async Task UpdateAsync(Shipment shipment)
        {
            _context.Shipments.Update(shipment);
            await _context.SaveChangesAsync();
        }
    }
}
