using System.Web.Http;
using Api.Domain;

namespace Api.Controllers
{
    public class UserController : ApiController
    {
        private readonly RetrieveUserInteractor _retrieveUserInteractor;
        // POST api/<controller>
        public UserController(RetrieveUserInteractor retrieveUserInteractor)
        {
            _retrieveUserInteractor = retrieveUserInteractor;
        }

        public void Post([FromBody]string value)
        {
        }

        // GET api/<controller>/5
        public User Get(int id)
        {
            return _retrieveUserInteractor.Execute(id);
        }
    }

    public class GetUserRequest
    {
        
    }

    public class GetUserResponse
    {
        
    }
}