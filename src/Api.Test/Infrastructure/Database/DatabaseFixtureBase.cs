using NUnit.Framework;

namespace Api.Test.Infrastructure.Database
{
    [TestFixture]
    class DatabaseFixtureBase
    {
        
        
        [SetUp]
        public void Setup()
        {
            if (!DatabaseInit.DatabaseExists("BCAPIDatabase_Dev"))
                DatabaseInit.CreateDatabase("BCAPIDatabase_Dev");
        }

        [TearDown]
        public void TearDown()
        {
            
        }

    }
}
