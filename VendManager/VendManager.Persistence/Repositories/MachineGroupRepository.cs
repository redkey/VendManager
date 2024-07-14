using VendManager.Application.Persistence;
using VendManager.Domain;

namespace VendManager.Persistence.Repositories
{
    public class MachineGroupRepository : GenericRepository<MachineGroups>, IMachineGroupRepository
    {
        public MachineGroupRepository(VendorManagerDbContext context) : base(context)
        {
        }
    }
}
