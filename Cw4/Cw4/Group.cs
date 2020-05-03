using System;
using System.Collections.Generic;
using System.Text;

namespace Cw4
{
    class Group
    {
        public List<Flower> flowers { get; set; }
        public Vector centroid { get; set; }

        public Group(Vector centroid, List<Flower> flowers) {
            this.centroid = centroid;
            this.flowers = flowers;
        }

    }
}
