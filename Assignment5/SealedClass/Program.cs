using System;
using System.Reflection;
namespace SealedClass
{
    interface IEmployee
    {
        //Properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Methods
        public string Fullname();
        public double Pay();
    }
    class Employee : IEmployee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Employee()
        {
            Id = 0;
            FirstName = string.Empty;
            LastName = string.Empty;
        }
        public Employee(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        public string Fullname()
        {
            return FirstName + " " + LastName;
        }
        public virtual double Pay()
        {
            double salary;
            Console.WriteLine($"What is {this.Fullname()}'s weekly salary?");
            salary = double.Parse(Console.ReadLine());
            return salary;
        }

    }  
    sealed class Executive : Employee
    {
        public string Title{get;set;}
        public double Salary{get;set;}

        public Executive()
        {
            Id = 0;
            FirstName = "";
            LastName = "";
            Title = "";
            Salary = 0;
        }
        public Executive(int Id, string FirstName, string LastName, string title, double salary)
            :base(Id, FirstName, LastName)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            Title = title;
            Salary = salary;
        }
        public override double Pay()
        {
            Console.WriteLine($"How much did you get paid?");
            Salary = double.Parse(Console.ReadLine());
            Salary = Salary * 15;
            Console.WriteLine("Doing a little math ;)");
            return Salary;
        }
    }
    class Program{
        public static void Main(string[] args)
        {
            Employee robert = new Employee(99, "Robert", "Gamer");
            Executive richard = new Executive (1, "Richard", "Cheddar", "Big Rat", 120000);
            Console.WriteLine(robert.Fullname());
            Console.WriteLine($"{robert.Fullname()}'s weekly salary is ${robert.Pay()}");
            Console.WriteLine(richard.Fullname());
            Console.WriteLine($"{richard.Fullname()}'s weekly pay is ${richard.Pay()}, because they obviously deserves 15 times what you make. :)");
        }
    }
}
