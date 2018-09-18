using FakeItEasy;
using FakeItEasy.Configuration;
using Microsoft.EntityFrameworkCore;

namespace OnionPattern.DataAccess.EF.Tests.Repository
{
    public abstract class BaseRepositoryTest
    {
        protected DbContext FakeDbContext;

        protected void InitializeFakes()
        {
            FakeDbContext = A.Fake<DbContext>();
        }

        protected void ClearFakes()
        {
            Fake.ClearConfiguration(FakeDbContext);
        }
    }
}
