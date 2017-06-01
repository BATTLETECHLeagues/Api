using System.Security.Claims;
using Api.Infrastructure.Security;
using NUnit.Framework;

namespace Api.Test.Infrastructure.Security
{
    [TestFixture]
    public class JwtTokenManagerFixture
    {
        [Test]
        public void JwtManager_GeneratesToken()
        {
            JwtTokenManager tokenManager = new JwtTokenManager();
            var username = "UserName";
            var token = tokenManager.GenerateToken(username);


            var simplePrinciple = tokenManager.GetPrincipal(token);
            var identity = simplePrinciple.Identity as ClaimsIdentity;


            Assert.That(token, Is.Not.Null);
            Assert.That(identity.Name, Is.EqualTo(username));

        }
    }
}
