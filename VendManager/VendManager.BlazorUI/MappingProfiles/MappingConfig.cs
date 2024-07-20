using AutoMapper;
using VendManager.BlazorUI.Models;
using VendManager.BlazorUI.Services.Base;

namespace VendManager.BlazorUI.MappingProfiles
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<MachineDto , MachineVM>().ReverseMap();

            CreateMap<GetAllMachinesWithSensorDetailsDto, MachineVM>()
          .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.Id))
          .ForMember(dest => dest.SensorBars, opt => opt.MapFrom(src => src.SensorBar));

            // Mapping for SensorBarDto to SensorBarViewModel
            // Mapping for SensorBarDto to SensorBarViewModel
            CreateMap<SensorBarDto, SensorBarViewModel>()
                .ForMember(dest => dest.LastCommunicationDateTimeUTC,
                           opt => opt.MapFrom(src => src.LastCommunicationDateTimeUTC.HasValue ? src.LastCommunicationDateTimeUTC.Value.DateTime : (DateTime?)null))
                .ReverseMap();
        }
    }
}
