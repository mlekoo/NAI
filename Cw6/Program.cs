using System;
using System.Diagnostics;

namespace Cw6
{
    class Program
    {
        static void Main(string[] args)
        {

            InputHandler inputHandler = new InputHandler("../../../data/plecak2.txt");

            Backpack backpack = new Backpack(inputHandler.backpackCapacity);

            var setNumber = new Random().Next(0, inputHandler.itemSets.Count);

            ItemSet itemSet = inputHandler.itemSets[setNumber];
            Console.WriteLine("Set number: " + (setNumber + 1));
            Console.WriteLine();

            var startTime = Stopwatch.StartNew();
            Console.WriteLine(startTime);

            BruteForce bruteForce = new BruteForce(backpack, itemSet);

            bruteForce.run();

            startTime.Stop();
            
            Console.WriteLine("Time of execution: " + startTime.ElapsedMilliseconds + " milis");

        }
    }
}
