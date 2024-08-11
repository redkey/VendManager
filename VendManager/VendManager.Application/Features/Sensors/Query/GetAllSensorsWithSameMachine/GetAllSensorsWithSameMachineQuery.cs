using MediatR;
using VendManager.Application.Models;

namespace VendManager.Application.Features.Sensors.Query.GetAllSensorsWithSameMachine
{
    public class GetAllSensorsWithSameMachineQuery : IRequest<List<MachineDto>>
    {

    }
}
