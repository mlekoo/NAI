using System;
using System.Collections.Generic;
using System.Text;

namespace Cw4
{
    public class Flower
    {
        public Vector vector { get; set; }
        public string name { get; set; }

        public Flower(Vector vector, string name) {
            this.vector = vector;
            this.name = name;
        }

    }
}
