using System;

namespace Cw4
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = 3;
            
           
            InputHandler inputHandler = new InputHandler("..\\..\\..\\iris_training.txt");

            TreningHandler treningHandler = new TreningHandler(
                                                    inputHandler.getInput(), k);


        }
    }
}
