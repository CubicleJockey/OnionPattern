namespace OnionPattern.Domain.Tests
{
    public abstract class TestBase<TEntity> where TEntity : class, new()
    {
        protected TEntity Entity { get; set; }

        protected TestBase()
        {
            Entity = new TEntity();
        }
    }
}
