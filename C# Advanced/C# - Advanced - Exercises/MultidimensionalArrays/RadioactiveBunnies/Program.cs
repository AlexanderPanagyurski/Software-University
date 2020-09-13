using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioactiveBunnies
{
    class Program
    {
        static void Main(string[] args)
        {

            TownPicture town1 = new TownPicture();
            TownPicture town2 = new TownPicture("Sofia.PNG", "Sofia");

            TownPicture[] array = new TownPicture[7];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new TownPicture();
            } 
        }
    }
}
