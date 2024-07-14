using AutoMapper;
using MediatR;
using VendManager.Application.Exceptions;
using VendManager.Application.Persistence;

namespace VendManager.Application.Features.Machines.Query.GetMachineDetails
{
    public class GetMachineDetailQueryHandler : IRequestHandler<GetMachineDetailQuery, MachineDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IMachinesRepository _machinesRepository;
        public GetMachineDetailQueryHandler(IMachinesRepository machinesRepository, IMapper mapper)
        {
            _machinesRepository = machinesRepository;
            _mapper = mapper;
        }
        public async Task<MachineDetailDto> Handle(GetMachineDetailQuery request, CancellationToken cancellationToken)
        {
            //Query the database
            var machineDetails = await _machinesRepository.GetByIdAsync(request.id);


            //Verify if the machine exists
            if (machineDetails == null)
            {
                throw new NotFoundException(nameof(Machines), request.id);
            }

            //Map to Dto
            var machineDetailDto = _mapper.Map<MachineDetailDto>(machineDetails);

            //Return
            return machineDetailDto;

        }
    }
}
