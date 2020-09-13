using SolidExercise.Appenders.Contracts;
using SolidExercise.Layouts.Contracts;
using SolidExercise.Loggers.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolidExercise.Appenders
{
    public class ConsoleAppender : IAppender
    {
        private ILayout layout;

        public ConsoleAppender(ILayout layout)
        {
            this.layout = layout;
        }
        public ReportLevel ReportLevel { get; set; }

        public void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel <= reportLevel)
            {
                Console.WriteLine(string.Format(this.layout.Format, dateTime, reportLevel, message));

            }
        }

    }
}
