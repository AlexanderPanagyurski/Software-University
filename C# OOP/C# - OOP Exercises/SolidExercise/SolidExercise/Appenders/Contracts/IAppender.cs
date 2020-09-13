using SolidExercise.Loggers.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolidExercise.Appenders.Contracts
{
    public interface IAppender
    {
        void Append(string dateTime, ReportLevel reportLevel, string message);
        ReportLevel ReportLevel { get; set; }
    }
}
