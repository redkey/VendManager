using AutoMapper;
using VendManager.Application.Features.Machines.Query.GetAllMachines;
using VendManager.Domain;

namespace VendManager.Application.MappingProfiles
{
    public class MachineProfile : Profile
    {
        public MachineProfile()
        {
            CreateMap<Machines, MachineDto>().ReverseMap();
        }

    }
}
