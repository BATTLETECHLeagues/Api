using NUnit.Framework;

namespace Api.Test.Infrastructure.Database
{
    
    [TestFixture]
    public class CreateDatabaseFixture
    {
        //[Test]
        [Category(UnitTestCategories.Explicit)]
        public void CreateTestDatabase()
        {
            if (!DatabaseInit.DatabaseExists(@"'Test2'"))
                DatabaseInit.CreateDatabase(@"Test2");

            Assert.That(DatabaseInit.DatabaseExists(@"'Test2'"));
            DatabaseInit.DeleteDatabase(@"'Test2'");
            
        }
    }
}
