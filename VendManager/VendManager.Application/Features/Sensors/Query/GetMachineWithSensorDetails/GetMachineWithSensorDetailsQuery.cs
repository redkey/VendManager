using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendManager.Application.Models;

namespace VendManager.Application.Features.Sensors.Query.GetMachineWithSensorDetails
{
    public class GetMachineWithSensorDetailsQuery : IRequest<List<SensorDto>>
    {
        public long Id { get; set; }
    }
}
