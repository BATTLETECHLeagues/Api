namespace Api.Domain
{
    public class UserLoginInteractor
    {
        private readonly TokenManager _tokenManager;
        private readonly FindUserQuery _findUserQuery;

        public UserLoginInteractor(TokenManager tokenManager, FindUserQuery findUserQuery)
        {
            _tokenManager = tokenManager;
            _findUserQuery = findUserQuery;
        }

        public string Execute(string userName)
        {
            if (_findUserQuery.Execute(userName) != null)
                return _tokenManager.GenerateToken(userName);

            return string.Empty;
        }
    }
}