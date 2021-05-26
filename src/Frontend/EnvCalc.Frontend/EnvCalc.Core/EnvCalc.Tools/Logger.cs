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
        public static Logger Entity;

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
                    WriteToFile("Verbose", logEvent.MessageTemplate.Text);
                    break;
                case LogEventLevel.Debug:
                    WriteToFile("Debug", logEvent.MessageTemplate.Text);
                    break;
                case LogEventLevel.Information:
                    WriteToFile("Info", logEvent.MessageTemplate.Text);
                    break;
                case LogEventLevel.Warning:
                    WriteToFile("Warning", logEvent.MessageTemplate.Text);
                    break;
                case LogEventLevel.Error:
                    WriteToFile("ERROR", logEvent.MessageTemplate.Text);
                    WriteToFile("ERROR", logEvent.Exception.ToString());
                    break;
                case LogEventLevel.Fatal:
                    WriteToFile("FATAL", logEvent.MessageTemplate.Text);
                    WriteToFile("FATAL", logEvent.Exception.ToString());
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void WriteToFile(string level, string logMessage)
        {
            var sw = File.AppendText(AppSettings.Loggerpfad);
            sw.WriteLine($"[{level}] {logMessage}");
            sw.Close();
        }
    }
}