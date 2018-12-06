using System.Collections.Generic;

namespace OnionPattern.Domain.Tests.Configurations
{
    public static class MockAppSettings
    {
        public static IDictionary<string, string> DevConfiguration => GetDevConfiguration();

        public static class ConfigurationKeys
        {
            public static string VideoGamesConnection => "ConnectionStrings:VideoGamesConnection";
            public static string LogLocationsLocal => "LogLocations:FileName";
        }
        private static IDictionary<string, string> GetDevConfiguration()
        {
            return new Dictionary<string, string>
            {
                { ConfigurationKeys.VideoGamesConnection, @"Server=(localdb)\mssqllocaldb;Database=Sentinel;Trusted_Connection=True;" },
                { ConfigurationKeys.LogLocationsLocal, "logs/ler-dtapi.log" }
            };
        }
    }
}
