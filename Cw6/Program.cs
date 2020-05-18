using System;

namespace Cw6
{
    class Program
    {
        static void Main(string[] args)
        {

            InputHandler inputHandler = new InputHandler("../../../data/plecak.txt");

            Backpack backpack = new Backpack(inputHandler.backpackCapacity);

            var setNumber = new Random().Next(0, inputHandler.itemSets.Count);

            ItemSet itemSet = inputHandler.itemSets[setNumber];
            Console.WriteLine("Set number: " + (setNumber + 1));
            Console.WriteLine();

            var startTime = DateTime.Now;

            BruteForce bruteForce = new BruteForce(backpack, itemSet);

            bruteForce.run();

            Console.WriteLine("Time of execution: " + (DateTime.Now.Millisecond - startTime.Millisecond) + " milis");

        }
    }
}
