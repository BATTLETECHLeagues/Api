using System.Configuration;
using NLog;
using System.Web.Http;
using Microsoft.ApplicationInsights.NLogTarget;
using NLog.Config;

namespace Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var config = new LoggingConfiguration();
            ConfigurationItemFactory.Default.Targets.RegisterDefinition(
                "ai",
                typeof(ApplicationInsightsTarget)
            );
            ApplicationInsightsTarget aiTarget = new ApplicationInsightsTarget();
            aiTarget.InstrumentationKey = ConfigurationManager.AppSettings["APPINSIGHTS_INSTRUMENTATIONKEY"];
            aiTarget.Name = "ai";
            config.AddTarget("ai", aiTarget);
            LogManager.Configuration = config;

            var logger = LogManager.GetLogger("Global Logger");

            logger.Info("Application Has Started");
        }
    }
}
