using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendManager.Application.Models;

namespace VendManager.Application.Features.SensorValueHistory.Query.GetAllSensorValueHistory
{
    public record GetAllSensorValueHistoryQuery : IRequest<List<SensorValueHistoryDto>>;
    
}
