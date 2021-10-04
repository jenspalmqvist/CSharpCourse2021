using System;
using System.Collections.Generic;
using System.Text;

namespace Projektarbete_grp7
{
    abstract class Location
    {
        public string Description { get; set; }

        public abstract void EnterLocation();
    }
}
