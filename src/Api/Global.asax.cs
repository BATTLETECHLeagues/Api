using System.Configuration;
using NLog;
using System.Web.Http;
using Microsoft.ApplicationInsights.NLogTarget;
using NLog.Config;
using Microsoft.ApplicationInsights;

namespace Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

  
            ApplicationInsightsTarget aiTarget = new ApplicationInsightsTarget();
            aiTarget.InstrumentationKey = ConfigurationManager.AppSettings["APPINSIGHTS_INSTRUMENTATIONKEY"];
            aiTarget.Name = "ai";
            LogManager.Configuration.AddTarget(aiTarget);

            var logger = LogManager.GetLogger("Global Logger");
            TelemetryClient telemetry = new TelemetryClient();
            telemetry.TrackEvent("WinGame");
            logger.Info("Application Has Started");
        }
    }
}
