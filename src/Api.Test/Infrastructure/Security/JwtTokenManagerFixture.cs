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
            var token = tokenManager.GenerateToken("sd");


            var simplePrinciple = tokenManager.GetPrincipal(token);
            var identity = simplePrinciple.Identity as ClaimsIdentity;


            Assert.That(token, Is.Not.Null);

        }
    }
}
