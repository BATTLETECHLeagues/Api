using Api.Domain;
using NUnit.Framework;

namespace Api.Test.Domain
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
