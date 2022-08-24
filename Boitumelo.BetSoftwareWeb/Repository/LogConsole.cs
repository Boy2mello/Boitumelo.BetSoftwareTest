using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Boitumelo.BetSoftwareWeb.Repository
{
    public class LogConsole : ILogger
    {
        private readonly string _name;
       // private readonly Func<LogConsoleConfiguartion> _getCurrentConfig;
        public IDisposable BeginScope<TState>(TState state) => default;

        public bool IsEnabled(LogLevel logLevel) => true;  

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            EventLog.WriteEntry("BetSoftware - Log {0}", exception.Message);
        }
    }
}