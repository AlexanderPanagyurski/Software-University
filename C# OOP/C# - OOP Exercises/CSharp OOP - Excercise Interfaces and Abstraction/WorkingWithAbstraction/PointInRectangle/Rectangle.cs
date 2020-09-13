using System;
using System.Collections.Generic;
using System.Text;

namespace PointInRectangle
{
    public class Rectangle
    {
        public Point TopLeftPoint { get; set; }
        public Point TopRightPoint { get; private set; }

        public Rectangle(int topLeftX, int topLeftY, int bottomRightX, int bottomRightY)
        {
            TopLeftPoint = new Point(topLeftX, topLeftY);
            TopRightPoint = new Point(bottomRightX, bottomRightY);
        }
        public bool Contains(Point point)
        {
            bool doesContains = false;

            if (point.X >= TopLeftPoint.X && point.X <= TopRightPoint.X
                && point.Y >= TopLeftPoint.Y && point.Y <= TopRightPoint.Y)
            {
                doesContains = true;
            }
            return doesContains;
        }
    }
}
