using System;
using System.ComponentModel;
namespace MoreOverloading
{
    public class firepower
    {
        public string weapon {get;set;}
        public int power{get;set;}
        public double rate{get;set;}

        public static firepower operator +(firepower gun1, firepower gun2)
        {
            firepower gun3 = new firepower();
            gun3.power = gun1.power + gun1.power;
            gun3.rate = gun1.rate + gun2.rate;
            return gun3;
        }
        public static firepower operator ++(firepower gun)
        {
            gun.power += gun.power;
            gun.rate += gun.power;
            return gun;
        }
        public static bool operator >(firepower gun1, firepower gun2)
        {
            bool result = false;
            double totalPower1 = gun1.rate * gun1.power;
            double totalPower2 = gun2.rate * gun2.power;
            if (totalPower1 > totalPower2) result = true;
            return result;
        }
        public static bool operator <(firepower gun1, firepower gun2)
        {
            bool result = false;
            double totalPower1 = gun1.rate * gun1.power;
            double totalPower2 = gun2.rate * gun2.power;
            if (totalPower1 < totalPower2) result = true;
            return result;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            firepower[] gadgetron = new firepower[2];
            firepower[] megacorp = new firepower[2];

            for (int i = 0; i < gadgetron.Length; i++)
            {
                gadgetron[i] = new firepower();
                megacorp[i] = new firepower();
            }

            //gadgetron weapon data
            int gadgetronCounter = 0;
            Console.WriteLine("Enter data for your Gadgetron arsenal.");
            while (true)
            {
                Console.Write($"Enter weapon {gadgetronCounter + 1}'s name: ");
                gadgetron[gadgetronCounter].weapon = Console.ReadLine();

                bool valid = false;
                int result;
                while (!valid)
                {
                    Console.Write("Enter the power of this weapon: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out result)) {valid = true; gadgetron[gadgetronCounter].power = result;}
                    else Console.WriteLine("Invalid number");
                }
                
                valid = false;
                double result1;
                while (!valid)
                {
                    Console.Write("Enter the rate of fire for this weapon: ");
                    string input = Console.ReadLine();
                    if (double.TryParse(input, out result1)) {valid = true; gadgetron[gadgetronCounter].rate = result1;}
                    else Console.WriteLine("Invalid number");
                }

                if (gadgetronCounter == 1) break;
                gadgetronCounter++;
            }

            int megacorpCounter = 0;
            Console.WriteLine("Enter your Megacorp Arsenal");
            while (true)
            {
                Console.Write($"Enter the weapon {megacorpCounter + 1}'s name: ");
                megacorp[megacorpCounter].weapon = Console.ReadLine();

                bool valid = false;
                int result;
                while (!valid)
                {
                    Console.Write("Enter the power of this weapon: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out result)) {valid = true; megacorp[megacorpCounter].power = result;}
                    else Console.WriteLine("Invalid number");
                }
                
                valid = false;
                double result1;
                while (!valid)
                {
                    Console.Write("Enter the rate of fire for this weapon: ");
                    string input = Console.ReadLine();
                    if (double.TryParse(input, out result1)) {valid = true; megacorp[megacorpCounter].rate = result1;}
                    else Console.WriteLine("Invalid number");
                }

                if (megacorpCounter == 1) break;
                megacorpCounter++;
            }
            Console.WriteLine();

            Console.WriteLine("Gadgetron Arsenal");
            foreach (var gun1 in gadgetron)
            {
                Console.WriteLine($"Weapon: {gun1.weapon}");
                Console.WriteLine($"Power: {gun1.power}");
                Console.WriteLine($"Rate of Fire: {gun1.rate}");
            }
            Console.WriteLine();

            Console.WriteLine("Megacorp Arsenal");
            foreach (var gun2 in megacorp)
            {
                Console.WriteLine($"Weapon: {gun2.weapon}");
                Console.WriteLine($"Power: {gun2.power}");
                Console.WriteLine($"Rate of Fire: {gun2.rate}");
            }
            Console.WriteLine();

            //using Overloaded ><
            for (int i = 0; i < 2; i++)
            {
                if (megacorp[i] > gadgetron[i]) Console.WriteLine($"{megacorp[i].weapon} is stronger than {gadgetron[i].weapon}");
                else if (megacorp[i] < gadgetron[i]) Console.WriteLine($"{megacorp[i].weapon} is weaker than {gadgetron[i].weapon}");
                else Console.WriteLine($"{megacorp[i].weapon} is the same power as {gadgetron[i].weapon}");
            }
            //using ++ and +
            firepower gun3 = new firepower();
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine($"Doubling fire power of weapons");
                gadgetron[i]++;
                megacorp[i]++;
                Console.WriteLine($"Weapon: {gadgetron[i].weapon}");
                Console.WriteLine($"Power: {gadgetron[i].power}");
                Console.WriteLine($"Rate of Fire: {gadgetron[i].rate}");
                Console.WriteLine();
                
                Console.WriteLine($"Weapon: {megacorp[i].weapon}");
                Console.WriteLine($"Power: {megacorp[i].power}");
                Console.WriteLine($"Rate of Fire: {megacorp[i].rate}");
                Console.WriteLine();
                
                Console.WriteLine("Combing Weapons");
                gun3 = gadgetron[i] + megacorp[i];
                Console.WriteLine("New weapon:");
                Console.WriteLine($"Power: {gun3.power}");
                Console.WriteLine($"Rate: {gun3.rate}");
                Console.WriteLine();
            }
        }
    }
}