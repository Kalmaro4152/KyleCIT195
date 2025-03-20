using System.Globalization;
using System.Security.Cryptography;

namespace OperatorOverloadingEx1
{
    public class Calculator
    {
        public int number { get; set; }

        // Overload unary operators ++ and -- 
        public static Calculator operator ++(Calculator obj)
        {
            ++obj.number;
            return obj;
        }
        public static Calculator operator --(Calculator obj)
        {
            --obj.number;
            return obj;
        }
        // Overload Comparison Operators > and <
        public static bool operator >(Calculator left, Calculator right)
        {
            bool larger = false;
            if (left.number > right.number)
                larger = true;
            return larger;
        }
        public static bool operator <(Calculator left, Calculator right)
        {
            bool smaller = false;
            if (left.number < right.number)
                smaller = true;
            return smaller;
        }

        // Overload Binary Operators + and -
        public static Calculator operator +(Calculator left, Calculator right)
        {
            Calculator Calc3 = new Calculator();
            Calc3.number = left.number + right.number;
            return Calc3;
        }
        public static Calculator operator - (Calculator left, Calculator right)
        {
            Calculator calc = new Calculator();
            calc.number = left.number + right.number;
            return calc;
        }

        static void Main(string[] args)
        {
            Random r = new Random();
            // create object array
            Calculator[] numbers = new Calculator[10];
            // place random numbers into array and print values
            Console.Write("Original Numbers= ");
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = new Calculator(); // creates the object
                numbers[i].number = r.Next(1, 100);  // places a value in the object
                Console.Write(" " + numbers[i].number);
            }
            Console.WriteLine();
            // if divisible by 2, add 1 to value using operator ++ method
            // otherwise subtract 1 from value using operator -- method
            Console.Write("New Numbers +1 or -1= ");
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i].number % 2 == 0)
                {
                    numbers[i]++;
                }
                else
                {
                    numbers[i]--;
                }
                Console.Write(" " + numbers[i].number);
            }   
            Console.WriteLine();

            // random Calculator object to add
            Calculator numToAdd = new Calculator();
            numToAdd.number = r.Next(1, 20);

            // Using operator +, add numToAdd.number to each element in the array 
            // Print the results

            // Insert a for loop that adds numToAdd to numbers[i]
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = numbers[i] + numToAdd;
                Console.WriteLine($"Numbers + {numToAdd.number} ={numbers[i].number}");
            }

            Console.WriteLine();

            // random Calculator object to subtract
            Calculator numToSub = new Calculator();
            numToSub.number = r.Next(1, 20);
            // Using operator -, subtract numToSub.number from each element in the array
            // Print the results

            // Insert a for loop that subtracts numToSub from numbers[i]
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = numbers[i] - numToAdd;
                Console.WriteLine($"Numbers - {numToSub.number} ={numbers[i].number}");
            }

            
            Console.WriteLine();

            // random Calculator object for comparison
            Calculator numToCompare = new Calculator();
            numToCompare.number = r.Next(1, 100);
            // Using operator > and operator <, compare each element to numToCompare.number
            // print if the element is higher, lower or equal to the number you are comparing to
            Console.WriteLine($"Numbers above or below {numToCompare.number}");

            // Insert a for loop
            // Inside the for loop insert a nested if/else that checks numbers[i] > numberToCompare
            // followed by a message that the number is higher
            // Then it should check numbers[i] < numToCompare 
            // followed by a message that the number is lower
            // if the number isn't higher or lower, the message should indicate they are equal
            for (int i = 0; i<numbers.Length; i++)
            {
                if (numbers[i] > numToCompare) Console.WriteLine($"{numbers[i].number} is greater than {numToCompare.number}");
                else if (numbers[i] < numToCompare) Console.WriteLine($"{numbers[i].number} is less than {numToCompare.number}");
                else Console.WriteLine($"{numbers[i].number} is equal to {numToCompare.number}");
            }
        }
    }
}