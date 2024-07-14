using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


            //Convert to Domain Entities
            var machine = _mapper.Map<Domain.Machines>(request);

            //Save to Database
            await _machineRepository.UpdateAsync(machine);

            //Return
            return Unit.Value;
        }
    }
    
}
