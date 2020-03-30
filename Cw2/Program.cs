using Cw2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cw1
{
    public class Program
    {
        public static void Main(string[] args)
        {

            inputHandler parameters = new inputHandler("..\\..\\..\\iris_training.txt");
            Perceptron perceptron = new Perceptron(0.5, 0.5, 1.2, 1.5, 1.4, 1.5); // (Theta, LearningConstant, x1, x2, x3, x...n)

            Teacher teacher = new Teacher(perceptron, parameters);

            teacher.teach(20); // iterations through dataset

            foreach (var vector in parameters) {
                Console.WriteLine(vector.ToString());
            }
            Console.WriteLine();
            foreach(var i in perceptron.values) {
                Console.Write(i + " ");
            }

            Console.WriteLine();

            inputHandler testDataSet = new inputHandler("..\\..\\..\\iris_test.txt");

            testHandler testHandler = new testHandler(perceptron, testDataSet);

            testHandler.testFile();

            Console.WriteLine();

            while (true) {
                Console.WriteLine("Write your own parameters...");

                String line = Console.ReadLine();

                var values = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                testHandler.testManual(values);

            }
        }
    }
}