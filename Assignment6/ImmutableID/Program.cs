using System;
namespace ImmutableID
{
    class Student
    {
        // auto-implemented properties
        public int Id { get; init; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // default constructor
        public Student()
        {
            Id = 0;
            FirstName = "";
            LastName = "";
        }
        //immutable accessor constructor???
        public Student(int id)
        {
            Id=id;
            FirstName=String.Empty;
            LastName=String.Empty;
        }
        // parameterized constructor
        public Student(int i, string First, string Last)
        {
            Id = i;
            FirstName = First;
            LastName = Last;
        }
    }
    class Program
    {
        public static void Main()
        {
            Student student1 = new Student(8);
            student1.FirstName = "Kyle";
            student1.LastName= "Morrill";
            Student student2 = new Student(16, "Henry", "Henryson");
            Console.WriteLine(student1.FirstName + student1.LastName + student1.Id);
            Console.WriteLine(student2.FirstName + student2.LastName + student2.Id);
        }
    }
}