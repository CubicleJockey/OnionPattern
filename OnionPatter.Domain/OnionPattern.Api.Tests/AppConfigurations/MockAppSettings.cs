using System.Collections.Generic;

namespace OnionPattern.Api.Tests.AppConfigurations
{
    public static class MockAppSettings
    {
        public static IDictionary<string, string> DevConfiguration => GetDevConfiguration();

        public static class ConnectionStringsKeys
        {
            public static string LogLocationsLocal => "LogLocations:Local";
        }
        private static IDictionary<string, string> GetDevConfiguration()
        {
            return new Dictionary<string, string>
            {
                { ConnectionStringsKeys.LogLocationsLocal, "logs/ler-dtapi.log" }
            };
        }
    }
}
