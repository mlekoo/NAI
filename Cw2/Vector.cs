using System;
using System.Collections.Generic;
using System.Text;

namespace Cw2
{
    public class Vector
    {
        public List<double> values { get; set; }
        public string predictedFlower { get; set; }

        public double resistance;
        public Vector() {
            values = new List<double>();
            predictedFlower = null;           
        }

        public override string ToString()
        {
            int count = 0;
            string stringResult = "";
            

            foreach (var value in values) {
                stringResult += "x" + count + ": " + value + " ";
                count++;
            }

            stringResult += predictedFlower;

            

            return stringResult;
        }


    }
}
