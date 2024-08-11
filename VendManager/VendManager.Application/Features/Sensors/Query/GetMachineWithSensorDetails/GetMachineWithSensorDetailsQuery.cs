using MediatR;
using VendManager.Application.Models;

namespace VendManager.Application.Features.Sensors.Query.GetMachineWithSensorDetails
{
    public class GetMachineWithSensorDetailsQuery : IRequest<List<SensorDto>>
    {
        public long Id { get; set; }
    }
}
