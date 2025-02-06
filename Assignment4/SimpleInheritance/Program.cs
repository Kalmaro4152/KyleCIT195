using System;
using System.Reflection;
using System.Reflection.Metadata;

namespace Inheritance
{

    // base class
    class Animal
    {
        public string name;

        // constructor
        public Animal()
        {
            name = "";

        }
        //parameterized constructor
        public Animal(string name)
        {
            this.name = name;
        }

        public void display()
        {
            Console.WriteLine($"I am an animal, my name is {name}");
        }

    }

    // derived class of Animal 
    class Snake:Animal
    {
        public string breed;
        public string morph;
        public double age;
        public Snake() :base()
        {
            breed = "";
            morph = "";
            age = 0;
        } 
        public Snake(string name, string breed, string morph, double age) :base(name)
        {
            this.breed = breed;
            this.morph = morph;
            this.age = age;
        }
        public void displayFields()
        {
            Console.WriteLine($"I am a Snake, my breed is {breed}, I am a {morph} morph, and I am {age} years old.");
        }
    }

    //second derived class
    class Cat:Animal
    {
        public double age;
        public double weight;
        public string type;
        
        public Cat() :base()
        {
            age = 0;
            weight = 0;
            type = "";
        }
        public Cat(string name, double age, double weight, string type) :base(name)
        {
            this.age = age;
            this.weight = weight;
            this.type = type;
        }
        public void displayFields()
        {
            Console.WriteLine($"I am a Cat, my type is {type}, I weigh {weight}lbs, and I am {age} years old.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // object of base class
            Animal myPet = new Animal();
            myPet.name = "Sparky";
            myPet.display();

            // derived class object using default constructor
            Snake mySnake = new Snake();
            mySnake.name = "Juno";
            mySnake.age = 13;
            mySnake.morph ="Xanthtic";
            mySnake.breed = "Ball Python";
            mySnake.display();
            mySnake.displayFields();

            //derived class object using parameterized constructor
            Snake otherSnake = new Snake("Brigette", "Hognose", "albino", 15);
            otherSnake.display();
            otherSnake.displayFields();

            //Second Derived Class
            Cat myCat = new Cat();
            myCat.name = "Jack";
            myCat.age = 8;
            myCat.weight = 20;
            myCat.type = "Shorthair";
            myCat.display();
            myCat.displayFields();

            //Parameters
            Cat extraCat = new Cat("Gabriel",2,12,"Long Hair");
            extraCat.display();
            extraCat.displayFields();
        }

    }
}