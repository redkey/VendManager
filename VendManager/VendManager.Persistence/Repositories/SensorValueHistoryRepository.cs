using VendManager.Application.Persistence;
using VendManager.Domain;

namespace VendManager.Persistence.Repositories
{
    public class SensorValueHistoryRepository : GenericRepository<SensorValueHistory>, ISensorValueHistoryRepository
    {
        public SensorValueHistoryRepository(VendorManagerDbContext context) : base(context)
        {
        }
    }
}