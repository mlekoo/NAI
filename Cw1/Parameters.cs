using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Cw1
{

    
    public class Parameters : IEnumerable<XVector>

    {
        public List<XVector> parameters { get; set; }

        public Parameters() {
            this.parameters = new List<XVector>();
        }

        public IEnumerator<XVector> GetEnumerator()
        {
            foreach (var vector in parameters) {
                if (vector != null) {
                    yield return vector;
                }

            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class XVector {
        public List<double> xvector { get; set; }
        public string expectedResult { get; set; }

        public XVector() {
            xvector = new List<double>();
        }

        public static double getDistance(XVector x1, XVector x2) {
            double result = 0;
            for (int i = 0; i < x1.xvector.Count; i++) {
                result += Math.Pow((x1.xvector[i] - x2.xvector[i]), 2);
            }

            return result;
        }

    }

}
