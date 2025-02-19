using System;
namespace clubMemberIndexer
{
    class Program
    {
        public const int Size = 15;
        class ClubMembers
        {
            private string[] Members = new string[Size];
            public string ClubType {get; set;}
            public string ClubLocation {get;set;}
            public string MeetingDate{get;set;}
            public ClubMembers()
            {
                for (int i = 0; i < Size; i++)
                {
                    Members[i] = string.Empty;
                }
                ClubType = string.Empty;
                ClubLocation=string.Empty;
                MeetingDate=string.Empty;
            }
            public string this [int index]
            {
                get
                {
                    string tmp;
                    if (index >= 0 && index <= Size -1)
                    {
                        tmp = Members[index];
                    }
                    else
                    {
                        tmp="";
                    }
                    return (tmp);
                }
                set
                {
                    if (index >= 0 && index <= Size - 1)
                    {
                        Members[index] = value;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            ClubMembers club = new ClubMembers();
            bool end = false;
            while (!end)
            {
                int sub=0;
                while (sub > Size || sub < 1)
                {
                    Console.WriteLine($"Which club member do you want to enter (enter 1-{Size})?");
                    while (!int.TryParse(Console.ReadLine(), out sub))
                        Console.WriteLine($"Enter a value between 1-{Size}.");
                }
                Console.WriteLine("Enter a club member:");
                club [sub-1] = Console.ReadLine();
                Console.WriteLine("Press any key to continue, q to stop");
                string stop = Console.ReadLine();
                if (stop == "q")
                    end =true;
            }
            Console.WriteLine("What is the club type?");
            club.ClubType = Console.ReadLine();
            Console.WriteLine("Where is the club located?");
            club.ClubLocation = Console.ReadLine();
            Console.WriteLine("When does the club meet?");
            club.MeetingDate = Console.ReadLine();

            Console.WriteLine($"Here is information about your club");
            Console.WriteLine("Club Members");
            for (int i = 0; i < Size; i++)
            {
                if (club[i] != string.Empty)
                    Console.WriteLine(club[i]);
            }
            Console.WriteLine($"Club Location: {club.ClubLocation}");
            Console.WriteLine($"Club Meeting Date: {club.MeetingDate}");
            Console.WriteLine($"Club Type: {club.ClubType}");
        }
    }
    
}