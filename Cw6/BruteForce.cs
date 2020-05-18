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
            for (int i = 0; i < (long)Math.Pow(2, itemSet.items.Count); i++) {
                long number = i;
                ItemSet currentResult = new ItemSet();

                for (int j = 0; j < itemSet.items.Count; j++) {
                    if ((number & j) == j) {
                        if (currentResult.sumOfSizes() + itemSet.items[j].size <= backpack.capacity)
                        {
                            currentResult.items.Add(itemSet.items[j]);
                        }
                    }
                }

                if (bestResult.items.Count < 1) {
                    bestResult = currentResult;
                }

                int bSumOfValues = bestResult.sumOfValues();
                int cSumOfValues = currentResult.sumOfValues();
                if (bSumOfValues < cSumOfValues) {
                    bestResult = currentResult;
                }

            }
            Console.WriteLine(bestResult);
            Console.WriteLine("Sum of sizes: " + bestResult.sumOfSizes() + " Sum of values: " + bestResult.sumOfValues());
        }

    }
}
