using Api.Domain;
using Api.Infrastructure;
using Api.Test.Infrastructure.Database;
using NCrunch.Framework;
using NUnit.Framework;

namespace Api.Test.Infrastructure
{
    [TestFixture]
    public class FindUserSessionQueryDapperFixture : DatabaseFixtureBase
    {
        private string _sessionKey = "UserName";
        private string _invalidSessionKey = "User";

        [Test]
        [ExclusivelyUses("Database")]
        public void FindUserSession_BySessionKey_FindsUserSession()
        {
            var repository = new DapperRepository();

            var userid = repository.Insert(new User { UserName = "UserName" });
            var id = repository.Insert(new UserSession {SessionKey = _sessionKey,UserId = userid });

            var query = new FindSessionForUserDapper();

            var result = query.Execute(_sessionKey);
            
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(id));
            Assert.That(result.SessionKey, Is.EqualTo(_sessionKey));
        }

        [Test]
        [ExclusivelyUses("Database")]
        public void FindUserSession_BySessionKey_DoesNotFindUserSession()
        {
            var repository = new DapperRepository();

            var userid = repository.Insert(new User { UserName = "UserName" });
            repository.Insert(new UserSession { SessionKey = _sessionKey, UserId = userid });
            
            var query = new FindSessionForUserDapper();

            var result = query.Execute(_invalidSessionKey);

            Assert.That(result, Is.Null);
        }
    }
}
