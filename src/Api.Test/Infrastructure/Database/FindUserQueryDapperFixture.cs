using Api.Domain;
using Api.Infrastructure;
using Api.Test.Infrastructure.Database;
using NCrunch.Framework;
using NUnit.Framework;

namespace Api.Test.Infrastructure
{
    [TestFixture]
    public class FindUserQueryDapperFixture : DatabaseFixtureBase
    {
        private string _validUserName = "UserName";
        private string _invalidUserName = "User";

        [Test]
        [ExclusivelyUses("Database")]
        public void FindUser_ByUserName_FindsUser()
        {
            var repository = new DapperRepository();

            var id = repository.Insert(new User {UserName = _validUserName});

            var query = new FindUserQueryDapper();

            var result = query.Execute(_validUserName);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(id));
            Assert.That(result.UserName, Is.EqualTo(_validUserName));
        }

        [Test]
        [ExclusivelyUses("Database")]
        public void FindUser_ByUseNAme_DoesNotFindUser()
        {
            var repository = new DapperRepository();

            repository.Insert(new User { UserName = _validUserName });

            var query = new FindUserQueryDapper();

            var result = query.Execute(_invalidUserName);

            Assert.That(result, Is.Null);
        }
    }
}
