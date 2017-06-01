using System.Text.RegularExpressions;
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
            var result = interactor.Execute("UserName");

            Assert.That(result.OperationSuccess, Is.True);
            Assert.That(result.OperationSuccess, Is.True);
            Assert.That(result.SessionKey, Is.EqualTo(((UserSession)repository.InsertedItem[1]).SessionKey));

            Assert.IsInstanceOf<User>(repository.InsertedItem[0]);
            Assert.That(((User)repository.InsertedItem[0]).UserName,Is.EqualTo("UserName"));
            Assert.That(((User)repository.InsertedItem[0]).Id, Is.EqualTo(1));

            Assert.IsInstanceOf<UserSession>(repository.InsertedItem[1]);
            Assert.True(Regex.Match(((UserSession)repository.InsertedItem[1]).SessionKey, "^[{(]?[0-9A-F]{8}[-]?([0-9A-F]{4}[-]?){3}[0-9A-F]{12}[)}]?$", RegexOptions.IgnoreCase).Success);
            Assert.That(((UserSession)repository.InsertedItem[1]).Id, Is.EqualTo(1));
        }

        [Test]
        public void AddUser_DoesNotAddUser_WhenUserExists()
        {
            var repository = new RepositoryFake();
            FindUserQuery fnq = FakeFindUserFake.UserFound(new User {UserName = "UserToFind",Id = 1});

            var interactor = GetAddUserInteractor(repository, fnq);
            var result = interactor.Execute("UserName");

            Assert.That(result.OperationSuccess, Is.False);
            Assert.That(string.IsNullOrEmpty(result.SessionKey), Is.True);
            Assert.That(repository.InsertedItem.Count, Is.EqualTo(0));
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
