using System.Web.Http;
using Microsoft.ApplicationInsights;
using System;
using Api.Domain;

namespace Api.Controllers
{
    public class UserAccount
    {
        public string userName { get; set; }

    }

    public class UserController : ApiController
    {
        private readonly AddUserInteractor _addUserInteractor;
        private readonly RetrieveUserInteractor _retrieveUserInteractor;
        // POST api/<controller>
        public UserController(RetrieveUserInteractor retrieveUserInteractor, AddUserInteractor addUserInteractor)
        {
            _retrieveUserInteractor = retrieveUserInteractor;
            _addUserInteractor = addUserInteractor;
        }

        public AddUserInteractor.AddUserResponse Post([FromBody]UserAccount account)
        {
            AddUserInteractor.AddUserResponse result = null;
            try
            {
                result = _addUserInteractor.Execute(account.userName);

                //once user has been added log them in.
            }
            catch  (Exception ex)
            {
                TelemetryClient telemetry = new TelemetryClient();
                telemetry.TrackEvent(ex.ToString());
            }

            return result;

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