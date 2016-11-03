using System;
using System.Data.SqlClient;
using Api.Domain.User;
using Api.Infrastructure.Database;
using NUnit.Framework;

namespace Api.Test.Infrastructure.Database
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
