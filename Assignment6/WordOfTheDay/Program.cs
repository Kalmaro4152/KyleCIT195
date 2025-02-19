using System;
using System.IO;
using System.Xml.Serialization;

namespace WordOfTheDay
{
    internal class Program
    {
        static void Main()
        {
            int choice = Menu();
            while (choice != 5)
            {
                switch (choice)
                {
                    case 1:
                       AppendToFile();
                        break;
                    case 2:
                        ReadFile();
                        break;
                    case 3:
                        ReadToArray();
                        break;
                    case 4:
                        try
                        {
                            string path = "Words.txt";
                            if (File.Exists(path))
                            {
                                File.Delete(path);
                                Console.WriteLine("File deleted successfully.");
                            }
                            else
                            {
                                Console.WriteLine("File does not exist.");
                            }
                        }
                        catch (IOException ex)
                        {
                            Console.WriteLine("An error occurred: " + ex.Message);
                        }
                        break;
                }
                choice = Menu();
            }

        }
        static int Menu()
        {
            Console.WriteLine("Enter your choice:\n1. Add Word\n2. Read All\n" +
                "3. Read Current Word\n4. Delete File\n5. Exit");
            int choice = 0;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
            }
            return choice;
        }
        static void AppendToFile()
        {
            string path = "Words.txt";
            Console.WriteLine("Please enter a word");
            string newString = Console.ReadLine();
            while (newString == string.Empty && newString == "")
            {
                Console.WriteLine("Please enter a valid word");
                newString = Console.ReadLine();
            }
            newString = newString + ": ";
            bool control = true;
            int counter = 1;
            do
            {
                Console.WriteLine("Please define that word: ");
                string tempString = Console.ReadLine();
                while (string.IsNullOrEmpty(tempString) || string.IsNullOrWhiteSpace(tempString))
                {
                    Console.WriteLine("Please enter a valid definition: ");
                    tempString = Console.ReadLine();
                }
                newString = newString + counter + ". " + tempString + " ";
                while (true)
                {
                    Console.WriteLine("Would you like to add another definition? [y/n]");
                    string usrChoice = Console.ReadLine().ToLower();
                    if (usrChoice == "y")
                    {
                        counter ++;
                        break;
                    }
                    else if (usrChoice == "n")
                    {
                        newString = newString + "\n";
                        control = false;
                        break;
                    }
                    else{Console.WriteLine("Please enter [y/n]");}
                }
            }while (control == true);
            try
            {
                File.AppendAllText(path, newString);
                Console.WriteLine("Text appended successfully.");
            }
            catch (IOException ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return;
        }
        static void ReadFile()
        {
            string path = "Words.txt";
            try
            {
                if (File.Exists(path))
                {
                    string content = File.ReadAllText(path);
                    Console.WriteLine("File Content:\n" + content);
                }
                else
                {
                    Console.WriteLine("File does not exist.");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return;

        }
        static void ReadToArray()
        {
            string path = "Words.txt";
            try
            {
                if (File.Exists(path))
                {
                    string[] lines = File.ReadAllLines(path);
                    string currentWord = lines[lines.Length - 1];
                    Console.WriteLine(currentWord);
                }
                else
                {
                    Console.WriteLine("File does not exist.");
                }
            }
            catch(IOException ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}