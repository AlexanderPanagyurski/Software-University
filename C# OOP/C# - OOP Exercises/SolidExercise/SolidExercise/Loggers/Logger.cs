using SolidExercise.Appenders.Contracts;
using SolidExercise.Loggers.Contracts;
using SolidExercise.Loggers.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolidExercise.Loggers
{
    public class Logger : ILogger
    {
        private IAppender consoleAppender;
        private IAppender fileAppender;

        public Logger(IAppender consoleAppender)
        {
            this.consoleAppender = consoleAppender;
        }
        public Logger(IAppender consoleAppender, IAppender fileAppender)
        {
            this.consoleAppender = consoleAppender;
            this.fileAppender = fileAppender;
        }

        public void Critical(string dateTime, string criticalMessage)
        {
            this.Append(dateTime, ReportLevel.CRICITICAL, criticalMessage);
        }

        public void Warning(string dateTime, string criticalMessage)
        {
            this.Append(dateTime, ReportLevel.WARNING, criticalMessage);
        }

        public void Fatal(string dateTime, string fatalMessage)
        {
            this.Append(dateTime, ReportLevel.FATAL, fatalMessage);
        }

        public void Error(string dateTime, string errorMessage)
        {
            this.Append(dateTime, ReportLevel.ERROR, errorMessage);
        }

        public void Info(string dateTime, string infoMessage)
        {
            this.Append(dateTime, ReportLevel.INFO, infoMessage);
        }
        private void Append(string dateTime, ReportLevel strType, string message)
        {
            consoleAppender?.Append(dateTime, strType, message);
            fileAppender?.Append(dateTime, strType, message);
        }
    }
}
