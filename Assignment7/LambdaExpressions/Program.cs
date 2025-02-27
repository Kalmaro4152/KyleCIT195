using System;
using System.ComponentModel;

namespace LambdaExpressions
{
    class program
    {
        static void Main(string[] args)
        {
            double numOne;
            double numTwo;
            Console.Write("Enter your first double: ");
            while(!double.TryParse(Console.ReadLine(), out numOne))
            {
                Console.Write("Enter a valid number: ");
            }
            Console.Write("Enter your second double: ");
            while(!double.TryParse(Console.ReadLine(), out numTwo))
            {
                Console.Write("Enter a valid number: ");
            }
            var sum = (double x, double y) => x + y;
            var multiplier = (double x, double y) => x * y;
            var larger = (double x, double y) => 
            {
                if (x>y)
                    return x;
                else
                    return y;
            };

            Console.WriteLine($"Numbers in use: {numOne}, {numTwo}.");
            Console.WriteLine($"The sum is: {sum(numOne, numTwo)}.");
            Console.WriteLine($"The product is: {multiplier(numOne, numTwo)}.");
            Console.WriteLine($"{larger(numOne, numTwo)} is the larger number.");
            Console.WriteLine();
        }
    }
}