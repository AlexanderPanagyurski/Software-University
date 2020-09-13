using SolidExercise.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolidExercise.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
