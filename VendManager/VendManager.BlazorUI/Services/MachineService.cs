using AutoMapper;
using Blazored.LocalStorage;
using DevExpress.PivotGrid.Criteria;
using VendManager.BlazorUI.Contracts;
using VendManager.BlazorUI.Models;
using VendManager.BlazorUI.Services.Base;
using VendManager.BlazorUI.Services.HttpContext;

namespace VendManager.BlazorUI.Services
{
    public class MachineService : BaseHttpService, IMachineService
    {
        
        private readonly IMapper _mapper;
        public MachineService(IClient client, IMapper mapper, TokenPersistenceService tokenService)
          : base(client, tokenService)
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
            var machinesVM = _mapper.Map<List<MachineVM>>(machines);
            return machinesVM;
        }

        public async Task<MachineDetailDto> GetMachine(long id)
        {
           await AddBearerToken();
           var machine = await _client.GetMachineDetailsAsync(id);
            return machine;
           // throw new NotImplementedException();
        }

        public async Task<List<SensorDto>> GetMachineChuteDetails(long machineId)
        {
            await AddBearerToken();
           // var sensors = await _client.SensorAll2Async(machineId);
            var sensors = await _client.Sensor2Async(machineId);
            return sensors.ToList();
        }

        public async Task<List<MachineVM>> GetMachines()
        {
           // await AddBearerToken();
         //   var machines = await _client.MachineAllAsync();
            var machines = await _client.MachineAsync();
            return _mapper.Map<List<MachineVM>>(machines);

        }

        public Task<Response<Guid>> UpdateMachine(long id, MachineVM machine)
        {
            throw new NotImplementedException();
        }
    }
}
    