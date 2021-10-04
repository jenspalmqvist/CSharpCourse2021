using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupparbete1.GameObjects
{
    public class Player : Actor
    {
        public int CorridorVisionRange { get; set; }

        public Player(int x, int y, string name) : base(x, y, name, '@', 15, 3, 3)
        {
            CorridorVisionRange = 3;
        }
    }
}
