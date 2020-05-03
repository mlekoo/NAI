using System;

namespace Cw4
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = 1;

            InputHandler inputHandler = new InputHandler("..\\..\\..\\iris_training.txt");

            while (k > 0)
            {
                Console.WriteLine("Write attribute k...");

                k = int.Parse(Console.ReadLine());

                if (k == 0) Console.WriteLine("Wrong attribute...");
                else
                {
                    TreningHandler treningHandler = new TreningHandler(
                                                            inputHandler.getInput(), k);
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

            }
        }
    }
}
