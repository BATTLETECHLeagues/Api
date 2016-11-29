using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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