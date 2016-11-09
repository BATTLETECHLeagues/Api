namespace Api.Domain
{
    public interface FindUserQuery
    {
        User Execute(string userName);
    }
}
