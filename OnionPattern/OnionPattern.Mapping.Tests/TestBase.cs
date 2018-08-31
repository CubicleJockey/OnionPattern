namespace OnionPattern.Mapping.Tests
{
    public abstract class TestBase
    {
        protected TestBase()
        {
            MappingProfileInitilizer.ConfigureMappings();
        }
    }
}
