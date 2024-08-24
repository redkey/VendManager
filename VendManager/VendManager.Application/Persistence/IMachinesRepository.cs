using VendManager.Domain;

namespace VendManager.Application.Persistence
{
    public interface IMachinesRepository : IGenericRepository<Machines>
    {
        Task<List<Machines>> GetAllMachinesWithSensorBarDetails();
        Task<List<Machines>> GetAllMachinesWithSensorDetails();
       
    }

}   
