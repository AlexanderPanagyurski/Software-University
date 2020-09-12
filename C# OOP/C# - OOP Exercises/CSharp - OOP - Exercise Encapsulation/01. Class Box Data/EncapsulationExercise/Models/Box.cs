using EncapsulationExercise.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EncapsulationExercise.Models
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return length;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(BoxExceptionMessages.LengthExceptionMessage);
                }
                length = value;
            }
        }

        public double Width
        {
            get
            {
                return width;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(BoxExceptionMessages.WidthExceptionMessage);
                }
                width = value;
            }
        }

        public double Height
        {
            get
            {
                return height;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(BoxExceptionMessages.HeightExceptionMessage);
                }
                height = value;
            }
        }

        public double CalculateSurfaceArea()
        {
            return 2 * (Height * Width) + 2 * (Height * Length) + 2 * (Width * Length);
        }

        public double CalculateLateralSurfaceArea()
        {
            //2(l + b)h
            return 2 * (Length + Width) * Height;
        }

        public double CalculateVolume()
        {
            return Length * Width * Height;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Surface Area - {CalculateSurfaceArea():f2}" + Environment.NewLine);
            sb.Append($"Lateral Surface Area - {CalculateLateralSurfaceArea():f2}" + Environment.NewLine);
            sb.Append($"Volume - {CalculateVolume():f2}" + Environment.NewLine);

            return sb.ToString().TrimEnd();
        }
    }
}
