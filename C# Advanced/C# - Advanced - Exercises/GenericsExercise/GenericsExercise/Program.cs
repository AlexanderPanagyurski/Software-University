using System;
using System.Linq;

namespace GenericsExercise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input1 = Console.ReadLine()
                .Split()
                .ToArray();

            var input2 = Console.ReadLine()
                .Split()
                .ToArray();

            var input3 = Console.ReadLine()
                .Split()
                .ToArray();

            var threeuple1 = new Threeuple<string, string, string>(input1[0] + " " + input1[1], input1[2], input1[3]);
            Threeuple<string, int, bool> threeuple2;
            if (input2[2] == "drunk")
            {
                threeuple2 = new Threeuple<string, int, bool>(input2[0], int.Parse(input2[1]), true);
            }
            else
            {
                threeuple2 = new Threeuple<string, int, bool>(input2[0], int.Parse(input2[1]), false);
            }
            var threeuple3 = new Threeuple<string, double, string>(input3[0], double.Parse(input3[1]), input3[2]);

            Console.WriteLine(threeuple1.ToString());
            Console.WriteLine(threeuple2.ToString());
            Console.WriteLine(threeuple3.ToString());
        }
    }
}
