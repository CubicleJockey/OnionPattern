using AutoMapper;
using OnionPattern.Domain.DataTransferObjects.Game;
using OnionPattern.Domain.Entities;
using OnionPattern.Mapping.Game;

namespace OnionPattern.DependencyInjection.Configurations
{
    public static class AutomapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Game, GameResponseDto>().ConvertUsing<GameToGameResponseDtoTypeConverter>();
            });
            Mapper.AssertConfigurationIsValid();
        }
    }
}
