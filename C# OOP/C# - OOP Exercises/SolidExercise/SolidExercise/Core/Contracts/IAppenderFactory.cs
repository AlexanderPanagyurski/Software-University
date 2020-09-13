using SolidExercise.Appenders.Contracts;
using SolidExercise.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolidExercise.Core.Contracts
{
    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout);
    }
}
