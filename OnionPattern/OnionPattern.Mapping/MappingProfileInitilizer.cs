using AutoMapper;

namespace OnionPattern.Mapping
{
    public static class MappingProfileInitilizer
    {
        public static void ConfigureMappings()
        {
            Mapper.Initialize(configuration => {
                configuration.AddProfile<GameMappingProfile>();
                configuration.AddProfile<PlatformMappingProfile>();
            });
            Mapper.AssertConfigurationIsValid();
        }
    }
}
