using System;
namespace FunWithMusic
{
    class Program
    {
        enum Genre
        {
            Rock, EDM, Pop, Classical, Jazz
        }
        struct Music
        {
            private string _Title;
            private string _Artist;
            private string _Album;
            private int _Length;
            private Genre? _Genre;

            public Music(string title, string artist, string album, int length, Genre genre)
            {
                _Title = title;
                _Artist = artist;
                _Album = album;
                _Length = length;
                _Genre = genre;
            }
            public void SetTitle(string title)
            {
                _Title = title;
            }
            public void SetArtist(string artist)
            {
                _Artist = artist;
            }
            public void SetAlbum(string album)
            {
                _Album = album;
            }
            public void SetLength(int length)
            {
                _Length = length;
            }
            public void SetGenre(Genre genre)
            {
                _Genre = genre;
            }

            public string Display()
            {
                return "Title: " + _Title + "\nArtist: " + _Artist + "\nAlbum: " + _Album + "\nLength: " + _Length + "\nGenre: " + _Genre;
            }
        }
        static void Main(string[] args)
        {
            string title;
            string artist;
            string album;
            int length;
            Genre genre = Genre.Rock;
            Console.WriteLine("What is the Genre of your favorite song?\nR = Rock, E = EDM, P = Pop, C = Classical, J = Jazz");
            char g = char.Parse(Console.ReadLine());
            switch(g)
            {
                case 'R':
                    genre = Genre.Rock;
                    break;
                case 'E':
                    genre = Genre.EDM;
                    break;
                case 'P':
                    genre = Genre.Pop;
                    break;
                case 'C':
                    genre = Genre.Classical;
                    break;
                case 'J':
                    genre = Genre.Jazz;
                    break;
            }
            Console.WriteLine("What is the title of your favorite song?");
            title = Console.ReadLine();
            Console.WriteLine("What is the artist of your favorite song?");
            artist = Console.ReadLine();
            Console.WriteLine("What album is your favorite song from?");
            album = Console.ReadLine();
            Console.WriteLine("How long in seconds is your favorite song?");
            length = int.Parse(Console.ReadLine());
            Music music = new Music(title, artist, album, length, genre);
            Console.WriteLine($"{music.Display()}");

            Music moreMusic = new Music();
            
            Console.WriteLine("What is the Genre of your favorite song?\nR = Rock, E = EDM, P = Pop, C = Classical, J = Jazz");
            g = char.Parse(Console.ReadLine());
            switch(g)
            {
                case 'R' or 'r':
                    genre = Genre.Rock;
                    break;
                case 'E' or 'e':
                    genre = Genre.EDM;
                    break;
                case 'P' or 'p':
                    genre = Genre.Pop;
                    break;
                case 'C' or 'c':
                    genre = Genre.Classical;
                    break;
                case 'J' or 'j':
                    genre = Genre.Jazz;
                    break;
            }
            moreMusic.SetGenre(genre);
            Console.WriteLine("What is the title of your favorite song?");
            moreMusic.SetTitle(Console.ReadLine());
            Console.WriteLine("What is the artist of your favorite song?");
            moreMusic.SetArtist(Console.ReadLine());
            Console.WriteLine("What album is your favorite song from?");
            moreMusic.SetAlbum(Console.ReadLine());
            Console.WriteLine("How long in seconds is your favorite song?");
            moreMusic.SetLength(int.Parse(Console.ReadLine()));
            Console.WriteLine($"{moreMusic.Display()}");
        }
    }
}
