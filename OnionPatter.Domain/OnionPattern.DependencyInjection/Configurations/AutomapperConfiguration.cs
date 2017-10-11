﻿using AutoMapper;
using OnionPattern.Domain.DataTransferObjects.Game;
using OnionPattern.Domain.DataTransferObjects.Game.Input;
using OnionPattern.Domain.Entities;
using OnionPattern.Mapping.Game;

namespace OnionPattern.DependencyInjection.Configurations
{
    public static class AutomapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(configs =>
            {
                configs.CreateMap<Game, GameResponseDto>().ConvertUsing<GameToGameResponseDtoTypeConverter>();
                configs.CreateMap<CreateGameInputDto, Game>().ConvertUsing<CreateGameDtoToGameTypeConverter>();
            });
            Mapper.AssertConfigurationIsValid();
        }
    }
}
