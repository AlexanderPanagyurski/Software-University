using System;
using System.Collections.Generic;
using System.Text;

namespace SolidExercise.Loggers.Contracts
{
    public interface ILogger
    {
        void Info(string dateTime, string infoMessage);

        void Error(string dateTime, string errorMessage);

        void Warning(string dateTime, string errorMessage);

        void Critical(string dateTime, string errorMessage);

        void Fatal(string dateTime, string errorMessage);
    }
}
