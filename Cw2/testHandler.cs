using Cw1;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cw2
{
    public class testHandler
    {
        public inputHandler inputContainer { get; set; }
        public Perceptron perceptron { get; set; }

        public testHandler(Perceptron perceptron, inputHandler inputHandler) {
            this.perceptron = perceptron;
            this.inputContainer = inputHandler;

        }

        public void testFile() {
            int count = 0;
            int properIdentificationsCount = 0;
            foreach (var vector in inputContainer) {
                int result = perceptron.getValue(vector);
                Console.WriteLine(result + " " + vector.predictedFlower);
                

                if((result == 1 && vector.predictedFlower == "Iris-setosa") || (result == 0 && vector.predictedFlower != "Iris-setosa")) 
                {
                    properIdentificationsCount++; 
                }
                count++;
            }

            Console.WriteLine(count/properIdentificationsCount*100 + "% correct identifications, count of correct identifications " +properIdentificationsCount );
        }

        public void testManual(params string[] values) {
            try
            {
                if (values.Length != perceptron.values.Count)
                {
                    throw new ArgumentException();
                }
            }
            catch(ArgumentException) {
                Console.WriteLine("Size of vector doesn't match size of the perceptron! - Program will now exit");
                Environment.Exit(1);
            }

            Vector vector = new Vector();

            for (int i = 0; i < values.Length; i++) {
                vector.values.Add(Double.Parse(values[i]));
            }

            Console.WriteLine("Is iris-setosa?: " + (perceptron.getValue(vector) == 1 ? "Yes" : "No"));

        }

    }
}
