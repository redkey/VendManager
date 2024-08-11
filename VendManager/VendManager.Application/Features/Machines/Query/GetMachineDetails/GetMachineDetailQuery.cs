using MediatR;

namespace VendManager.Application.Features.Machines.Query.GetMachineDetails
{
    public record class GetMachineDetailQuery(long id) : IRequest<MachineDetailDto>;
    
}
