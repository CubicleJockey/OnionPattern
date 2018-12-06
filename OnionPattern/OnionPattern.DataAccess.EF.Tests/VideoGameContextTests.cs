using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OnionPattern.DataAccess.EF.Tests
{
    public class VideoGameContextTests
    {
        [TestClass]
        public class ConstructorTests
        {
            private DbContextOptions<VideoGameContext> dbContextOptions;
            private readonly VideoGameContext context;

            public ConstructorTests()
            {
                dbContextOptions = new DbContextOptions<VideoGameContext>();
                context = new VideoGameContext(dbContextOptions);
            }

            [TestMethod]
            public void InheritsFromDbContext()
            {
                context.Should().BeAssignableTo<DbContext>();
            }

            [TestMethod]
            public void InheritsFromIVideoGameContext()
            {
                context.Should().BeAssignableTo<IVideoGameContext>();
            }
        }
    }
}
