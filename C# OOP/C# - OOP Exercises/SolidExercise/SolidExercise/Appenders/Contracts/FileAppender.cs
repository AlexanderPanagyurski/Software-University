using SolidExercise.Layouts.Contracts;
using SolidExercise.Loggers;
using SolidExercise.Loggers.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SolidExercise.Appenders.Contracts
{
    public class FileAppender : IAppender
    {
        private const string PATH = @"..\..\..\log.txt";
        private ILayout layout;
        private ILogFile logFile;

        public ReportLevel ReportLevel { get; set; }

        public FileAppender(ILayout layout, ILogFile logFile)
        {
            this.layout = layout;
            this.logFile = logFile;
        }

        public void Append(string dateTime, ReportLevel reportLevel, string message)
        {

            string content = string.Format(this.layout.Format, dateTime, reportLevel, message)
                + Environment.NewLine;

            if (this.ReportLevel <= reportLevel)
            {
                File.AppendAllText(PATH, content);
            }
        }
    }
}
