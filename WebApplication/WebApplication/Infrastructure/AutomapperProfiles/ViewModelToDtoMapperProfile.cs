using AutoMapper;
using WebApplication.BLL.DTO;
using WebApplication.Models;

namespace WebApplication.Infrastructure.AutomapperProfiles
{
    public class ViewModelToDtoMapperProfile : Profile
    {
        public ViewModelToDtoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Pet, PetDto>();
        }
    }
}