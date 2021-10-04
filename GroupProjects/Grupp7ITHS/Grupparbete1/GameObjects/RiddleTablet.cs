using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupparbete1.GameObjects
{
    public class RiddleTablet : GameObject
    {
        public Riddle Riddle { get; set; }

        public RiddleTablet(int x, int y, Riddle riddle) : base(x, y, "RiddleTablet", '?')
        {
            Riddle = riddle;
        }
    }
}
