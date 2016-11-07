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
            FindUserQuery fnq = FakeFindUserQuery.NoUserFound();
            var interactor = GetAddUserInteractor(repository, fnq);
            interactor.Execute("UserName");

            Assert.IsInstanceOf<User>(repository.InsertedItem);
            Assert.That(((User)repository.InsertedItem).UserName,Is.EqualTo("UserName"));
            Assert.That(((User)repository.InsertedItem).Id, Is.EqualTo(1));
        }

        [Test]
        public void AddUser_DoesNotAddUser_WhenUserExists()
        {
            var repository = new FakeRepository();
            FindUserQuery fnq = FakeFindUserQuery.UserFound(new User {UserName = "UserToFind",Id = 1});

            var interactor = GetAddUserInteractor(repository, fnq);
            interactor.Execute("UserName");

            Assert.That(repository.InsertedItem, Is.Null);
        }

        private static AddUserInteractor GetAddUserInteractor(FakeRepository repository, FindUserQuery findUserQuery)
        {
            var interactor = new AddUserInteractor(repository,findUserQuery);
            return interactor;
        }


    }

    public class FakeFindUserQuery : FindUserQuery
    {
        private FakeFindUserQuery()
        {
            
        }

        private User UserToReturn { get; set; }

        public static FakeFindUserQuery NoUserFound()
        {
            return new FakeFindUserQuery();
        }

        public static FakeFindUserQuery UserFound(User userToReturn)
        {
            return new FakeFindUserQuery {UserToReturn = userToReturn};
        }


        public User Execute(string userName)
        {
            return UserToReturn;
        }
    }
}
