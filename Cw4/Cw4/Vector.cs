using System;
using System.Collections.Generic;
using System.Text;

namespace Cw4
{
    public class Vector
    {
        public List<double> values { get; set; }

        public Vector() {
            values = new List<double>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (var value in values) {

                sb.Append("V").Append(i).Append(" ").Append(value).Append(" ");

                i++;
            }

            return sb.ToString();
        }

    }
}
