using System;

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

            var startTime = DateTime.Now.Second;
            Console.WriteLine(startTime);
            BruteForce bruteForce = new BruteForce(backpack, itemSet);

            bruteForce.run();

            var endTime = DateTime.Now.Second;
            Console.WriteLine(endTime);
            Console.WriteLine("Time of execution: " + (endTime - startTime) + " milis");

        }
    }
}
