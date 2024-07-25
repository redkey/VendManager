using VendManager.Application.Models;
using VendManager.Domain;

namespace VendManager.Application.Persistence
{
    public interface ISensorRepository : IGenericRepository<Sensor>
    {

        Task<List<Machines>> GetAllMachinesWithSensorDetails();
        Task<List<Sensor>> GetMachineWithSensorDetails(long machineId);
    }

}
