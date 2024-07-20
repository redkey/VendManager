using AutoMapper;
using Blazored.LocalStorage;
using DevExpress.PivotGrid.Criteria;
using VendManager.BlazorUI.Contracts;
using VendManager.BlazorUI.Models;
using VendManager.BlazorUI.Services.Base;

namespace VendManager.BlazorUI.Services
{
    public class MachineService : BaseHttpService, IMachineService
    {
        
        private readonly IMapper _mapper;
        public MachineService(IClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
        {

            _mapper = mapper;
        }

        public Task<Response<Guid>> CreateMachine(MachineVM machine)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Guid>> DeleteMachine(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MachineVM>> GetAllMachinesWithSensorDetails()
        {
            await AddBearerToken();
            var machines = await _client.GetAllMachinesWithSensorDetailsAsync();
            return _mapper.Map<List<MachineVM>>(machines);
        }

        public Task<Response<MachineVM>> GetMachine(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MachineVM>> GetMachines()
        {
            await AddBearerToken();
            var machines = await _client.MachineAllAsync();
            return _mapper.Map<List<MachineVM>>(machines);

        }

        public Task<Response<Guid>> UpdateMachine(long id, MachineVM machine)
        {
            throw new NotImplementedException();
        }
    }
}
    