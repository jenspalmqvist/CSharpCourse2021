using System;
using System.Collections.Generic;
using System.Text;

namespace Adventure_Game
{
    internal interface IEnemy
    {
        public int xPos { get; set; }
        public int yPos { get; set; }

        public GameState Move(Map map);
    }
}