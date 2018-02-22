using Bogus;
using OnionPattern.Domain.Game.Entities;
using OnionPattern.Domain.Platform.Entities;
using System;
using System.Linq;

namespace OnionPattern.MockData
{
    public static class Mocks
    {
        private static Faker<Game> gameFaker;
        private static Faker<Platform> platformFaker;

        static Mocks()
        {
            GenerateGameFakerProfile();
            GeneratePlatformFakerProfile();
        }

        public static IQueryable<Game> GenerateGames(int count = 10)
        {
            return gameFaker.GenerateForever()
                            .Take(count)
                            .AsQueryable();
        }

        public static IQueryable<Platform> GeneratePlatforms(int count = 10)
        {
            return platformFaker.GenerateForever()
                .Take(count)
                .AsQueryable();
        }

        #region Helper Methods

        private static void GenerateGameFakerProfile()
        {
            gameFaker = new Faker<Game>()
                .StrictMode(false)
                .Rules((faker, entity) =>
                {
                    entity.Id = faker.IndexFaker;
                    entity.Name = string.Join(' ', faker.Lorem.Words());
                    entity.Genre = faker.Lorem.Word();
                    entity.Price = faker.Finance.Amount();
                    entity.ReleaseDate = faker.Date.Between(DateTime.MinValue, DateTime.Now);
                });
        }

        private static void GeneratePlatformFakerProfile()
        {
            platformFaker = new Faker<Platform>()
                .StrictMode(false)
                .Rules((faker, entity) =>
                {
                    entity.Id = faker.IndexFaker;
                    entity.Name = faker.Lorem.Word();
                    entity.ReleaseDate = faker.Date.Between(DateTime.MinValue, DateTime.Now);
                });
        }

        #endregion Helper Methods
    }
}
