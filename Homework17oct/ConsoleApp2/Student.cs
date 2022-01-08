using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Major { get; set; }
        public string Age { get; set; }
 
        List<int> studMarks = new List<int>();

        private static int count;
        public readonly int Id;


        public Student()
        {
            count++;
            Id = count;
        }
        public Student(string name, string surname, string major, string age):this()
        {
            Name = name;
            Surname = surname;
            Major = major;
            Age = age;
            
        }
        public override string ToString()
        {
            return $"Student: {Id} - Name: {Name} - Surname: {Surname} - Major: {Major} - Age: {Age} ";
        }
        public override bool Equals(object obj)
        {
            return Name == ((Student)obj).Name;
        }
        

    }
}
