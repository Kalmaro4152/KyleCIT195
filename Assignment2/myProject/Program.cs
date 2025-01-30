using System;

namespace myProject
{
    class workDue
    {
        private int _Due;
        private string _Name;
        private string _Teacher;

        public workDue()
        {
            _Due = 0;
            _Teacher = "";
            _Name = "";
        }
        public workDue(int Amount, string Assign, string Person)
        {
            _Due = Amount;
            _Teacher = Person;
            _Name = Assign;
        }

        public int GetDue()
        {
            return _Due;
        }
        public string GetName()
        {
            return _Name;
        }
        public string GetTeacher()
        {
            return _Teacher;
        }
        public void SetDue(int amnt)
        {
            _Due = amnt;
        }
        public void SetName(string assgn)
        {
            _Name = assgn;
        }
        public void SetTeacher(string human)
        {
            _Teacher = human;
        }
    }
    class workTime
    {
        static void displayAssignments(workDue assignment)
        {
            Console.WriteLine("Here's info about your assignment!");
            Console.WriteLine($"Priority: {assignment.GetDue()}");
            Console.WriteLine($"Name: {assignment.GetName()}");
            Console.WriteLine($"Teacher: {assignment.GetTeacher()}");
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            //Default Assignment Block
            workDue defaultDue = new workDue();
            defaultDue.SetDue(1);
            defaultDue.SetName("CSharp Coding");
            defaultDue.SetTeacher("Lisa Balbach");

            //User Book Block
            workDue usrDue = new workDue();
            Console.WriteLine("Please enter an Assignment Priority: ");
            usrDue.SetDue(int.Parse(Console.ReadLine()));
            Console.WriteLine("Please enter an Assignment Name: ");
            usrDue.SetName(Console.ReadLine());
            Console.WriteLine("Please enter the Teacher Name: ");
            usrDue.SetTeacher(Console.ReadLine());

            //Parameterized Book Block
            workDue paramDue = new workDue(2, "HTML1", "Lise Balbach");

            //Parameterized Book Block but Custom
            Console.WriteLine("Please enter a Assigment Priority: ");
            int assignDue = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter an Assignment Name: ");
            string assignName = Console.ReadLine();
            Console.WriteLine("Please enter the Teacher: ");
            string assignTeacher = Console.ReadLine();
            workDue customDue = new workDue(assignDue, assignName, assignTeacher);

            //Call the assignemnts forth
            displayAssignments(defaultDue);
            displayAssignments(usrDue);
            displayAssignments(paramDue);
            displayAssignments(customDue);
        }

    }
}
