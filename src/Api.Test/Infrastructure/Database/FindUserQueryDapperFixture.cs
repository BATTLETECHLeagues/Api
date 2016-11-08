using System.Data;
using System.Data.SqlClient;
using Api.Domain;
using Api.Infrastructure;
using Api.Test.Infrastructure.Database;
using Dapper.Contrib.Extensions;
using NUnit.Framework;

namespace Api.Test.Infrastructure
{
    [TestFixture]
    public class FindUserQueryDapperFixture : DatabaseFixtureBase
    {
        [Test]
        public void FindUser_ByUserName_FindsUser()
        {
            DapperRepository repository = new DapperRepository();

            var id = repository.Insert(new User() {UserName = "UserName"});

            FindUserQueryDapper query = new FindUserQueryDapper();

            var result = query.Execute("UserName");

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void FindUser_ByUseNAme_DoesNotFindUser()
        {
            DapperRepository repository = new DapperRepository();

            var id = repository.Insert(new User() { UserName = "UserName" });

            FindUserQueryDapper query = new FindUserQueryDapper();

            var result = query.Execute("User");

            Assert.That(result, Is.Null);


        }
    }
}
