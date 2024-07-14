using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendManager.Application.Persistence;
using VendManager.Domain;

namespace VendManager.Persistence.Repositories
{
    public class MachinesRepository : GenericRepository<Machines>, IMachinesRepository
    {
        public MachinesRepository(VendorManagerDbContext context) : base(context)
        {
        }
    }
}
