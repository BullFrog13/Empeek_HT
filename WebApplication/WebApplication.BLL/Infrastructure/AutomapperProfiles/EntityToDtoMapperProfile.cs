using AutoMapper;
using WebApplication.BLL.DTO;
using WebApplication.DAL.Entities;

namespace WebApplication.BLL.Infrastructure.AutomapperProfiles
{
    public class EntityToDtoMapperProfile : Profile
    {
        public EntityToDtoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Pet, PetDto>();
        }
    }
}