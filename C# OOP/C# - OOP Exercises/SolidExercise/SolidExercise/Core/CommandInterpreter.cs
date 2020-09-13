﻿using SolidExercise.Appenders.Contracts;
using SolidExercise.Core.Contracts;
using SolidExercise.Layouts.Contracts;
using SolidExercise.Loggers.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolidExercise.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private ICollection<IAppender> appenders;
        private IAppenderFactory appenderFactory;
        private ILayoutFactory layoutFactory;

        public CommandInterpreter()
        {
            this.appenders = new List<IAppender>();
            this.appenderFactory = new AppenderFactory();
            this.layoutFactory = new LayoutFactory();
        }

        public void AddApender(string[] args)
        {
            string typeAppender = args[0];
            string typeLayout = args[1];
            ReportLevel reportLevel = ReportLevel.INFO;

            if (args.Length == 3)
            {
                reportLevel = Enum.Parse<ReportLevel>(args[2]);
            }
            ILayout layout = this.layoutFactory.CreateLayout(typeLayout);

            IAppender appender = this.appenderFactory.CreateAppender(typeAppender, layout);

            appender.ReportLevel = reportLevel;

            appenders.Add(appender);
        }

        public void AddReport(string[] args)
        {
            string reportType = args[0];
            string datetime = args[1];
            string message = args[2];
            ReportLevel reportLevel = Enum.Parse<ReportLevel>(reportType);
            foreach (var appender in appenders)
            {
                appender.Append(datetime, reportLevel, message);
            }
        }

        public void PrintInfo()
        {

        }
    }
}
