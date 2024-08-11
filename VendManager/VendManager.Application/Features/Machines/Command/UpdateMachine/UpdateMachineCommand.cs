using MediatR;

namespace VendManager.Application.Features.Machines.Command.UpdateMachine
{
    public class UpdateMachineCommand : IRequest<Unit>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }
        public bool Enabled { get; set; }
    }
}
