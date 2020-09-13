using System;
using System.Collections.Generic;
using System.Text;

namespace PointInRectangle
{
    public class Point
    {
        public int X { get;private set; }
        public int Y { get;private set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
