using Cw4;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Cw4
{


    public class InputHandler : IEnumerable<Flower>
    {
        public List<Flower> inputContainer { get; set; }

        public InputHandler(string filePath)
        {

            inputContainer = new List<Flower>();

            loadFile(filePath);



        }

        private void loadFile(string path)
        {

            var lines = File.ReadLines(path);

            foreach (var line in lines)
            {

                saveInputLine(
                    splitLine(line));

            }
        }

        private void saveInputLine(string[] value)
        {

            Vector vector = new Vector();



            for (int i = 0; i < value.Length - 1; i++)
            {
                vector.values.Add(
                    Double.Parse(
                        value[i].Replace(',', '.')
                        )
                    );
            }

            string flowerName = value[value.Length - 1];

            

            inputContainer.Add(new Flower(vector, flowerName));

        }

        private string[] splitLine(string line)
        {

            return line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries); ;

        }

        public List<Flower> getInput() {
            return this.inputContainer;
        }

        public IEnumerator<Flower> GetEnumerator()
        {

            foreach (var flower in inputContainer)
            {
                if (flower != null)
                {
                    yield return flower;
                }

            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }



}
