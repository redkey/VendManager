using AutoMapper;
using MediatR;
using VendManager.Application.Exceptions;
using VendManager.Application.Persistence;

namespace VendManager.Application.Features.Machines.Command.UpdateMachine
{
    public class UpdateMachineCommandHandler : IRequestHandler<UpdateMachineCommand, Unit>
    {

        private readonly IMapper _mapper;
        private readonly IMachinesRepository _machineRepository;

        public UpdateMachineCommandHandler(IMapper mapper, IMachinesRepository machineRepository)
        {
            _mapper = mapper;
            _machineRepository = machineRepository;
        }

        public async Task<Unit> Handle(UpdateMachineCommand request, CancellationToken cancellationToken)
        {
            //Validate Incoming Data
            var validator = new UpdateMachineValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new BadRequestException("Invalid Machine", validationResult);

            //Convert to Domain Entities
            var machine = _mapper.Map<Domain.Machines>(request);

            //Save to Database
            await _machineRepository.UpdateAsync(machine);

            //Return
            return Unit.Value;
        }
    }
    
}
