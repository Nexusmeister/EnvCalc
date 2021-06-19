using System;
using System.Collections.Generic;
using System.IO;
using Serilog;
using Serilog.Events;
using Serilog.Parsing;

namespace EnvCalc.Tools
{
    public class Logger : ILogger
    {
        public static Logger Instanz;

        public void WriteLog(string message, LogEventLevel level)
        {
            Write(new LogEvent(DateTimeOffset.Now, level, null,
                new MessageTemplate(message, new List<MessageTemplateToken>()), new List<LogEventProperty>()));
        }

        public void WriteException(string message, LogEventLevel level, Exception exception)
        {
            Write(new LogEvent(DateTimeOffset.Now, level, exception,
                new MessageTemplate(message, new List<MessageTemplateToken>()), new List<LogEventProperty>()));
        }

        public void Write(LogEvent logEvent)
        {
            switch (logEvent.Level)
            {
                case LogEventLevel.Verbose:
                    WriteToFile("Verbose", logEvent);
                    break;
                case LogEventLevel.Debug:
                    WriteToFile("Debug", logEvent);
                    break;
                case LogEventLevel.Information:
                    WriteToFile("Info", logEvent);
                    break;
                case LogEventLevel.Warning:
                    WriteToFile("Warning", logEvent);
                    break;
                case LogEventLevel.Error:
                    WriteToFile("ERROR", logEvent);
                    WriteExceptionToFile("ERROR", logEvent);
                    break;
                case LogEventLevel.Fatal:
                    WriteToFile("FATAL", logEvent);
                    WriteExceptionToFile("FATAL", logEvent);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void WriteToFile(string level, LogEvent log)
        {
            var sw = File.AppendText(AppSettings.Loggerpfad);
            sw.WriteLine($"[{level}] [{log.Timestamp}] {log.MessageTemplate.Text}");
            sw.Close();
        }

        private void WriteExceptionToFile(string level, LogEvent log)
        {
            var sw = File.AppendText(AppSettings.Loggerpfad);
            sw.WriteLine($"[{level}] [{log.Timestamp}] {log.Exception}");
            sw.Close();
        }
    }
}