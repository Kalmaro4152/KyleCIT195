using System;
namespace AbstractAnimalClass
{
    abstract class Animal
    {
        //property
        public abstract string Name {get;set;}
         // Methods
        public abstract string Describe();
        public string whatAmI()
        {
            return "I am an animal";
        }
    }

    class Hound : Animal
    {
        public override string Name{get;set;}
        public string Color{get;set;}
        public int Legs{get;set;}

        public Hound()
        {
            Name = "";
            Color = "";
            Legs = 4;
        }
        public Hound(string name, string color, int legs)
        {
            Name = name;
            Color = color;
            Legs = legs;
        }

        public override string Describe()
        {
            return $"My name is {Name}, I am {Color} and I have {Legs} legs.";
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            Hound nix = new Hound("Jeremy", "green", 6);
            Hound beagle = new Hound();
            Console.WriteLine(nix.Describe());
            beagle.Color = "brown";
            beagle.Name = "Houston";
            beagle.Legs = 3;
            Console.WriteLine(beagle.Describe());
        }
    }
}