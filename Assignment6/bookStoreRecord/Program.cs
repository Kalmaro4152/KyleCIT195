using System;
namespace bookStoreRecord
{
    class Program
    {
        public record Bookstore(int ID, string Title, string Author, double Price);
        public static void Main()
        {
            Bookstore book = new(5, "Of Mice and Men", "Who wrote it again?", 6.00);
            Bookstore book2 = new(10, "Ready Player One", "Some Dude", 10.00);
            Bookstore book3 = new(15, "The Color of Magic", "Terry Practett", 12.00);
            Console.WriteLine(book);
            Console.WriteLine(book2);
            Console.WriteLine(book3);
        }
    }
}