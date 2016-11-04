namespace Api.Domain
{
    public class AddUserInteractor
    {
        private readonly IRepository _repository;

        public AddUserInteractor(IRepository repository)
        {
            _repository = repository;
        }
        public void Execute()
        {
            var user = new User
            {
                UserName = "UserName"
            };

            _repository.Insert(user);
        }

        public class AddUserRequest
        {
            public string UserName { get; set; }
        }
    }
}