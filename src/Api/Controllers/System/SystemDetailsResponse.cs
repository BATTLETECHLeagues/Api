using System.Configuration;
using NLog;
using System.Web.Http;
using Microsoft.ApplicationInsights.NLogTarget;
using Microsoft.ApplicationInsights;
using NLog.Config;

namespace Api.Controllers.System
{
    public class SystemDetailsResponse
    {
        public Version Version { get; set; }
    }

    public class Version
    {
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Revision { get; set; }
    }
}