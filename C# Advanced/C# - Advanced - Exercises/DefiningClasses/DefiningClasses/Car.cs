using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public string Weight { get; set; }
        public string Color { get; set; }

        public Car(string model, Engine engine, string weight, string color)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }
        public string CarInfo()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"{Model}:" + Environment.NewLine);
            builder.Append($"  {Engine.Model}:" + Environment.NewLine);
            builder.Append($"    Power: {Engine.Power}" + Environment.NewLine);
            builder.Append($"    Displacement: {Engine.Displacement}" + Environment.NewLine);
            builder.Append($"    Efficiency: {Engine.Efficiency}" + Environment.NewLine);
            builder.Append($"  Weight: {Weight}" + Environment.NewLine);
            builder.Append($"  Color: {Color}" + Environment.NewLine);
            return builder.ToString();
        }
    }
}
