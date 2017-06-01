using System.Security.Claims;
using Api.Domain;
using NUnit.Framework;

namespace Api.Test.Domain
{
    [TestFixture]
    public class UserLoginInteractorFixture
    {
        [Test]
        public void Execute_OnSuccess_ReturnsToken()
        {
            var interactor = new UserLoginInteractor(new FakeTokenManager(), FakeFindUserFake.UserFound(new User {UserName = "UserName"}));

            var token = interactor.Execute("UserName");

            Assert.That(token, Is.EqualTo(FakeTokenManager.Token));
        }

        [Test]
        public void Execute_OnFailure_DoesNotReturnToken()
        {
            var interactor = new UserLoginInteractor(new FakeTokenManager(), FakeFindUserFake.NoUserFound());

            var token = interactor.Execute("UserName");

            Assert.True(string.IsNullOrEmpty(token));
        }

        private class FakeTokenManager : TokenManager
        {
            public const string Token = "Token";

            public string GenerateToken(string username, int expireMinutes = 20)
            {
                return Token;
            }

            public ClaimsPrincipal GetPrincipal(string token)
            {
                throw new global::System.NotImplementedException();
            }
        }


    }
}
