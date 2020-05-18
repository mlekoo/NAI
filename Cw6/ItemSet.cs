using System;
using System.Collections.Generic;
using System.Text;

namespace Cw6
{
    public class ItemSet
    {
        public List<Item> items { get; set; }

        public ItemSet() {
            this.items = new List<Item>();
        }

        public int sumOfSizes() {
            int sum = 0;
            foreach (var item in items) {
                sum += item.size;
            }

            return sum;

        }

        public int sumOfValues() {
            int sum = 0;
            foreach (var item in items) {
                sum += item.value;
            }

            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in items) {
                sb.Append("Nr: " + item.number + " Size: " + item.size + " Value: " + item.value + "\n");
            }

            return sb.ToString();
        }

    }
}
