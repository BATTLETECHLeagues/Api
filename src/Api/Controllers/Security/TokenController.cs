using System.Web.Http;
using Api.Domain;

namespace Api.Controllers.Security
{
    public class TokenController : ApiController
    {
        private UserLoginInteractor _userLoginInteractor;

        public TokenController(UserLoginInteractor interactor)
        {
            _userLoginInteractor = interactor;

        }
        public LoginResponse Post([FromBody] LoginRequest account)
        {
            return new LoginResponse();   
        }
    }


    public class LoginResponse
    {
    }

    public class LoginRequest
    {
        public string userName { get; set; }
    }
}