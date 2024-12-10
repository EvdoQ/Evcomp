using AutoMapper;
using Evcomp.API.Models;
using Evcomp.API.Models.Dto;

namespace Evcomp.API.Configurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ComputerCreateDTO, ComputerEntity>();
            CreateMap<ComputerUpdateDTO, ComputerEntity>();
        }
    }
}
