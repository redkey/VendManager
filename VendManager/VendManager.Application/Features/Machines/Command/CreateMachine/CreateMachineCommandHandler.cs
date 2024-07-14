using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendManager.Application.Persistence;

namespace VendManager.Application.Features.Machines.Command.CreateMachine
{
    public class CreateMachineCommandHandler : IRequestHandler<CreateMachineCommand, int>
    {
        private protected IMapper _mapper;
        private protected IMachinesRepository _machinesRepository;
        public CreateMachineCommandHandler(IMachinesRepository machinesRepository, IMapper mapper)
        {
            _machinesRepository = machinesRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateMachineCommand request, CancellationToken cancellationToken)
        {
            //Validate Incoming Data

            //Convert from DTO to Entity
            var machine = _mapper.Map<Domain.Machines>(request);

            //Save to Database
            await _machinesRepository.AddAsync(machine);

            //Return
            return machine.ID;
        }
    }
}
