using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendManager.Application.Features.Machines.Query.GetAllMachinesWithSensorDetails;

namespace VendManager.Application.Features.Machines.Query.GetAllMachinesWithSensorHistory
{
    public class GetAllMachinesWithSensorHistoryQuery : IRequest<List<GetAllMachinesWithSensorDetailsDto>>
    {

    }
}
