using Microsoft.EntityFrameworkCore;
using VendManager.Application.Persistence;
using VendManager.Domain;

namespace VendManager.Persistence.Repositories
{
    public class SensorValueHistoryRepository : GenericRepository<SensorValueHistory>, ISensorValueHistoryRepository
    {
        public SensorValueHistoryRepository(VendorManagerDbContext context) : base(context)
        {
        }

        public async Task<List<SensorValueHistory>> GetAllById(long Id)
        {
           var sensoValue = await _context.SensorValueHistory.Where(x => x.SensorID == Id).ToListAsync();
           return sensoValue;
        }
    }
}