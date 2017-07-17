using AutoMapper;
using WebApplication.BLL.DTO;
using WebApplication.DAL.Entities;

namespace WebApplication.BLL.Infrastructure.AutomapperProfiles
{
    public class DtoToEntityMapperProfile : Profile
    {
        public DtoToEntityMapperProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<PetDto, Pet>();
        }
    }
}