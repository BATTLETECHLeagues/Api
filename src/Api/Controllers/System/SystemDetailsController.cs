using System.Collections.Generic;
using System.Web.Http;

namespace Api.Controllers.System
{
    public class SystemDetailsController : ApiController
    {
        // GET api/<controller>
        public SystemDetailsResponse Get()
        {
            return new SystemDetailsResponse {Version = new Version {Minor = 1} };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}