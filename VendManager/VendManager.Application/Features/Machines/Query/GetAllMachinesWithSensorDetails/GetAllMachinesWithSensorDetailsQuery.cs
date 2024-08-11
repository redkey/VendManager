using MediatR;

namespace VendManager.Application.Features.Machines.Query.GetAllMachinesWithSensorDetails
{
    public class GetAllMachinesWithSensorDetailsQuery : IRequest<List<GetAllMachinesWithSensorDetailsDto>>
    {
    }
}
