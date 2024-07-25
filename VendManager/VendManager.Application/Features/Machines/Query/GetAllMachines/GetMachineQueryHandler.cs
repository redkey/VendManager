using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendManager.Application.Models;
using VendManager.Application.Persistence;

namespace VendManager.Application.Features.Machines.Query.GetAllMachines
{
    public class GetMachineQueryHandler : IRequestHandler<GetMachineQuery, List<MachineDto>>
    {
        private readonly IMapper _mapper;
        private readonly IMachinesRepository _machineRepository;

        public GetMachineQueryHandler(IMapper mapper, IMachinesRepository machineRepository)
        {
            _mapper = mapper;
            _machineRepository = machineRepository;
        }
        public async Task<List<MachineDto>> Handle(GetMachineQuery request, CancellationToken cancellationToken)
        {
            
                //Query the Database
                var machines = await _machineRepository.GetAllAsync();
                //Convert Entity to DTO
                var machinesDto = _mapper.Map<List<MachineDto>>(machines);

                //return DTO List
                return machinesDto;

        }
    }
}
