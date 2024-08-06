using AutoMapper;
using VendManager.BlazorUI.Models;
using VendManager.BlazorUI.Services.Base;

namespace VendManager.BlazorUI.MappingProfiles
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<MachineDto, MachineVM>().ReverseMap();
            CreateMap<MachineDetailDto, UpdateMachineCommand>().ReverseMap();

            //  CreateMap<GetAllMachinesWithSensorDetailsDto, MachineVM>()
            //.ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.Id))
            //.ForMember(dest => dest.SensorBars, opt => opt.MapFrom(src => src.SensorBar));

            //  // Mapping for SensorBarDto to SensorBarViewModel
            //  // Mapping for SensorBarDto to SensorBarViewModel
            //  CreateMap<SensorBarDto, SensorBarViewModel>()
            //      .ForMember(dest => dest.LastCommunicationDateTimeUTC,
            //                 opt => opt.MapFrom(src => src.LastCommunicationDateTimeUTC.HasValue ? src.LastCommunicationDateTimeUTC.Value.DateTime : (DateTime?)null))
            //      .ReverseMap();

            CreateMap<GetAllMachinesWithSensorDetailsDto, MachineVM>()
           .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
           .ForMember(dest => dest.SerialNumber, opt => opt.MapFrom(src => src.SerialNumber))
           .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
           .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes))
           .ForMember(dest => dest.Enabled, opt => opt.MapFrom(src => src.Enabled))
           .ForMember(dest => dest.LastCommunicationDateTimeUTC, opt => opt.MapFrom(src =>
               src.SensorBar.Any(sb => sb.LastCommunicationDateTimeUTC.HasValue)
               ? src.SensorBar.Max(sb => sb.LastCommunicationDateTimeUTC.Value.DateTime)
               : (DateTime?)null
           ));
        }
    }
}
