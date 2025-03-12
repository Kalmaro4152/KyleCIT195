using System.Text.RegularExpressions;

namespace LinqMethod
{
    public class Student{
    public int StudentID { get; set; }
    public string StudentName { get; set; }
    public int Age { get; set; }
    public string Major { get; set; }
	public double Tuition {get;set;}
    }
    public class StudentClubs
    {
        public int StudentID { get; set; }
        public string ClubName { get; set; }
    }
    public class StudentGPA
    {
        public int StudentID { get; set;}
        public double GPA    { get; set;}
    }

    public class Program
    {
        static void Main()
        {
            // Student collection
            IList < Student > studentList = new List < Student >() { 
                new Student() { StudentID = 1, StudentName = "Frank Furter", Age = 55, Major="Hospitality", Tuition=3500.00} ,
                new Student() { StudentID = 2, StudentName = "Gina Host", Age = 21, Major="Hospitality", Tuition=4500.00 } ,
                new Student() { StudentID = 3, StudentName = "Cookie Crumb",  Age = 21, Major="CIT", Tuition=2500.00 } ,
                new Student() { StudentID = 4, StudentName = "Ima Script",  Age = 48, Major="CIT", Tuition=5500.00 } ,
                new Student() { StudentID = 5, StudentName = "Cora Coder",  Age = 35, Major="CIT", Tuition=1500.00 } ,
                new Student() { StudentID = 6, StudentName = "Ura Goodchild" , Age = 40, Major="Marketing", Tuition=500.00} ,
                new Student() { StudentID = 7, StudentName = "Take Mewith" , Age = 29, Major="Aerospace Engineering", Tuition=5500.00 }
            };
            // Student GPA Collection
            IList < StudentGPA > studentGPAList = new List < StudentGPA > () {
                new StudentGPA() { StudentID = 1,  GPA=4.0} ,
                new StudentGPA() { StudentID = 2,  GPA=3.5} ,
                new StudentGPA() { StudentID = 3,  GPA=2.0 } ,
                new StudentGPA() { StudentID = 4,  GPA=1.5 } ,
                new StudentGPA() { StudentID = 5,  GPA=4.0 } ,
                new StudentGPA() { StudentID = 6,  GPA=2.5} ,
                new StudentGPA() { StudentID = 7,  GPA=1.0 }
            };
            // Club collection
            IList < StudentClubs > studentClubList = new List < StudentClubs >() {
                new StudentClubs() {StudentID=1, ClubName="Photography" },
                new StudentClubs() {StudentID=1, ClubName="Game" },
                new StudentClubs() {StudentID=2, ClubName="Game" },
                new StudentClubs() {StudentID=5, ClubName="Photography" },
                new StudentClubs() {StudentID=6, ClubName="Game" },
                new StudentClubs() {StudentID=7, ClubName="Photography" },
                new StudentClubs() {StudentID=3, ClubName="PTK" },
            };

            //group by gpa and display studentID
            Console.WriteLine("Studnet GPAs");
            var result = studentGPAList.OrderBy(g => g.GPA).GroupBy(g => g.GPA);
            foreach(var item in result)
            {
                Console.WriteLine(item.Key);
                foreach(StudentGPA g in item)
                {
                    Console.WriteLine("StudentID: " + g.StudentID);
                    Console.WriteLine("Student GPA: " + g.GPA);
                }
            }
            Console.WriteLine();

            //sort by club, group by club, display IDs
            Console.WriteLine("Student Clubs");
            var clubResult = studentClubList.OrderBy(x => x.ClubName).GroupBy(g => g.ClubName);
            foreach (var item in clubResult)
            {
                Console.WriteLine(item.Key);
                foreach(StudentClubs c in item)
                {
                    Console.WriteLine("student ID: " + c.StudentID);
                }
            }
            Console.WriteLine();

            //Count Students with GPA between 2.5 and 4.0
            Console.WriteLine("Students with 2.5 - 4.0 GPA");
            var gpaResult = studentGPAList.Where(g => g.GPA >= 2.5 && g.GPA <= 4.0).Count();
            Console.WriteLine(gpaResult);
            Console.WriteLine();

            //Average all tuitions
            Console.WriteLine("Average Tuition");
            var averageCost = studentList.Average(t => t.Tuition);
            Console.WriteLine(Math.Round(averageCost, 2));
            Console.WriteLine();

            //find student paying most, display name major tuition. Display all who match.
            Console.WriteLine("Most Tuition");
            var mostTuition = studentList.Max(t => t.Tuition);
            foreach(var item in studentList)
            {
                if(item.Tuition == mostTuition)
                {
                    Console.WriteLine($"{item.StudentName} {item.Major} {item.Tuition}");
                }
            }
            Console.WriteLine();

            //join student list and student gpa list on StudentID, display name major gpa
            Console.WriteLine("Student Name, Major, GPA");
            var innerJoin = studentList.Join(studentGPAList, student => student.StudentID, gpa => gpa.StudentID,
                (student, gpa) => new {name = student.StudentName, grade=gpa.GPA, major = student.Major });
            foreach(var item in innerJoin)
            {
                Console.WriteLine($"{item.name} - {item.major} - {item.grade}");
            }
            Console.WriteLine();

            //join student/club lists. Display only those in game club
            Console.WriteLine("Gamers");
            var studentJoin = studentList.Join(studentClubList, student => student.StudentID, club => club.StudentID,
                (student, club) => new {name = student.StudentName, club = club.ClubName});
            
            foreach(var item in studentJoin)
            {
                if(item.club == "Game")
                {
                    Console.WriteLine(item.name);
                }
            }
        }
    }
}