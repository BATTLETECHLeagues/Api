using Api.Domain;
using Api.Infrastructure;
using Api.Test.Infrastructure.Database;
using NUnit.Framework;

namespace Api.Test.Infrastructure
{
    [TestFixture]
    public class DapperRepositoryFixture : DatabaseFixtureBase
    {
        [Test]
        public void Test()
        {
            var dapperRepository = new DapperRepository();

            var id = dapperRepository.Insert(new User {UserName = "Name"});
            
        }
    }
}
