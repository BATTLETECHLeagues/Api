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
            var token = _userLoginInteractor.Execute(account.userName);
            return new LoginResponse {Token = token};   
        }
    }


    public class LoginResponse
    {
        public string Token { get; set; }
    }

    public class LoginRequest
    {
        public string userName { get; set; }
    }
}