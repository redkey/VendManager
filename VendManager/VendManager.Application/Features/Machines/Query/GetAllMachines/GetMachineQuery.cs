using MediatR;

namespace VendManager.Application.Features.Machines.Query.GetAllMachines
{
    public record GetMachineQuery : IRequest<List<MachineDto>>;
    
}
