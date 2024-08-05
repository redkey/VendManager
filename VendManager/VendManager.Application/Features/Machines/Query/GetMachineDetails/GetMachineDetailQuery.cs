using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendManager.Application.Features.Machines.Query.GetMachineDetails
{
    public record class GetMachineDetailQuery(long id) : IRequest<MachineDetailDto>;
    
}
