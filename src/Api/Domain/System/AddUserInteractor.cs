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
        public void Execute(string userName)
        {
            if (_findUserQuery.Execute(userName) != null)
                return;
            

            var user = new User
            {
                UserName = userName
            };

            var id = _repository.Insert(user);
            user.Id = id;
        }

        public class AddUserRequest
        {
            public string UserName { get; set; }
        }
    }
}