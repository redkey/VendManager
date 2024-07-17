using VendManager.BlazorUI.Models;
using VendManager.BlazorUI.Services.Base;

namespace VendManager.BlazorUI.Contracts
{
    public interface IMachineService
    {
        Task<Response<Guid>> CreateMachine(MachineVM machine);
        Task<List<MachineVM>> GetMachines();
        Task<Response<MachineVM>> GetMachine(long id);
        Task<Response<Guid>> UpdateMachine(long id , MachineVM machine);
        Task<Response<Guid>> DeleteMachine(long id);
    }
}
