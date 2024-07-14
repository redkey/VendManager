using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendManager.Application.Persistence;

namespace VendManager.Application.Features.Machines.Query.GetAllMachines
{
    public class GetMachineQueryHandler : IRequestHandler<GetMachineQuery, List<MachineDto>>
    {
        private readonly IMapper _mapper;
        private readonly IMachineGroupRepository _machineGroupRepository;

        public GetMachineQueryHandler(IMapper mapper, IMachineGroupRepository machineGroupRepository)
        {
            _mapper = mapper;
            _machineGroupRepository = machineGroupRepository;
        }
        public async Task<List<MachineDto>> Handle(GetMachineQuery request, CancellationToken cancellationToken)
        {
            //Query the Database
            var machines = await _machineGroupRepository.GetAllAsync();

            //Convert Entity to DTO
            var machinesDto = _mapper.Map<List<MachineDto>>(machines);

            //return DTO List
            return machinesDto;

        }
    }
}
