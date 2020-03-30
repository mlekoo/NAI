using Cw1;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cw2
{
    public class Teacher
    {
        Perceptron perceptron;
        inputHandler inputHandler;

        public Teacher(Perceptron perceptron, inputHandler inputHandler) {
            this.perceptron = perceptron;
            this.inputHandler = inputHandler;
        }



        public void teach(int iterations)
        {
            for (int i = 0; i < iterations; i++) {
                foreach (var vector in this.inputHandler) {

                    

                    
                        int rightDecision = vector.predictedFlower == "Iris-setosa" ? 1 : 0;
                        int actualDecision = this.perceptron.getValue(vector);

                        this.perceptron.values = delta(vector, actualDecision, rightDecision, this.perceptron);
                    
                }
                
            }
        }
        public List<double> delta(Vector vector, int actualDecision, int rightDecision, Perceptron perceptron) {

            List<double> newPerceptron = new List<double>();

            for (int i = 0; i < perceptron.values.Count; i++) {
                newPerceptron.Add(perceptron.values[i] + (rightDecision - actualDecision) * perceptron.learningConstant * vector.values[i]);
            }
            perceptron.theta = perceptron.theta +  (rightDecision - actualDecision) * perceptron.learningConstant;

            return newPerceptron;
        }

    }
}
