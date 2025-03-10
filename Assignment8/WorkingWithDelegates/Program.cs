namespace Assignment8ex2
{   
    public class MathSolutions
    {
        public double GetSum(double x, double y)
        {
            return x + y;
        }
        public double GetProduct(double a, double b)
        {
            return a * b;
        }
        public void GetSmaller(double a, double b)
        {
            if (a < b)
                Console.WriteLine($" {a} is smaller than {b}");
            else if (b < a)
                Console.WriteLine($" {b} is smaller than {a}");
            else
                Console.WriteLine($" {b} is equal to {a}");
        }
        static void Main(string[] args)
        {
            // create a class object
            MathSolutions answer = new MathSolutions();
            //declare delegates???
            Func<double, double, double> summer = answer.GetSum;
            Func<double, double, double> multi = answer.GetProduct;
            Action<double, double> smallie = answer.GetSmaller;
            Random r= new Random();
            double num1 = Math.Round(r.NextDouble()*100);
            double num2 = Math.Round(r.NextDouble()*100);
            Console.WriteLine($" {num1} + {num2} = {summer(num1,num2)}");
            Console.WriteLine($" {num1} * {num2} = {multi(num1, num2)}");
            smallie(num1, num2);
        }
    }
}