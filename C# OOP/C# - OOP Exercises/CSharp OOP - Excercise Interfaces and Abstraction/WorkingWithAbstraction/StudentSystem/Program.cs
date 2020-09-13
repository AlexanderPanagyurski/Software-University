using System;
using System.Collections.Generic;

namespace StudentSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Repository students = new Repository();

            while (command?.ToLower() != "exit")
            {
                string[] splitCommand = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (splitCommand[0] == "Create")
                {
                    string studentName = splitCommand[1];
                    int studentAge = int.Parse(splitCommand[2]);
                    double studentGrade = double.Parse(splitCommand[3]);
                    Student student = new Student(studentName, studentAge, studentGrade);
                    bool doesContains = students.Contains(student);
                    if (!doesContains)
                    {
                        students.Add(student);
                    }
                }
                else if (splitCommand[0] == "Show")
                {
                    string studentName = splitCommand[1];
                    bool doesContains = students.Contains(studentName);
                    if (doesContains)
                    {
                        Student student = students.Find(studentName);
                        Console.WriteLine(student);
                    }
                }
                command = Console.ReadLine();
            }
        }
    }
}
