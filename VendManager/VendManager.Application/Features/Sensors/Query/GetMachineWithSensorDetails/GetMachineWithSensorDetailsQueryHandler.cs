using AutoMapper;
using MediatR;
using VendManager.Application.Models;
using VendManager.Application.Persistence;

namespace VendManager.Application.Features.Sensors.Query.GetMachineWithSensorDetails
{
    public class GetMachineWithSensorDetailsQueryHandler : IRequestHandler<GetMachineWithSensorDetailsQuery, List<SensorDto>>
    {

        private readonly ISensorRepository _sensorRepository;
        private readonly IMapper _mapper;

        public GetMachineWithSensorDetailsQueryHandler(ISensorRepository sensorRepository, IMapper mapper)
        {

            _sensorRepository = sensorRepository;
            _mapper = mapper;
        }
        public async Task<List<SensorDto>> Handle(GetMachineWithSensorDetailsQuery request, CancellationToken cancellationToken)
        {
           
            var machine = await _sensorRepository.GetMachineWithSensorDetails(request.Id);

            return _mapper.Map<List<SensorDto>>(machine);
        }
    }
}
