using System;
using System.Collections.Generic;
using System.Text;

namespace StudentSystem
{
    public class Repository
    {
        private List<Student> students;

        public Repository()
        {
            students = new List<Student>();
        }
        public void Add(Student student)
        {
            students.Add(student);
        }
        public bool Contains(Student student)
        {
            return students.Exists(s => s.Name == student.Name);
        }
        public bool Contains(string name)
        {
            return students.Exists(s => s.Name == name);
        }
        public Student Find(string name)
        {
            return students.Find(s => s.Name == name);
        }
    }
}
