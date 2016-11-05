using Api.Domain;
using Api.Test.Infrastructure.Database;
using NUnit.Framework;

namespace Api.Test.Domain
{
    [TestFixture]
    public class AddUserInteractorFixture
    {
        [Test]
        public void AddUser_AddsUser_WhenNewUser()
        {
            var repository = new FakeRepository();
            var interactor = new AddUserInteractor(repository);
            interactor.Execute();

            Assert.IsInstanceOf<User>(repository.InsertedItem);
            Assert.That(((User)repository.InsertedItem).UserName,Is.EqualTo("UserName"));
            Assert.That(((User)repository.InsertedItem).Id, Is.EqualTo(0));
        }

        [Test]
        [Ignore("TODO")]
        public void AddUser_DoesNotAddUser_WhenUserExists40()
        {

        }

    }
}
