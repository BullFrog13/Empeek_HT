using AutoMapper;
using WebApplication.BLL.Infrastructure.AutomapperProfiles;
using WebApplication.Infrastructure.AutomapperProfiles;

namespace WebApplication.Infrastructure
{
    public class AutomapperConfiguration
    {
        public MapperConfiguration Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ViewModelToDtoMapperProfile());
                cfg.AddProfile(new DtoToViewModelMapperProfile());

                cfg.AddProfile(new DtoToEntityMapperProfile());
                cfg.AddProfile(new EntityToDtoMapperProfile());
            });

            return config;
        }
    }
}