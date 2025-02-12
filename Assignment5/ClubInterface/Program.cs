using System;
namespace ClubInterface
{
        interface IClub
    {
        //Properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Methods
        public string Fullname();
    }
    class Program
    {
        class RunningClub : IClub
        {
            public int Id{get;set;}
            public string FirstName{get;set;}
            public string LastName{get;set;}
            public double BestTime { get; set; }
            public string Quote { get; set;}
            public int Placement {get;set;}

            public RunningClub()
            {
                Id = 0;
                FirstName = "";
                LastName="";
                BestTime=0;
                Quote="";
                Placement=0;
            }
            public RunningClub(int Id, string first, string last, double best, string quote, int place)
            {
                this.Id = Id;
                FirstName = first;
                LastName = last;
                BestTime = best;
                this.Quote = quote;
                Placement = place;
            }
            public string Fullname()
            {
                return FirstName + " " + LastName;
            }

            public void DisplayMember()
            {
                Console.WriteLine($"Name: {Fullname()}");
                Console.WriteLine($"Member ID: {Id}");
                Console.WriteLine($"Quote: '{Quote}'");
                Console.WriteLine($"Best Time: {BestTime}");
                Console.WriteLine($"Current Placement: {Placement}");
            }
        }
        static void Main(string[] args)
        {
            RunningClub run = new RunningClub(12, "Kyle", "Morrill", 12.12, "2Fast2Quick", 17);
            run.DisplayMember();
        }
    }
}        