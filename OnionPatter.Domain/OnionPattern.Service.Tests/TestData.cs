using System;
using System.Collections.Generic;
using OnionPattern.Domain.Entities;

namespace OnionPattern.Service.Tests
{
    public static class TestData
    {
        public static IEnumerable<Platform> GetPlatforms()
        {
            IList<Platform> games = new List<Platform>();

            var nintendo = new Platform
            {
                Id = 1,
                Name = "Nintendo",
                ReleaseDate = new DateTime(1983, 07, 15)
            };
            games.Add(nintendo);


            var superNintendo = new Platform
            {
                Id = 2,
                Name = "Super Nintendo",
                ReleaseDate = new DateTime(1990, 11, 21)
            };
            games.Add(superNintendo);

            var nintendo64 = new Platform
            {
                Id = 3,
                Name = "Nintendo 64",
                ReleaseDate = new DateTime(1996, 06, 23)
            };
            games.Add(nintendo64);

            var nintendoWii = new Platform
            {
                Id = 4,
                Name = "Nintendo Wii",
                ReleaseDate = new DateTime(2006, 11, 19)
            };
            games.Add(nintendoWii);

            var nintendoWiiU = new Platform
            {
                Id = 5,
                Name = "Nintendo Wii U",
                ReleaseDate = new DateTime(2012, 11, 18)
            };
            games.Add(nintendoWiiU);


            var nintendoSwitch = new Platform
            {
                Id = 6,
                Name = "Nintendo Switch",
                ReleaseDate = new DateTime(2017, 03, 03)
            };
            games.Add(nintendoSwitch);

            return games;
        }

        public static IEnumerable<Game> GetGames()
        {
            IList<Game> games = new List<Game>();

            return games;
        }
    }
}
