using System;
namespace GenericAnimalClass
{
    public class Animal <T>
    {
        public T Data;
        public Animal(T data)
        {
            this.Data=data;
        }
        public T getAnimal()
        {
            return Data;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Animal <string> animalName = new Animal<string>("Kwama");
            Animal <string> animalHabitat = new Animal<string>("Caverns");
            Animal <bool> endangered = new Animal<bool>(false);
            Animal <bool> extinct = new Animal<bool>(false);
            Animal <int> averageLifespan = new Animal<int>(2);
            Console.WriteLine(animalName.getAnimal());
            Console.WriteLine(animalHabitat.getAnimal());
            Console.WriteLine(endangered.getAnimal());
            Console.WriteLine(extinct.getAnimal());
            Console.WriteLine(averageLifespan.getAnimal());
        }
    }
}