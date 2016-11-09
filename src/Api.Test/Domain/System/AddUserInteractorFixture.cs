using Api.Domain;
using NUnit.Framework;

namespace Api.Test.Domain
{
    [TestFixture]
    public class AddUserInteractorFixture
    {
        [Test]
        public void AddUser_AddsUser_WhenNewUser()
        {
            var repository = new RepositoryFake();
            FindUserQuery fnq = FakeFindUserFake.NoUserFound();
            var interactor = GetAddUserInteractor(repository, fnq);
            interactor.Execute("UserName");

            Assert.IsInstanceOf<User>(repository.InsertedItem);
            Assert.That(((User)repository.InsertedItem).UserName,Is.EqualTo("UserName"));
            Assert.That(((User)repository.InsertedItem).Id, Is.EqualTo(1));
        }

        [Test]
        public void AddUser_DoesNotAddUser_WhenUserExists()
        {
            var repository = new RepositoryFake();
            FindUserQuery fnq = FakeFindUserFake.UserFound(new User {UserName = "UserToFind",Id = 1});

            var interactor = GetAddUserInteractor(repository, fnq);
            interactor.Execute("UserName");

            Assert.That(repository.InsertedItem, Is.Null);
        }

        private static AddUserInteractor GetAddUserInteractor(RepositoryFake repository, FindUserQuery findUserQuery)
        {
            var interactor = new AddUserInteractor(repository,findUserQuery);
            return interactor;
        }


    }

    public class FakeFindUserFake : FindUserQuery
    {
        private FakeFindUserFake()
        {
            
        }

        private User UserToReturn { get; set; }

        public static FakeFindUserFake NoUserFound()
        {
            return new FakeFindUserFake();
        }

        public static FakeFindUserFake UserFound(User userToReturn)
        {
            return new FakeFindUserFake {UserToReturn = userToReturn};
        }


        public User Execute(string userName)
        {
            return UserToReturn;
        }
    }
}
