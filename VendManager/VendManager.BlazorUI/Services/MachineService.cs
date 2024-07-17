using VendManager.BlazorUI.Contracts;
using VendManager.BlazorUI.Services.Base;

namespace VendManager.BlazorUI.Services
{
    public class MachineService : BaseHttpService, IMachineService
    {
        public MachineService(IClient client) : base(client)
        {
        }
    }
}
