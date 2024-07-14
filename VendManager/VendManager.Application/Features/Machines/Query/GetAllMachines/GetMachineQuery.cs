using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendManager.Application.Features.Machines.Query.GetAllMachines
{
    public record GetMachineQuery : IRequest<List<MachineDto>>;
    
}
