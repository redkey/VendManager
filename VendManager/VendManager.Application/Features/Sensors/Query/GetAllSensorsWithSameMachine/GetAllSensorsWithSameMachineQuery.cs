using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendManager.Application.Models;
using VendManager.Domain;

namespace VendManager.Application.Features.Sensors.Query.GetAllSensorsWithSameMachine
{
    public class GetAllSensorsWithSameMachineQuery : IRequest<List<MachineDto>>
    {

    }
}
