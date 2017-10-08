using System.Collections.Generic;

namespace OnionPattern.Api.Tests.AppConfigurations
{
    public static class MockAppSettings
    {
        public static IDictionary<string, string> DevConfiguration => GetDevConfiguration();

        public static class ConnectionStringsKeys
        {
            public static string VideoGamesConnection => "ConnectionStrings:VideoGamesConnection";
            public static string LogLocationsLocal => "LogLocations:FileName";
        }
        private static IDictionary<string, string> GetDevConfiguration()
        {
            return new Dictionary<string, string>
            {
                { ConnectionStringsKeys.VideoGamesConnection, @"Server=(localdb)\mssqllocaldb;Database=Sentinel;Trusted_Connection=True;" },
                { ConnectionStringsKeys.LogLocationsLocal, "logs/ler-dtapi.log" }
            };
        }
    }
}
