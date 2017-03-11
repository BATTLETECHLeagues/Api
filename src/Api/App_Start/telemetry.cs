using System;
using System.Web.Http.ExceptionHandling;
using Api;


namespace Api
{
    public class AiExceptionLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            base.Log(context);
        }
    }
}