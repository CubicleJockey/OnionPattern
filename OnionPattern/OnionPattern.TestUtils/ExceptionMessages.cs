using System;

namespace OnionPattern.TestUtils
{
    public static class ExceptionMessages
    {
        public static string ArgumentNull(string propertyName) => $"Value cannot be null.{Environment.NewLine}Parameter name: {propertyName}";
        public static string GenericMessage => "Oh noes n' stuff!";
    }
}
