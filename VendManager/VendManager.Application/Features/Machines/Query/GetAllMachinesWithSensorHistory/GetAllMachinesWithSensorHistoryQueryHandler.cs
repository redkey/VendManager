using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendManager.Application.Features.Machines.Query.GetAllMachinesWithSensorDetails;
using VendManager.Application.Persistence;

namespace VendManager.Application.Features.Machines.Query.GetAllMachinesWithSensorHistory
{
    public class GetAllMachinesWithSensorHistoryQueryHandler : IRequestHandler<GetAllMachinesWithSensorHistoryQuery, List<GetAllMachinesWithSensorDetailsDto>>
    {

        private readonly IMapper _mapper;
        private readonly IMachinesRepository _machineRepository;

        public GetAllMachinesWithSensorHistoryQueryHandler(IMachinesRepository machineRepository, IMapper mapper)
        {
            _machineRepository = machineRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllMachinesWithSensorDetailsDto>> Handle(GetAllMachinesWithSensorHistoryQuery request, CancellationToken cancellationToken)
        {
            var machines = await _machineRepository.GetAllMachinesWithSensorDetails();

            var machineWithDetailsDto = _mapper.Map<List<GetAllMachinesWithSensorDetailsDto>>(machines);
            return machineWithDetailsDto;
        }
    }
}
