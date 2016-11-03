using Api.Infrastructure.Database;

namespace Api.Domain.User
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

    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}