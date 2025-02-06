using System;
namespace AnimalInheritance
{
    // base Class 
    class Animal
    {
        private string name; // only accessible within this class
        protected string type; //accessible from derived classes
        public string color;  // accessible from any class

        public void setName(string name)
        {
            this.name = name;
        }
        public virtual string getName() 
        { 
            return this.name; 
        }
        public void setType(string type) 
        { 
            this.type = type; 
        }
        public virtual string getType() 
        { 
            return this.type;
        }
    }
//derived class
    class Kwama:Animal
    {
        protected string variety;
        protected double weight;
        protected double length;

        public Kwama() :base()
        {
            variety = "";
            weight = 0;
            length = 0;
        }
        public Kwama(string vari, double wei, double len) :base()
        {
            variety = vari;
            weight = wei;
            length = len;
        }
        //I'm starting to find this to be very tedious
        //sets and gets for protected inheritance
        //for practice
        public string getVariety() {return this.variety;}
        public double getWeight() {return this.weight;}
        public double getLength() {return this.length;}
        public void setVariety(string vari) {this.variety = vari;}
        public void setWeight(double wei) {this.weight = wei;}
        public void setLength(double len) {this.length = len;}
        public override string getName()
        {
        return base.getName();
        }
        public override string getType()
        {
            return base.getType();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Base Class
            Animal myPet = new Animal();
            myPet.setName("Genji");
            myPet.setType("Kwama");
            myPet.color = "White";
            Console.WriteLine($"I'm an Animal, my name is {myPet.getName()}, I am a {myPet.getType()}, and I am {myPet.color}.");

            //Derived Class
            Kwama myKwama = new Kwama("Forager", 0, 0);
            myKwama.setLength(3);
            myKwama.setWeight(80);
            myKwama.setName("Zeigler");
            myKwama.setType("Kwama");
            myKwama.color = "white";
            Console.WriteLine($"I am an Animal, my name is {myKwama.getName()}, I am a {myKwama.getType()}, I am {myKwama.color}, I weigh {myKwama.getWeight()}bamble plinths, I am a {myKwama.getVariety()}, and I am {myKwama.getLength()} doodleloos long.");

        }
    }
}