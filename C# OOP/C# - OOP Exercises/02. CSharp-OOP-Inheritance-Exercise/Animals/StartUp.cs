using System;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string animalType = Console.ReadLine();

            while (animalType != "Beast!")
            {

                try
                {


                    var animalInfo = Console.ReadLine()
                   .Split(" ")
                   .ToArray();


                    if (animalType == "Cat")
                    {
                        Cat cat = new Cat(animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]);
                        Console.WriteLine(cat);
                        Console.WriteLine(cat.ProduceSound());
                    }
                    else if (animalType == "Tomcat")
                    {
                        Tomcat tomcat = new Tomcat(animalInfo[0], int.Parse(animalInfo[1]));
                        Console.WriteLine(tomcat);
                        Console.WriteLine(tomcat.ProduceSound());

                    }
                    else if (animalType == "Kitten")
                    {
                        Kitten kitten = new Kitten(animalInfo[0], int.Parse(animalInfo[1]));
                        Console.WriteLine(kitten);
                        Console.WriteLine(kitten.ProduceSound());
                    }
                    else if (animalType == "Dog")
                    {
                        Dog dog = new Dog(animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]);
                        Console.WriteLine(dog);
                        Console.WriteLine(dog.ProduceSound());
                    }
                    else if (animalType == "Frog")
                    {
                        Frog frog = new Frog(animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]);
                        Console.WriteLine(frog);
                        Console.WriteLine(frog.ProduceSound());
                    }

                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

                animalType = Console.ReadLine();
            }

        }
    }
}
