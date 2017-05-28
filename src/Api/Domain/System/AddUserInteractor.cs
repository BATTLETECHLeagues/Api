namespace Api.Domain
{
    public class AddUserInteractor
    {
        private readonly IRepository _repository;
        private readonly FindUserQuery _findUserQuery;

        public AddUserInteractor(IRepository repository, FindUserQuery findUserQuery)
        {
            _repository = repository;
            _findUserQuery = findUserQuery;
        }
        public AddUserResponse Execute(string userName)
        {
            if (_findUserQuery.Execute(userName) != null)
                return new AddUserResponse {OperationSuccess = false};
            
            var id = CreateAndInsertUser(userName);

            var userSession = CreateAndInsertUserSession(userName, id);

            return new AddUserResponse {OperationSuccess = true,SessionKey = userSession.SessionKey};
        }

        private UserSession CreateAndInsertUserSession(string userName, long id)
        {
            var userSession = UserSession.Create(id, userName);

            userSession.Id = _repository.Insert(userSession);
            return userSession;
        }

        private long CreateAndInsertUser(string userName)
        {
            var user = new User
            {
                UserName = userName
            };

            var id = _repository.Insert(user);
            user.Id = id;
            return id;
        }

        public class AddUserRequest
        {
            public string UserName { get; set; }
        }

        public class AddUserResponse
        {
            public bool OperationSuccess { get; set; }
            public string SessionKey { get; set; }
        }
    }
}