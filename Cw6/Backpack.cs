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

    }
}
