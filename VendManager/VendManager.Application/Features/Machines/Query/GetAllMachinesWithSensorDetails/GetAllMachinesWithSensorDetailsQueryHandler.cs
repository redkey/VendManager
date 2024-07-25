using AutoMapper;
using MediatR;
using VendManager.Application.Persistence;

namespace VendManager.Application.Features.Machines.Query.GetAllMachinesWithSensorDetails
{
    public class GetAllMachinesWithSensorDetailsQueryHandler : IRequestHandler<GetAllMachinesWithSensorDetailsQuery, List<GetAllMachinesWithSensorDetailsDto>>
    {
        private readonly IMapper _mapper;
        private readonly IMachinesRepository _machineRepository;

        public GetAllMachinesWithSensorDetailsQueryHandler(IMachinesRepository machineRepository, IMapper mapper)
        {
            _machineRepository = machineRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllMachinesWithSensorDetailsDto>> Handle(GetAllMachinesWithSensorDetailsQuery request, CancellationToken cancellationToken)
        {
             var machines = await _machineRepository.GetAllMachinesWithSensorBarDetails();

             var machineWithDetailsDto =  _mapper.Map<List<GetAllMachinesWithSensorDetailsDto>>(machines); 
            return machineWithDetailsDto;
        }
    }
}
