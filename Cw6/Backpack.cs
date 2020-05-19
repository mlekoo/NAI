using System;
using System.Collections.Generic;
using System.Text;

namespace Cw6
{
    public class Backpack
    {
        public int capacity { get; set; }

        public List<Item> items { get; set; }

        public Backpack(int capacity) {
            this.capacity = capacity;
            this.items = new List<Item>();
        }
        public Backpack(int capacity, List<Item> items)
        {
            this.capacity = capacity;
            this.items = items;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in items)
            {
                sb.Append("Nr: " + item.number + " Size: " + item.size + " Value: " + item.value + "\n");
            }

            return sb.ToString();
        }

    }
}
