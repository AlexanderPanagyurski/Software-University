using System;
using System.Collections.Generic;
using System.Text;

namespace SolidExercise.Core.Contracts
{
    public interface ICommandInterpreter
    {
        void AddApender(string[] args);

        void AddReport(string[] args);
        void PrintInfo();
    }
}
