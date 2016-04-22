﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;

namespace GoodAI.Logging
{
    public class SerilogRobe : ILog
    {
        static SerilogRobe()
        {
            // Serilog diagnostic output. Serilog won't write its errors into the user-space sinks.
            Serilog.Debugging.SelfLog.Out = Console.Out;
        }

        protected SerilogRobe(ILogger serilogLogger)
        {
            m_logger = serilogLogger;
        }

        public static ILog CreateLogger(Func<LoggerConfiguration, LoggerConfiguration> configAction)
        {
            return new SerilogRobe(configAction(SerilogRobeConfig.DefaultConfig).CreateLogger());
        }

        private readonly ILogger m_logger;

        #region ILog Implementation

        public void Add(Severity severity, string template, params object[] objects)
        {
            m_logger.Write(ConvertSeverity(severity), template, objects);
        }

        public void Add(Severity severity, Exception ex, string template, params object[] objects)
        {
            m_logger.Write(ConvertSeverity(severity), ex, template, objects);
        }

        #endregion

        private static LogEventLevel ConvertSeverity(Severity severity)
        {
            switch (severity)
            {
                case Severity.Error:   return LogEventLevel.Error;
                case Severity.Warn:    return LogEventLevel.Warning;
                case Severity.Info:    return LogEventLevel.Information;
                case Severity.Debug:   return LogEventLevel.Debug;
                case Severity.Verbose: return LogEventLevel.Verbose;
                default: return LogEventLevel.Error;
            }
        }
    }

    public class SerilogRobe<TContext> : SerilogRobe
    {
        public SerilogRobe(LoggerConfiguration serilogConfig)
            : base(serilogConfig.CreateLogger().ForContext("SourceContext", typeof(TContext).Name))
        { }
    }
}