using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    class Group
    {
        public string Name { get; set; }
        public int MaxStudentCount  { get; set; }
        private List<Student> Students { get; set; }
        private static int count;
        public readonly int Id;

        private Group()
        {   
           
            count++;
            Id = count;
            Students = new List<Student>();
        }

        public Group(string name, int maxStudentCount) : this()
        {
            MaxStudentCount = maxStudentCount;
            Name = name;
        }

        public override string ToString()
        {
            return $"Group: {Id} - Name: {Name}";
        }

        public override bool Equals(object obj)
        {
            return Name == ((Group)obj).Name;
        }

        public bool AddStudent(Student student)
        {
            
            if (Students.Contains(student))
            {
                return false;
            }

            Students.Add(student);
            return true;
        }

        public bool RemoveStudent(int id)
        {
            int count = Students.Count;

            for (int i = 0; i < count; i++)
            {
                if (Students[i].Id == id)
                {
                    Students.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }
        public void PrintAllStudents()
        {
            foreach (Student item in Students)
            {
                Console.WriteLine($" {item} is in Group {Name}");
            }
        }

        public void SearchAndPrintStudents(string query)
        {
            bool resultFound = false;
            foreach (Student item in Students)
            {
                if (item.Name.Contains(query) || item.Major.Contains(query))
                {
                    Console.WriteLine($"{item} in {Name}");
                    resultFound = true;
                }
            }

            if (!resultFound)
            {
                Console.WriteLine($"No results found in {Name}.");
            }


        }
    }
}
