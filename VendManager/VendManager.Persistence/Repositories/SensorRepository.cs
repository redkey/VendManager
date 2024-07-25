using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using VendManager.Application.Models;
using VendManager.Application.Persistence;
using VendManager.Domain;

namespace VendManager.Persistence.Repositories
{
    public class SensorRepository : GenericRepository<Sensor>, ISensorRepository
    {
        public SensorRepository(VendorManagerDbContext context) : base(context)
        {
        }

        public async Task<List<Machines>> GetAllMachinesWithSensorDetails()
        {
            var machines = await _context.Machines
           .Include(m => m.SensorBars)
           .ThenInclude(sb => sb.Sensors)
           .ToListAsync();


            return machines;

           
        }

        public async Task<List<Sensor>> GetMachineWithSensorDetails(long machineId)
        {
            var machine = await _context.Machines
          .Include(m => m.SensorBars)
          .ThenInclude(sb => sb.Sensors)
          .FirstOrDefaultAsync(m => m.ID == machineId);

            if (machine == null)
            {
                return null;
            }

            // Flatten the sensors from all sensor bars
            var sensors = machine.SensorBars
                .SelectMany(sb => sb.Sensors)
                .ToList();

            return sensors;
        }
    }
}
