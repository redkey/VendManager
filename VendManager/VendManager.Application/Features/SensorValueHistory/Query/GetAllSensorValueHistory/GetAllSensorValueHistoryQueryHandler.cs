using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendManager.Application.Models;
using VendManager.Application.Persistence;

namespace VendManager.Application.Features.SensorValueHistory.Query.GetAllSensorValueHistory
{
    public class GetAllSensorValueHistoryQueryHandler : IRequestHandler<GetAllSensorValueHistoryQuery, List<SensorValueHistoryDto>>
    {

        private readonly ISensorValueHistoryRepository _sensorValueHistoryRepository; 
        private readonly IMapper _mapper;

        public GetAllSensorValueHistoryQueryHandler(IMapper mapper, ISensorValueHistoryRepository sensorValueHistoryRepository)
        {
            _mapper = mapper;
            _sensorValueHistoryRepository = sensorValueHistoryRepository;
        }

        public async Task<List<SensorValueHistoryDto>> Handle(GetAllSensorValueHistoryQuery request, CancellationToken cancellationToken)
        {
            var sensorHistory = await _sensorValueHistoryRepository.GetAllAsync();

            return _mapper.Map<List<SensorValueHistoryDto>>(sensorHistory);
        }
    }
}
