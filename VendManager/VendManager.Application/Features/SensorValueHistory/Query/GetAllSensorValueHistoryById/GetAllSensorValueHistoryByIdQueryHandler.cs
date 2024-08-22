using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendManager.Application.Models;
using VendManager.Application.Persistence;

namespace VendManager.Application.Features.SensorValueHistory.Query.GetAllSensorValueHistoryById
{
    public class GetAllSensorValueHistoryByIdQueryHandler : IRequestHandler<GetAllSensorValueHistoryByIdQuery, List<SensorValueHistoryDto>>
    {

        private readonly ISensorValueHistoryRepository _sensorValueHistoryRepository;
        private readonly IMapper _mapper;

        public GetAllSensorValueHistoryByIdQueryHandler(IMapper mapper, ISensorValueHistoryRepository sensorValueHistoryRepository)
        {
            _mapper = mapper;
            _sensorValueHistoryRepository = sensorValueHistoryRepository;
        }

        public async Task<List<SensorValueHistoryDto>> Handle(GetAllSensorValueHistoryByIdQuery request, CancellationToken cancellationToken)
        {
            var sensorHistory = await _sensorValueHistoryRepository.GetAllById(request.Id);
            return _mapper.Map<List<SensorValueHistoryDto>>(sensorHistory);
        }
    }
}
