using System.Configuration;
using NLog;
using System.Web.Http;
using Microsoft.ApplicationInsights.NLogTarget;
using Microsoft.ApplicationInsights;
using NLog.Config;
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

        public void Post([FromBody]UserAccount account)
        {
            try
            {
                _addUserInteractor.Execute(account.userName);
            }
            catch  (Exception ex)
            {
                TelemetryClient telemetry = new TelemetryClient();
                telemetry.TrackEvent("WinGame");

            }
                
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