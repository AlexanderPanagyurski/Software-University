using System;

namespace ExplicitInterfaces
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            while (command != "End")
            {
                string name = command.Split(' ')[0];
                string country = command.Split(' ')[1];
                int age = int.Parse(command.Split(' ')[2]);
                Citizen citizen = new Citizen(name,country, age);

                Console.WriteLine(((IPerson)citizen).GetName());
                Console.WriteLine(((IResident)citizen).GetName());

                command = Console.ReadLine();
            }

            
        }
    }
}
