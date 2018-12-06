using Microsoft.EntityFrameworkCore;
using OnionPattern.Domain.Game.Entities;
using OnionPattern.Domain.GamePlatform.Entities;
using OnionPattern.Domain.Platform.Entities;
using OnionPattern.Domain.Repository;
using System;

namespace OnionPattern.DataAccess.EF.Repository
{
    public class RepositoryAsyncAggregate : IRepositoryAsyncAggregate
    {
        private readonly DbContext dbContext;

        public RepositoryAsyncAggregate(DbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        private IRepositoryAsync<Game> games;
        public IRepositoryAsync<Game> Games => games ?? (games = new RepositoryAsync<Game>(dbContext));

        private IRepositoryAsync<Platform> platforms;
        public IRepositoryAsync<Platform> Platforms => platforms ?? (platforms = new RepositoryAsync<Platform>(dbContext));

        private IRepositoryAsync<GamePlatform> gamePlatforms;
        public IRepositoryAsync<GamePlatform> GamePlatforms => gamePlatforms ?? (gamePlatforms = new RepositoryAsync<GamePlatform>(dbContext));
    }
}
