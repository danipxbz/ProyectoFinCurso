using AutoMapper;
using AutoMapper.EquivalencyExpression;

namespace VLTMTool.Controller2.Mapping
{
    public class AutoMapperConfiguration
    {
        public static IMapper Configure()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddCollectionMappers();
                cfg.AddProfile<DomainToViewModelMappingProfile>();
                cfg.AddProfile<ViewModelToDomainMappingProfile>();
                cfg.AddProfile<ViewModelToViewModelMappingProfile>();
            });

            return mapperConfiguration.CreateMapper();
        }
    }
}
