namespace Api.Domain
{
    public interface FindSessionForUser
    {
        UserSession Execute(string sessionKey);
    }
}