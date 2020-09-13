using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Car
    {
        public string Model { get; }
        public Engine Engine { get; }
        public Cargo Cargo { get; }
        private Tire[] tires { get;}

        public Car()
        {

        }

        public Car(string model, Engine engine, Cargo cargo)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
            tires = new Tire[4];
        }
        public void AddTiresInfo(double tire1Pressure, int tire1Age, double tire2Pressure, int tire2Age,
            double tire3Pressure, int tire3Age, double tire4Pressure, int tire4Age)
        {
            tires[0] = new Tire(tire1Pressure, tire1Age);
            tires[1] = new Tire(tire2Pressure, tire2Age);
            tires[2] = new Tire(tire3Pressure, tire3Age);
            tires[3] = new Tire(tire4Pressure, tire4Age);
        }
        public void AddTiresInfo(Tire tire1, Tire tire2, Tire tire3, Tire tire4)
        {
            tires[0] = tire1;
            tires[1] = tire2;
            tires[2] = tire3;
            tires[3] = tire4;
        }
        public bool IsLessThan1()
        {
            bool checker = false;
            foreach (var item in tires)
            {
                if (item.TirePressure<1)
                {
                    checker = true;
                    break;
                }
            }
            return checker;
        }

    }
}
