using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
namespace Factions
{
    abstract class House
    {
        public double Disposition{get;set;}
        public string Alignment{get;set;}
        abstract public void Display();
    }

    class HouseInfo : House
    {
        public string Name{get;set;}
        public string Color{get;set;}
        public int Strength{get;set;}

        public HouseInfo()
        {
            Disposition = 0;
            Alignment = "Neutral";
            Name = "";
            Color = "White";
            Strength = 0;
        } 

        public HouseInfo(double disp, string align, string nam, string col, int stren)
        {
            Disposition = disp;
            Alignment = align;
            Name = nam;
            Color = col;
            Strength = stren;
        }

        public override void Display()
        {
            Console.WriteLine($"Faction is {Name}, Color is {Color}, Strength is {Strength}, Alignment is {Alignment}, Disposition is {Disposition}.");
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            HouseInfo Dagoth = new HouseInfo(-99, "Evil", "Dagoth", "Red", 1024);
            Dagoth.Display();
        }
        /* Could I do something more creative? Probably. But i don't know what to do, I honestly don't
        I'd like to try something harder, or more interesting, or something of the like, but I have no idea where
        to even start, or to even have the motivation to do so. i don't know. I'm just not feeling it. */
    }
}