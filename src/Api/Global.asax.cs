using NLog;
using System.Web.Http;

namespace Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var logger = LogManager.GetLogger("Global Logger");

            logger.Info("Application Has Started");
        }
    }
}
