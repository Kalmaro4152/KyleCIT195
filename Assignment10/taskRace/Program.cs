namespace threadRace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Read, Set Go...");
            int t1Location = 0;
            int t2Location = 0;
            int t3Location = 0;
            int t4Location = 0;
            int t5Location = 0;

            //Creating Threads
            Task t1 = Task.Run(() =>
            {
                Thread.CurrentThread.Name = "Speedy Gonzales";
                for (int i = 0; i < 100; i++)
                {
                    if (t1Location < 100 && t2Location < 100)
                        MoveIt(ref t1Location);
                }

            });
            Task t2 = Task.Run(() =>
            {
                Thread.CurrentThread.Name = "Road Runner";
                for (int i = 0; i < 100; i++)
                {
                    if (t1Location < 100 && t2Location < 100)
                        MoveIt(ref t2Location);

                }
            });

            Task t3 = Task.Run(() =>
            {
                Thread.CurrentThread.Name = "Pemenie";
                for (int i = 0; i< 100; i++)
                {
                    if (t3Location < 100 && t2Location < 100)
                        MoveIt(ref t3Location);
                }
            });
            Task t4 = Task.Run(() =>
            {
                Thread.CurrentThread.Name = "Tracer";
                for (int i = 0; i< 100; i++)
                {
                    if (t4Location < 100 && t3Location < 100)
                        MoveIt(ref t4Location);
                }
            });
            Task t5 = Task.Run(() =>
            {
                Thread.CurrentThread.Name = "Scout";
                for (int i = 0; i< 100; i++)
                {
                    if (t4Location < 100 && t5Location < 100)
                        MoveIt(ref t5Location);
                }
            });

            //Executing the methods
            Task.WaitAny(t5);
            Console.WriteLine("Race has ended");
        }
        static void MoveIt(ref int location)
        {
            location++;
            Console.WriteLine($"{Thread.CurrentThread.Name} location={location}");
            if (location >= 100)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} is the winner");
                return;
            }
        }

    }
}