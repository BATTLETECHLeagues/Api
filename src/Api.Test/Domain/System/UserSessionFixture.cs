using System.Text.RegularExpressions;
using Api.Domain;
using NUnit.Framework;

namespace Api.Test.Domain
{
    [TestFixture]
    public class UserSessionFixture
    {
        [Test]
        public void UserSession_Create_CreatesSession()
        {
            var userId = 1;
            string userName = "UserName";
            UserSession session = UserSession.Create(userId, userName);

            Assert.That(session.UserId, Is.EqualTo(userId));
            Assert.True(Regex.Match(session.SessionKey, "^[{(]?[0-9A-F]{8}[-]?([0-9A-F]{4}[-]?){3}[0-9A-F]{12}[)}]?$", RegexOptions.IgnoreCase).Success);
        }
    }
}
