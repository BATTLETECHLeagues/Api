using Api.Domain;
using Api.Domain.User;
using Api.Infrastructure.Database;
using NUnit.Framework;

namespace Api.Test.Domain.User
{
    public class FakeRepository : IRepository
    {
        public object InsertedItem { get; set; }
        public void Insert<T>(T item)
        {
            InsertedItem = item;
        }

        public void Remove<T>(T item)
        {
            throw new global::System.NotImplementedException();
        }

        public void Update<T>(T item)
        {
            throw new global::System.NotImplementedException();
        }

        public T FindById<T>(int id)
        {
            throw new global::System.NotImplementedException();
        }
    }

    [TestFixture]
    public class AddUserInteractorFixture
    {
        [Test]
        public void AddUser_AddsUser_WhenNewUser()
        {
            var repository = new FakeRepository();
            var interactor = new AddUserInteractor(repository);
            interactor.Execute();

            Assert.IsInstanceOf<Api.Domain.User.User>(repository.InsertedItem);
            Assert.That(((Api.Domain.User.User)repository.InsertedItem).UserName,Is.EqualTo("UserName"));
            Assert.That(((Api.Domain.User.User)repository.InsertedItem).Id, Is.EqualTo(0));
        }

        [Test]
        [Ignore("TODO")]
        public void AddUser_DoesNotAddUser_WhenUserExists40()
        {

        }

    }
}
