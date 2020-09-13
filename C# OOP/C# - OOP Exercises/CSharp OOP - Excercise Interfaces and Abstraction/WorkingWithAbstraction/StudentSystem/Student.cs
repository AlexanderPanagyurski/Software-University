using System;
using System.Collections.Generic;
using System.Text;

namespace StudentSystem
{
    public class Student
    {
        public string Name { get; }
        public int Age { get; }
        public double Grade { get; }

        public Student(string name, int age, double grade)
        {
            Name = name;
            Age = age;
            Grade = grade;
        }
        public override string ToString()
        {
            string result = string.Empty;
            if (Grade >= 5.50)
            {
                result = $"{Name} is {Age} years old. Excellent student.";
            }
            else
            {
                result = $"{Name} is {Age} years old. Average student.";
            }
            return result.TrimEnd();
        }
    }
}
