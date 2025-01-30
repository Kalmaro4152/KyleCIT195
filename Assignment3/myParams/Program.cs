using System;

class Program
{
    static void Main(string[] args)
    {
        Random r = new Random();
        Console.WriteLine("How many random numbers would you like to generate?");
        int genNums = int.Parse(Console.ReadLine());
        int[] numbers = new int[genNums];
        for(int i = 0; i<numbers.Length; i++)
        {
            numbers[i] = r.Next(1,10);
        }
        Console.WriteLine("The following numbers were generated:");
        foreach(int num in numbers)
        {
            Console.Write($"{num} ");
        }
        Console.WriteLine();
        Console.WriteLine($"Added together they equal {Add(numbers)}");
        Console.WriteLine($"Multiplied together they equal {Multiply(numbers)}");
    }
    static int Add(params int[] numbers)
    {
        int total = 0;
        foreach (int number in numbers)
        {
            total += number;
        }
        return total;
    }
    static int Multiply(params int[] numbers)
    {
        int total = 1;
        foreach (int number in numbers)
        {
            total *= number;
        }
        return total;
    }
}
