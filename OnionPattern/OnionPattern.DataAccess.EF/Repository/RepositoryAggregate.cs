using System;
using Microsoft.EntityFrameworkCore;
using OnionPattern.Domain.Game.Entities;
using OnionPattern.Domain.GamePlatform.Entities;
using OnionPattern.Domain.Platform.Entities;
using OnionPattern.Domain.Repository;

namespace OnionPattern.DataAccess.EF.Repository
{
    public class RepositoryAggregate : IRepositoryAggregate
    {
        private readonly DbContext dbContext;

        public RepositoryAggregate(DbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException($"{nameof(dbContext)} cannot be null.");
        }

        private IRepository<Game> games;
        public IRepository<Game> Games => games ?? (games = new Repository<Game>(dbContext));

        private IRepository<Platform> platforms;
        public IRepository<Platform> Platforms => platforms ?? (platforms = new Repository<Platform>(dbContext));

        private IRepository<GamePlatform> gamePlatforms;
        public IRepository<GamePlatform> GamePlatforms => gamePlatforms ?? (gamePlatforms = new Repository<GamePlatform>(dbContext));
    }
}
