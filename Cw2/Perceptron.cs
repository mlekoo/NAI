using System;
using System.Collections.Generic;
using System.Text;

namespace Cw2
{
    public class Perceptron
    {
        public List<double> values { get; set; }
        public double theta { get; set; }
        public double learningConstant { get; }

        public Perceptron(double theta, double learningConstant, params double[] values) {            
            try
            {
                if (theta < 0 || theta > 1 || learningConstant < 0 || learningConstant > 1)
                {
                    throw new ArgumentException();
                }
                else { 
                this.theta = theta;
            }

            }
            catch (ArgumentException) {
                Console.WriteLine("Value of theta and learningConstant must be between 0 and 1 - Program will now exit");
                Environment.Exit(1);
            }
            this.learningConstant = learningConstant;
            this.values = new List<double>();
            for (int i = 0; i < values.Length; i++) {
                this.values.Add(values[i]);
            }




        }

        public int getValue(Vector vector)
        {
            double result = 0;

            for (int i = 0; i < vector.values.Count; i++)
            {
                result += vector.values[i] * this.values[i];
            }

            return result >= this.theta ? 1 : 0;
        }

    }
}
