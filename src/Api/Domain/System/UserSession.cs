using System;
using Microsoft.ApplicationInsights.Web;

namespace Api.Domain
{
    public class UserSession
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string SessionKey { get; set; }

        public static UserSession Create(long userId, string userName)
        {
            return new UserSession {UserId = userId,SessionKey = Guid.NewGuid().ToString()};
        }
    }
}