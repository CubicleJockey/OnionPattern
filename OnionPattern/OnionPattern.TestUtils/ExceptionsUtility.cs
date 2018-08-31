using System;

namespace OnionPattern.TestUtils
{
    public static class ExceptionsUtility
    {
        public static string ArgumentNull(string propertyName) => $"Value cannot be null.{Environment.NewLine}Parameter name: {propertyName}";
        public static string GenericMessage => "Oh noes n' stuff!";
        public static Exception BasicException => new Exception(GenericMessage);
    }
}
