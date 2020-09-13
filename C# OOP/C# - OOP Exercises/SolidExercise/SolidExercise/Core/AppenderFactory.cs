using SolidExercise.Appenders;
using SolidExercise.Appenders.Contracts;
using SolidExercise.Core.Contracts;
using SolidExercise.Layouts.Contracts;
using SolidExercise.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolidExercise.Core
{
    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout)
        {
            string typeToLower = type.ToLower();

            if (typeToLower=="consoleappender")
            {
                return new ConsoleAppender(layout);
            }
            else if (typeToLower == "fileappender")
            {
                return new FileAppender(layout,new LogFile());
            }
            throw new ArgumentException("Invalid appender type");
        }
    }
}
