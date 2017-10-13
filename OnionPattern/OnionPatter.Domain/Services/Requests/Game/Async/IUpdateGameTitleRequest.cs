﻿using System.Threading.Tasks;
using OnionPattern.Domain.DataTransferObjects.Game;
using OnionPattern.Domain.DataTransferObjects.Game.Input;

namespace OnionPattern.Domain.Services.Requests.Game.Async
{
    public interface IUpdateGameTitleRequest
    {
        Task<GameResponseDto> ExecuteAsync(UpdateGameTitleInputDto input);
    }
}