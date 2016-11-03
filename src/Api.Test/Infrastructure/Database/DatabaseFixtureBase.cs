using System;
using System.Transactions;
using NUnit.Framework;

namespace Api.Test.Infrastructure.Database
{
    [TestFixture]
    public class DatabaseFixtureBase
    {
        private TransactionScope _transaction;
        
        [SetUp]
        public void Setup()
        {
            if (!DatabaseInit.DatabaseExists("BCAPIDatabase_Dev"))
                DatabaseInit.CreateDatabase("BCAPIDatabase_Dev");

            _transaction = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions {IsolationLevel = IsolationLevel.ReadUncommitted,Timeout = new TimeSpan(0,0,10)});
        }

        [TearDown]
        public void TearDown()
        {
            _transaction.Dispose();
        }

    }
}
