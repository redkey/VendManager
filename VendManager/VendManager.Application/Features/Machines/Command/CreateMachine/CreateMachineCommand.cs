using MediatR;

namespace VendManager.Application.Features.Machines.Command.CreateMachine
{
    public class CreateMachineCommand : IRequest<long>
    {
        public string Name { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public bool Enabled { get; set; } = false;
    }
}
