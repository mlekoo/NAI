using Cw2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Cw1
{


    public class inputHandler : IEnumerable<Vector>
    {
        public List<Vector> inputContainer { get; set; }

        public inputHandler(string filePath) {

            inputContainer = new List<Vector>();

            loadFile(filePath);            

           

        }

        private void loadFile(string path) {

            var lines = File.ReadLines(path);

            foreach (var line in lines)
            {

                saveInputLine(
                    splitLine(line));

            }
        }

        private void saveInputLine(string[] value) {

            Vector vector = new Vector();



            for (int i = 0; i < value.Length - 1; i++) {
                vector.values.Add(
                    Double.Parse(
                        value[i].Replace(',', '.')
                        )
                    );
            }

            vector.predictedFlower = value[value.Length - 1];

            inputContainer.Add(vector);
        
        }

        private string[] splitLine(string line) { 
        
            return line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries); ;

        }

        public IEnumerator<Vector> GetEnumerator()
        {
            
            foreach (var vector in inputContainer)
            {
                if (vector != null)
                {
                    yield return vector;
                }

            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    
      
}
