using System.Runtime.CompilerServices;

namespace LinqQuery
{
    public class famousPeople
    {
        public string Name { get; set; } = string.Empty;
        public int? BirthYear { get; set; } = null;
        public int? DeathYear { get; set; } = null;
    }
    
    public class Program
    {
        static void Main()
        {
            IList < famousPeople > stemPeople = new List < famousPeople >() {
            new famousPeople() { Name= "Michael Faraday", BirthYear=1791,DeathYear=1867 },
            new famousPeople() { Name= "James Clerk Maxwell", BirthYear=1831,DeathYear=1879 },
            new famousPeople() { Name= "Marie Skłodowska Curie", BirthYear=1867,DeathYear=1934 },
            new famousPeople() { Name= "Katherine Johnson", BirthYear=1918,DeathYear=2020 },
            new famousPeople() { Name= "Jane C. Wright", BirthYear=1919,DeathYear=2013 },
            new famousPeople() { Name = "Tu YouYou", BirthYear= 1930 },
            new famousPeople() { Name = "Françoise Barré-Sinoussi", BirthYear=1947 },
            new famousPeople() {Name = "Lydia Villa-Komaroff", BirthYear=1947},
            new famousPeople() {Name = "Mae C. Jemison", BirthYear=1956},
            new famousPeople() {Name = "Stephen Hawking", BirthYear=1942,DeathYear=2018 },
            new famousPeople() {Name = "Tim Berners-Lee", BirthYear=1955 },
            new famousPeople() {Name = "Terence Tao", BirthYear=1975 },
            new famousPeople() {Name = "Florence Nightingale", BirthYear=1820,DeathYear=1910 },
            new famousPeople() {Name = "George Washington Carver", BirthYear=1866, DeathYear=1943 },
            new famousPeople() {Name = "Frances Allen", BirthYear=1932,DeathYear=2020 },
            new famousPeople() {Name = "Bill Gates", BirthYear=1955 }
            };

            //results with birthdates after 1900
            var result = from s in stemPeople
                where s.BirthYear > 1900
                select s;
            Console.WriteLine("People born after 1900.");
            foreach(var item in result)
            {
                Console.WriteLine($"{item.Name}");
            }

            //results with two lowercase L's in Name
            result = from s in stemPeople
                where s.Name.Contains("ll")
                select s;
            Console.WriteLine();
            Console.WriteLine("People with double L in name");
            foreach(var item in result)
            {
                Console.WriteLine(item.Name);
            }

            //birthdays after 1950
            result = from s in stemPeople
                where s.BirthYear > 1950
                select s;
            Console.WriteLine();
            Console.WriteLine(result.Count() + " people born after 1950.");

            //birthdays between 1920 and 2000. display names, count.
            result = from s in stemPeople
                where s.BirthYear >= 1920 && s.BirthYear <= 2000
                select s;
            Console.WriteLine();
            Console.WriteLine(result.Count() + " People born between 1920 and 2000");
            foreach(var item in result)
            {
                Console.WriteLine(item.Name);
            }

            // sort list by birthyear
            result = from s in stemPeople
                orderby s.BirthYear descending
                select s;
            Console.WriteLine();
            Console.WriteLine("Birth Years");
            foreach(var item in result)
            {
                Console.WriteLine($"{item.Name}: {item.BirthYear}");
            }

            //Dead people between 1960 and 2015 ascending order
            result = from s in stemPeople
                where s.DeathYear >= 1960 && s.DeathYear <= 2015
                orderby s.DeathYear ascending
                select s;
            Console.WriteLine();
            Console.WriteLine("Death Year 1960 - 2015");
            foreach(var item in result)
            {
                Console.WriteLine($"{item.Name}: {item.DeathYear}");
            }
        }
    }
}