using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendManager.Application.Models;

namespace VendManager.Application.Features.SensorValueHistory.Query.GetAllSensorValueHistoryById
{
    public record GetAllSensorValueHistoryByIdQuery(long Id) : IRequest<List<SensorValueHistoryDto>>;
    
}
