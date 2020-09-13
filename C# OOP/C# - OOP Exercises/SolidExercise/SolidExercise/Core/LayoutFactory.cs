using SolidExercise.Core.Contracts;
using SolidExercise.Layouts;
using SolidExercise.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolidExercise.Core
{
    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            string typeAsLower = type.ToLower();

            if (typeAsLower=="simplelayout")
            {
                return new SimpleLayout();
            }
            else if (typeAsLower=="xmllayout")
            {
                return new XmlLayout();
            }
            throw new ArgumentException("Invalid layout type!");
        }
    }
}
