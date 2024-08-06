using AutoMapper;
using System.Reflection.PortableExecutable;
using VendManager.Application.Features.Machines.Command.UpdateMachine;
using VendManager.Application.Features.Machines.Query.GetAllMachines;
using VendManager.Application.Features.Machines.Query.GetAllMachinesWithSensorDetails;
using VendManager.Application.Features.Machines.Query.GetMachineDetails;
using VendManager.Application.Models;
using VendManager.Domain;

namespace VendManager.Application.MappingProfiles
{
    public class MachineProfile : Profile
    {
        public MachineProfile()
        {

            //CreateMap<Machines, MachineDto>();
            //CreateMap<SensorBar, SensorBarDto>();
            //CreateMap<Sensor, SensorDto>();

            CreateMap<Machines, MachineDto>()
         .ForMember(dest => dest.SensorBars, opt => opt.MapFrom(src => src.SensorBars));

            CreateMap<SensorBar, SensorBarDto>()
                .ForMember(dest => dest.Sensors, opt => opt.MapFrom(src => src.Sensors));

            CreateMap<Sensor, SensorDto>();

            CreateMap<Machines, MachineDetailDto>().ReverseMap();
            CreateMap<Machines, UpdateMachineCommand>().ReverseMap();
            CreateMap<Machines, GetAllMachinesWithSensorDetailsDto>()
            .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
            .ForMember(dest => dest.SensorBar, opt => opt.MapFrom(src => src.SensorBars));

            //// Mapping for SensorBar to SensorBarDto
            //CreateMap<SensorBar, SensorBarDto>().ReverseMap();
        }

    }
}
