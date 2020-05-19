using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cw6
{
    public class InputHandler
    {
        public int backpackCapacity;
        public List<ItemSet> itemSets { get; set; }



        public InputHandler(string path) {
            var lines = File.ReadLines(path);
            itemSets = new List<ItemSet>();
            List<int> sizes = new List<int>();
            foreach (var line in lines) {
                if (line.Contains("capacity ")) {
                    backpackCapacity = int.Parse(line.Replace("length - 26, capacity ", ""));
                }

                if (line.Contains("sizes")) {
                    sizes = new List<int>();
                    var sizeList = getRawDataFromLine(line);

                    foreach (var size in sizeList) {
                        sizes.Add(int.Parse(size));
                    }
                }

                if (line.Contains("vals")) {
                    var valueList = getRawDataFromLine(line);

                    ItemSet itemSet = new ItemSet();

                    for (int i = 0; i < valueList.Length; i++) {
                        itemSet.items.Add(new Item(i,sizes[i], int.Parse(valueList[i])));
                    }
                    itemSets.Add(itemSet);
                }
            }

            foreach (var itemSet in itemSets) {
                Console.WriteLine(itemSet);
                Console.WriteLine();
            }

        
        }
        private string[] getRawDataFromLine(string line) {
            var startIndex = line.IndexOf("{") + 1;
            var length = line.IndexOf("}") - startIndex;
            var data = line.Substring(startIndex, length).Trim();
            var rawData = data.Split(",");

            return rawData;
        }

    }



}
