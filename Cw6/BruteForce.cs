using System;
using System.Collections.Generic;
using System.Text;

namespace Cw6
{
    public class BruteForce
    {
        ItemSet itemSet { get; set; }
        Backpack backpack { get; set; }
        public BruteForce(Backpack backpack, ItemSet itemSet) {
            this.backpack = backpack;
            this.itemSet = itemSet;
        }

        public void run() {
            ItemSet bestResult = new ItemSet();
            ItemSet currentResult = new ItemSet();
            for (long i = 0; i < (long)Math.Pow(2, itemSet.items.Count); i++) {

                for (int j = 0; j < itemSet.items.Count; j++) {
                    if (((i >> j) & 1) == 1) {
                                currentResult.items.Add(itemSet.items[j]);
                    }
                }
                if (currentResult.sumOfSizes() <= backpack.capacity) { 
                    if (bestResult.sumOfValues() <= currentResult.sumOfValues()) {
                    
                        bestResult = currentResult;
                    }
                }
                currentResult = new ItemSet();

            }
            Backpack resultBackpack = new Backpack(backpack.capacity, bestResult.items);
            Console.WriteLine(resultBackpack);
            Console.WriteLine("Sum of sizes: " + bestResult.sumOfSizes() + " Sum of values: " + bestResult.sumOfValues());
        }

    }
}
