using AutoMapper;
using MediatR;
using VendManager.Application.Models;
using VendManager.Application.Persistence;

namespace VendManager.Application.Features.Sensors.Query.GetAllSensorsWithSameMachine
{
    public class GetAllSensorsWithSameMachineQueryHandler : IRequestHandler<GetAllSensorsWithSameMachineQuery, List<MachineDto>>
    {


        private readonly ISensorRepository _sensorRepository;
        private readonly IMapper _mapper;

        public GetAllSensorsWithSameMachineQueryHandler(ISensorRepository sensorRepository, IMapper mapper)
        {

            _sensorRepository = sensorRepository;
            _mapper = mapper;
        }

        public async Task<List<MachineDto>> Handle(GetAllSensorsWithSameMachineQuery request, CancellationToken cancellationToken)
        {
            var sensor = await _sensorRepository.GetAllMachinesWithSensorDetails();

            return _mapper.Map<List<MachineDto>>(sensor);



        }
    }
}
