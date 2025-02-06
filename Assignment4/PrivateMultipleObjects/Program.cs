using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Dynamic;
using System.Net;
using Microsoft.VisualBasic;
namespace AnimalInheritance
{
    // base Class 
    class Faction
    {
        private string name; // only accessible within this class
        private int strength; //accessible from derived classes
        private string color;  // accessible from any class

        //constructors
        public Faction()
        {
            name = "";
            strength = 0;
            color = "";
        }
        public Faction(string name, string color, int strength)
        {
            this.name = name;
            this.color = color;
            this.strength = strength;
        }

        public void setName(string name) {this.name = name;}
        public virtual string getName() {return this.name;}
        public void setColor(string col) {this.color = col;}
        public virtual string getColor() {return this.color;}
        public void setStrength(int stren) {this.strength = stren;}
        public virtual int getStrength() {return this.strength;}

        public virtual void addChange()
        {
            Console.Write("Faction Name= ");
            setName(Console.ReadLine());
            Console.Write("Faction Color= ");
            setColor(Console.ReadLine());
            Console.Write("Faction Strength= ");
            setStrength(int.Parse(Console.ReadLine()));
        }
        public virtual void display()
        {
            Console.WriteLine();
            Console.WriteLine($"Faction Name: {getName()}, its Strength: {getStrength()}, its associated Color: {getColor()}");
        }
    }
//derived class
    class Sect:Faction
    {
        private string alignment;
        private double disposition;

        public Sect() 
            :base()
        {
            alignment = "";
            disposition = 0;
        }
        public Sect(string name, string color, int strength, string align, double dispo) 
            :base(name, color, strength)
        {
            alignment = align;
            disposition = dispo;
        }
        //I'm starting to find this to be very tedious
        //sets and gets for protected inheritance
        //for practice
        public string getAlign() {return this.alignment;}
        public double getDispo() {return this.disposition;}
        public void setAlign(string align) {this.alignment = align;}
        public void setDispo(double dispo) {this.disposition = dispo;}
        public override string getName() {return base.getName();}
        public override string getColor() {return base.getColor();}
        public override int getStrength() {return base.getStrength();}

        public override void addChange()
        {
            base.addChange();
            Console.Write("Faction Alignment= ");
            setAlign(Console.ReadLine());
            Console.Write("Faction Disposition= ");
            setDispo(double.Parse(Console.ReadLine()));
        }
        public override void display()
        {
            Console.WriteLine();
            base.display();
            Console.WriteLine($"This Faction's Alignment: {getAlign()}, and its Disposition towards you: {getDispo()}.");
        }

    }
    

    class Program
    {

        private static int Menu()
        {
            Console.WriteLine("Please make a selection.");
            Console.WriteLine("1-Add, 2-Change, 3-Print, 4-Quit");
            int selection = 0;
            while (selection < 1 || selection > 4)
                while (!int.TryParse(Console.ReadLine(), out selection))
                    Console.WriteLine("1-Add, 2-Change, 3-Print, 4-Quit");
            return selection;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("How Many Factions are there?");
            int maxFactions;
            while (!int.TryParse(Console.ReadLine(), out maxFactions))
                Console.WriteLine("Please enter a whole number");
            Faction[] fac = new Faction[maxFactions];
            Console.WriteLine("How Many Sects are there?");
            int maxSects;
            while (!int.TryParse(Console.ReadLine(), out maxSects))
                Console.WriteLine("Please enter a whole number");
            Sect[] sect = new Sect[maxSects];
            int choice, rec, type;
            int factCount = 0, sectCount = 0;
            choice = Menu();
            while (choice != 4)
            {
                Console.WriteLine("Enter 1 for Faction, or 2 for Sect");
                while (!int.TryParse(Console.ReadLine(), out type))
                    Console.WriteLine("1 for Faction, 2 for Sect");
                try
                {
                    switch (choice)
                    {
                        case 1:
                            if (type == 1)
                            {
                                if (factCount <= maxFactions)
                                {
                                    fac[factCount] = new Faction();
                                    fac[factCount].addChange();
                                    factCount++;
                                }
                                else
                                    Console.WriteLine("The maximum number of factions have been added.");
                            }
                            else
                            {
                                if (sectCount <=maxSects)
                                {
                                    sect[sectCount] = new Sect();
                                    sect[sectCount].addChange();
                                    sectCount++;
                                }
                                else
                                    Console.WriteLine("The Maximum number of sects have been added.");
                            }
                            break;
                        case 2:
                            Console.Write("Enter the record number you want to change: ");
                            while (!int.TryParse(Console.ReadLine(), out rec))
                                Console.Write("Enter the record number you want to change: ");
                            rec--;
                            if (type == 1)
                            {
                                while (rec > factCount - 1 || rec < 0)
                                {
                                    Console.Write("The number you entered was out of range, try again.");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("ether the record number you want to change: ");
                                    rec--;
                                }
                                fac[rec].addChange();
                            }
                            else
                            {
                                while (rec > sectCount -1 || rec < 0)
                                {
                                    Console.Write("The number you entered was out of range, try again");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter the record number you want to chage: ");
                                    rec--;
                                }
                                sect[rec].addChange();
                            }
                            break;
                        case 3:
                            if (type ==1)
                            {
                                for (int i=0; i< factCount; i++)
                                    fac[i].display();
                            }
                            else
                            {
                                for (int i = 0; i < sectCount; i++)
                                    sect[i].display();
                            }
                            break;
                        default:
                            Console.WriteLine("You made an invalid selection, please try again.");
                            break;
                    }
                }

                catch (IndexOutOfRangeException e) {Console.WriteLine(e.Message);}
                catch (FormatException e) {Console.WriteLine(e.Message);}
                catch (Exception e) {Console.WriteLine(e.Message);}
                choice = Menu();
            }
        }
    }
}