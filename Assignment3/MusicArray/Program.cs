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

            /*public Music(string title, string artist, string album, int length, Genre genre)
            {
                _Title = title;
                _Artist = artist;
                _Album = album;
                _Length = length;
                _Genre = genre;
            }*/


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
            Genre genre = Genre.Rock;
            Console.WriteLine("How many songs would you like to enter?");
            int size = int.Parse(Console.ReadLine());
            Music[] collection = new Music[size];
            try
            {

            
                for (int i=0; i<size; i++)
                {
                Console.WriteLine($"What is the Genre of song number {i+1}?\nR = Rock, E = EDM, P = Pop, C = Classical, J = Jazz");
                char g = char.Parse(Console.ReadLine());
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
                collection[i].SetGenre(genre);
                }
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
            }
            try
            {
                for (int i=0; i<size; i++)
                {
                Console.WriteLine($"What is the title of song {i+1}?");
                collection[i].SetTitle(Console.ReadLine());
                }
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
            }
            try
            {
                for (int i=0; i<size; i++)
                {
                Console.WriteLine($"What is the Artist of song {i+1}?");
                collection[i].SetArtist(Console.ReadLine());
                }
            }
             catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
            }
            try
            {
                for (int i=0; i<size; i++)
                {
                Console.WriteLine($"What is the album of song {i+1}?");
                collection[i].SetAlbum(Console.ReadLine());
                }
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
            }
            try
            {
                for (int i=0; i<size; i++)
                {
                Console.WriteLine($"What is the length of song {i+1}?");
                collection[i].SetLength(int.Parse(Console.ReadLine()));
                }
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
            }
            for(int i=0; i<size; i++)
            {
                Console.WriteLine($"Song Number {i+1} is:\n{collection[i].Display()}");
            }
        }
    }
}
