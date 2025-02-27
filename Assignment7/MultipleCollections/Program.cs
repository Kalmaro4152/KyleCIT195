using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Transactions;
using System.Xml.Serialization;
namespace MultipleCollections
{
    class program
    {
        static int Menu()
        {
            int choice = 0;
            Console.WriteLine("1: UseQueue, 2: UseStack, 3: UseLinkedList, 4: UseDictionary, 5: UseHashSet, 0: Exit");
            Console.Write("Enter Choice: ");
            if (int.TryParse(Console.ReadLine(), out int input))
            {
                
                choice = input;
            }
            else{Console.WriteLine("Please enter a number");}
            return choice;
        }
        static void UseQueue()
        {
            Queue<string> gamesQueue = new Queue<string>();
            for(int i = 0; i < 5; i++)
            {
                Console.Write("Please enter a game name: "); //add games to the queue
                gamesQueue.Enqueue(Console.ReadLine());
            }
            Console.WriteLine($"There are {gamesQueue.Count} games in the Queue."); //count the number in queue
            Console.Write("Check for a game in the queue:");
            string game = Console.ReadLine();
            if(gamesQueue.Contains(game))
            {
                Console.WriteLine("That game is in the queue.");
            }
            else
            {
                Console.WriteLine("Game not found in queue.");
            }
            Console.WriteLine("Removing the first game from the queue.");
            gamesQueue.Dequeue();
            foreach(string thing in gamesQueue)
            {
                Console.WriteLine($"Game: {thing}");
            }
        }
        static void UseStack()
        {
            Stack<string> gamesStack = new Stack<string>();
            for(int i = 0; i < 5; i++)
            {
                Console.Write("Please enter a game name: "); //add games to the queue
                gamesStack.Push(Console.ReadLine());
            }
            Console.WriteLine("Check to see if a game is in the stack. q quits");
            while(true)
            {
                Console.Write("Game: ");
                string input = Console.ReadLine();
                if(input == "q")
                {
                    break;
                }
                else if(gamesStack.Contains(input))
                {
                    Console.WriteLine("That game is in the stack");
                }
                else{Console.WriteLine("That game is not in the stack");}
            }
            Console.WriteLine($"Popping {gamesStack.Pop()}");
            Console.WriteLine($"There are {gamesStack.Count} items in the stack.");
            foreach (string item in gamesStack)
            {
                Console.WriteLine(item);
            }
        }
        static void UseLinkedList()
        {
            LinkedList<string> gamesLinked = new LinkedList<string>();
            for(int i = 0; i < 5; i++)
            {
                Console.Write("Please enter a game name: "); //add games to the linkedlist
                gamesLinked.AddLast(Console.ReadLine());
            }
            Console.WriteLine($"The First Game added was {gamesLinked.First.Value}");
            Console.WriteLine($"The last game added was {gamesLinked.Last.Value}");
            Console.Write("Enter a game to find: ");
            string find = Console.ReadLine();
            LinkedListNode<string> node = gamesLinked.Find(find);
            if (node != null)
            {
                Console.Write("Please enter a game to add after that game: ");
                gamesLinked.AddAfter(node, Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Game not found");
            }
            Console.Write("Specify a game to remove: ");
            find = Console.ReadLine();
            if (gamesLinked.Find(find) != null)
                gamesLinked.Remove(find);
            else
                Console.WriteLine("Not found, not removed");
            Console.WriteLine($"There are {gamesLinked.Count} games left in the list.");
            foreach(string thing in gamesLinked)
            {
                Console.WriteLine(thing);
            }

        }
        static void UseDictionary()
        {
            Dictionary<string, string> gamesDict = new Dictionary<string, string>();
            for(int i = 0; i < 5; i++)
            {
                Console.Write("Enter a game: ");
                string game = Console.ReadLine();
                Console.Write("Enter a developer: ");
                string dev = Console.ReadLine();
                gamesDict[game] = dev;
            }
            foreach( string item in gamesDict.Keys)
            {
                Console.WriteLine(item);
            }
            foreach(string item in gamesDict.Values)
            {
                Console.WriteLine(item);
            }
            foreach(var entry in gamesDict)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
            Console.Write("Choose a game to remove: ");
            string remove = Console.ReadLine();
            gamesDict.Remove(remove);
            Console.WriteLine($"Games left: {gamesDict.Count}");
        }
        static void UseHashSet()
        {
            HashSet<string> gamesHashOne = new HashSet<string>();
            HashSet<string> gamesHashTwo = new HashSet<string>();
            HashSet<string> gamesHashThree = new HashSet<string>();
            Console.WriteLine("Create a games list.");
            for(int i = 0; i < 5; i++)
            {
                Console.Write("Enter a game: ");
                gamesHashOne.Add(Console.ReadLine());
            }
            Console.WriteLine("Create a second games list.");
            for(int i = 0; i < 5; i++)
            {
                Console.Write("Enter a game: ");
                gamesHashTwo.Add(Console.ReadLine());
            }
            Console.WriteLine("Create a third games list, with some duplicates.");
            for(int i = 0; i < 5; i++)
            {
                Console.Write("Enter a game: ");
                gamesHashThree.Add(Console.ReadLine());
            }
            gamesHashOne.UnionWith(gamesHashTwo);
            gamesHashOne.UnionWith(gamesHashThree);
            Console.WriteLine("All games with no repeats.");
            foreach(string item in gamesHashOne)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Total games: " + gamesHashOne.Count);
        }

        static void Main(string[] args)
        {
            int choice = Menu();
            while (choice != 0)
            {
                switch(choice)
                {
                    case 1:
                        UseQueue();
                        break;
                    case 2:
                        UseStack();
                        break;
                    case 3:
                        UseLinkedList();
                        break;
                    case 4:
                        UseDictionary();
                        break;
                    case 5:
                        UseHashSet();
                        break;
                    default:
                        Console.WriteLine("Invalid Choice.");
                        break;
                }
                choice = Menu();
            }
        }
    }
}