using System.Configuration;
using NLog;
using System.Web.Http;
using Microsoft.ApplicationInsights.NLogTarget;
using Microsoft.ApplicationInsights;
using NLog.Config;

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
            LoggingRule rule = new LoggingRule("*", LogLevel.Trace, aiTarget);
            LogManager.Configuration.LoggingRules.Add(rule);
            var logger = LogManager.GetLogger("Global Logger");
            TelemetryClient telemetry = new TelemetryClient();
            telemetry.TrackEvent("WinGame");
            logger.Error("Application Has Started");
        }
    }
}
