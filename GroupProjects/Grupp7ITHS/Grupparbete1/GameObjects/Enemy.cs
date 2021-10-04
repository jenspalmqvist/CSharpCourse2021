using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupparbete1.GameObjects
{
    /// <summary>
    /// Actor som spelaren kan interagera med genom att attackera dem.
    /// </summary>
    public class Enemy : Actor
    {
        public Enemy(int x, int y, string name) : base(x, y, name, 'E', 10, 2, 10)
        {
            
        }
    }
}
