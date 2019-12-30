using AutoMapper;
using Delicate.Application.AutoMapper;

namespace Delicate.Tests.Utils
{
    public static class Mapper
    {

        public static IMapper GetMapper()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(typeof(ViewModelToDomainMappingProfile));
                cfg.AddProfile(typeof(DomainToViewModelMappingProfile));
                cfg.AddProfile(typeof(DomainToCommandMappingProfile));
                cfg.AddProfile(typeof(CommandToViewModelMappingProfile));
            });


            return mockMapper.CreateMapper();

        }
    }
}