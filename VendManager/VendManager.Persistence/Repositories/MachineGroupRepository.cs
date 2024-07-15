using VendManager.Application.Persistence;
using VendManager.Domain;

namespace VendManager.Persistence.Repositories
{
    public class MachineGroupRepository : GenericRepository<MachineGroups>, IMachineRepository
    {
        public MachineGroupRepository(VendorManagerDbContext context) : base(context)
        {
        }
    }
}
