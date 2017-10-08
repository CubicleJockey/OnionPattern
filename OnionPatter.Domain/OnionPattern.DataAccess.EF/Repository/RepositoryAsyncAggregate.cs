using System;
using Microsoft.EntityFrameworkCore;
using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Repository;

namespace OnionPattern.DataAccess.EF.Repository
{
    public class RepositoryAsyncAggregate
    {
        private readonly DbContext dbContext;

        public RepositoryAsyncAggregate(DbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException($"{nameof(dbContext)} cannot be null.");
        }

        private IRepositoryAsync<Game> games;
        public IRepositoryAsync<Game> Games => games ?? (games = new RepositoryAsync<Game>(dbContext));

        private IRepositoryAsync<Platform> platforms;
        public IRepositoryAsync<Platform> Platforms => platforms ?? (platforms = new RepositoryAsync<Platform>(dbContext));

        private IRepositoryAsync<GamePlatform> gamePlatforms;
        public IRepositoryAsync<GamePlatform> GamePlatforms => gamePlatforms ?? (gamePlatforms = new RepositoryAsync<GamePlatform>(dbContext));
    }
}
