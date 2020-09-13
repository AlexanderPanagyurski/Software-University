using SolidExercise.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolidExercise.Core
{
    public class Engine : IEngine
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            int appendersCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < appendersCount; i++)
            {
                string[] appendeArgs = Console.ReadLine().Split();

                this.commandInterpreter.AddApender(appendeArgs);
            }
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] reportArgs = input.Split("|");

                this.commandInterpreter.AddReport(reportArgs);


                input = Console.ReadLine();
            }
            this.commandInterpreter.PrintInfo();
        }
    }
}
