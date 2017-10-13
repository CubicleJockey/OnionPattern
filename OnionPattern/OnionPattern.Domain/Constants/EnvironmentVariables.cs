using System;

namespace OnionPattern.Domain.Constants
{
    public static class EnvironmentVariables
    {
        public static string InMemoryDb => nameof(InMemoryDb);
        public static string ASPNETCORE_ENVIRONMENT => nameof(ASPNETCORE_ENVIRONMENT);

        public static bool GetInMemoryDbValue()
        {
            var inMemoryDbEnvironmentVar = Environment.GetEnvironmentVariable(InMemoryDb);
            var inMemoryDb = string.Equals(bool.TrueString, inMemoryDbEnvironmentVar, StringComparison.CurrentCultureIgnoreCase);
            return inMemoryDb;
        }
    }
}
