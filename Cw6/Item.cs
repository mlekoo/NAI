using System;
using System.Collections.Generic;
using System.Text;

namespace Cw6
{
    public class Item
    {
        public int number { get; set; }
        public int size { get; set; }
        public int value { get; set; }

        public Item(int number, int size, int value) {
            this.number = number;
            this.size = size;
            this.value = value;
        }

        public override string ToString()
        {
            return "Size: " + this.size + " Value: " + value;
        }

    }
}
