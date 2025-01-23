using System;
using System.Transactions;

namespace bookStore
{
    class Book
    {
        private int _Id;
        private static int _Transactions = 0;
        private string _Title;
        private string _Author;

        public Book()
        {
            _Id = 0;
            _Title = null;
            _Author = null;
        }
        public Book(int Id, string Title, string Author)
        {
            _Id = Id;
            _Title = Title;
            _Author = Author;
        }

        public int GetId()
        {
            return _Id;
        }
        public int GetTrans()
        {
            return _Transactions;
        }
        public string GetTitle()
        {
            return _Title;
        }
        public string GetAuthor()
        {
            return _Author;
        }
        public void SetId(int iden)
        {
            _Id = iden;
        }
        public void SetTrans()
        {
            _Transactions++;
        }
        public void SetTitle(string title)
        {
            _Title = title;
        }
        public void SetAuthor(string author)
        {
            _Author = author;
        }
    }

    class myStore
    {
        static void displayBooks(Book novel)
        {
            Console.WriteLine("Here's info about your book!");
            Console.WriteLine($"Book ID: {novel.GetId()}");
            Console.WriteLine($"Book Title: {novel.GetTitle()}");
            Console.WriteLine($"Book Author: {novel.GetAuthor()}");
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            //Default Book Block
            Book defaultBook = new Book();
            defaultBook.SetTrans(); // Static Field Call
            defaultBook.SetId(1);
            defaultBook.SetTitle("Desmond's Big Day");
            defaultBook.SetAuthor("Desomnd Nickles");

            //User Book Block
            Book usrBook = new Book();
            usrBook.SetTrans(); //Stati Field Call
            Console.WriteLine("Please enter a Book ID: ");
            usrBook.SetId(int.Parse(Console.ReadLine()));
            Console.WriteLine("Please enter a title: ");
            usrBook.SetTitle(Console.ReadLine());
            Console.WriteLine("Please enter an Author: ");
            usrBook.SetAuthor(Console.ReadLine());

            //Parameterized Book Block
            Book paramBook = new Book(9187, "Best Book", "Cool Dude");
            paramBook.SetTrans(); //Static Field Call

            //Parameterized Book Block but Custom
            Console.WriteLine("Please enter a Book ID: ");
            int bookID = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter a title: ");
            string bookTitle = Console.ReadLine();
            Console.WriteLine("Please enter an Author: ");
            string bookAuthor = Console.ReadLine();
            Book customBook = new Book(bookID, bookTitle, bookAuthor);
            customBook.SetTrans(); //Static Field Call
            
            //Get those trans(actions)
            Console.WriteLine();
            Console.WriteLine($"The total number of transactions is: {customBook.GetTrans()}.");
            Console.WriteLine();
            
            //Call the books forth
            displayBooks(defaultBook);
            displayBooks(usrBook);
            displayBooks(paramBook);
            displayBooks(customBook);
        }

    }
}