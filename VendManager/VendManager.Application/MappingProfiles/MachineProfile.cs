using AutoMapper;
using VendManager.Application.Features.Machines.Query.GetAllMachines;
using VendManager.Application.Features.Machines.Query.GetAllMachinesWithSensorDetails;
using VendManager.Domain;

namespace VendManager.Application.MappingProfiles
{
    public class MachineProfile : Profile
    {
        public MachineProfile()
        {
            CreateMap<Machines, MachineDto>().ReverseMap();
            CreateMap<Machines, GetAllMachinesWithSensorDetailsDto>()
            .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
            .ForMember(dest => dest.SensorBar, opt => opt.MapFrom(src => src.SensorBars));

            // Mapping for SensorBar to SensorBarDto
            CreateMap<SensorBar, SensorBarDto>().ReverseMap();
        }

    }
}
