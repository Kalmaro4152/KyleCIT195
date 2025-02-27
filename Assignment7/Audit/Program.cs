using System;
using System.Drawing;
namespace Audit
{
    class Auditor
    {
        public string Name{get;set;}
        public string PhoneNumber{get;set;}

    }
    class Business
    {
        public string Name{get;set;}
        public string Type{get;set;}
        public string Address{get;set;}
        public Auditor Auditor{get;set;}

        public void displayBusiness()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Business Information");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Type: {Type}");
            Console.WriteLine($"Address: {Address}");
            Console.WriteLine($"Auditor Name: {Auditor.Name}");
            Console.WriteLine($"Auditor Phone Number: {Auditor.PhoneNumber}");
        }
    }
    class program
    {
        static void Main()
        {
            Auditor auditor = new Auditor {Name = "Jacob", PhoneNumber = "555-555-5555"};
            Business realty = new Business {Name = "Structureality", Address = "Sydeny", Type = "Reality", Auditor = auditor};
            realty.displayBusiness();
        }
    }
}