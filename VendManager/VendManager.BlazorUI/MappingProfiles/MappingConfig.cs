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
        }
    }
}
