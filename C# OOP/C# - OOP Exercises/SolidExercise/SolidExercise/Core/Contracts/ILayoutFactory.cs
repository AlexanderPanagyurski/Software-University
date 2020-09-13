using SolidExercise.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolidExercise.Core.Contracts
{
    public interface ILayoutFactory
    {
        ILayout CreateLayout(string type);
    }
}
