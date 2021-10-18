using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsAndLinq
{
    public interface IAquatic
    {
        public int MaxTimeUnderwater { get; set; }

        public void Dive(int minutes)
        {
            if (!(this as Mammal).IsAlive)
            {
                throw new InvalidOperationException();
            }
            (this as Mammal).IsAlive = minutes <= MaxTimeUnderwater;
        }
    }
}