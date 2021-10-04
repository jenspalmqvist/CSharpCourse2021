using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    interface IEdible
    {
        public int HealthIncrease { get; set; }
        public int HungerIncrease { get; set; }
    }
}
