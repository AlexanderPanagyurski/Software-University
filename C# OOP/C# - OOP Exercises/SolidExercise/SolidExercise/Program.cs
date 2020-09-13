
namespace SolidExercise
{
    using SolidExercise.Appenders;
    using SolidExercise.Appenders.Contracts;
    using SolidExercise.Core;
    using SolidExercise.Core.Contracts;
    using SolidExercise.Layouts;
    using SolidExercise.Layouts.Contracts;
    using SolidExercise.Loggers;
    using SolidExercise.Loggers.Contracts;
    using SolidExercise.Loggers.Enums;
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();

            Engine engine = new Engine(commandInterpreter);

            engine.Run();
        }
    }
}
