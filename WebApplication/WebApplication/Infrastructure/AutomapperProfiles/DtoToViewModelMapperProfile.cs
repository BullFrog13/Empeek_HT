using System.Linq;
using AutoMapper;
using WebApplication.BLL.DTO;
using WebApplication.Models;

namespace WebApplication.Infrastructure.AutomapperProfiles
{
    public class DtoToViewModelMapperProfile : Profile
    {
        public DtoToViewModelMapperProfile()
        {
            CreateMap<UserDto, User>()
                .ForMember(vm => vm.PetCount, opt => opt.ResolveUsing(src => src.Pets?.Count() ?? 0));
            CreateMap<PetDto, Pet>();
        }
    }
}