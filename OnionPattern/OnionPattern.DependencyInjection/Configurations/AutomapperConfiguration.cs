using AutoMapper;
using OnionPattern.Domain.DataTransferObjects.Game;
using OnionPattern.Domain.DataTransferObjects.Game.Input;
using OnionPattern.Domain.DataTransferObjects.Platform;
using OnionPattern.Domain.DataTransferObjects.Platform.Input;
using OnionPattern.Domain.Entities;
using OnionPattern.Mapping.Game;
using OnionPattern.Mapping.Platform;

namespace OnionPattern.DependencyInjection.Configurations
{
    public static class AutomapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(configs =>
            {
                ConfigureGameMappings(configs);
                ConfigurePlatformMappings(configs);
            });
            Mapper.AssertConfigurationIsValid();
        }

        private static void ConfigureGameMappings(IProfileExpression configs)
        {
            configs.CreateMap<Game, GameResponseDto>().ConvertUsing<GameToGameResponseDtoTypeConverter>();
            configs.CreateMap<CreateGameInputDto, Game>().ConvertUsing<CreateGameDtoToGameTypeConverter>();
        }

        private static void ConfigurePlatformMappings(IProfileExpression configs)
        {
            configs.CreateMap<Platform, PlatformResponseDto>().ConvertUsing<PlatformToPlatformResponseDtoTypeConverter>();
            configs.CreateMap<CreatePlatformInputDto, Platform>().ConvertUsing<CreatePlatformInputDtoToPlatformTypeConverter>();
        }
    }
}
