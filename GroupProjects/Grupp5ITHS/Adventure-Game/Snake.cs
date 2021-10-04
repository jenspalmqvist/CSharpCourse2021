using System;
using System.Collections.Generic;
using System.Text;

namespace Adventure_Game
{
    internal class Snake : IEnemy
    {
        public int xPos { get; set; }
        public int yPos { get; set; }

        private int patrolLength = 3;
        private bool changeDirection = false;
        private int stepsFromStart = 0;

        //Ändrar från ypos, xpos till tvärtom
        public Snake(int xPos, int yPos)
        {
            this.yPos = yPos;
            this.xPos = xPos;
        }

        public GameState Move(Map map)
        {
            if (stepsFromStart == patrolLength)
            {
                changeDirection = true;
            }
            else if (stepsFromStart == 0)
            {
                changeDirection = false;
            }

            if (!changeDirection)
            {
                if (map.GetPosContent(xPos, yPos + 1) == Graphics.Player)
                {
                    return GameState.EnemyEncountered;
                }
                map.PutCharAtPos(xPos, yPos, Graphics.Empty);
                map.PutCharAtPos(xPos, yPos + 1, Graphics.Snake);
                yPos++;
                stepsFromStart++;
            }
            else
            {
                if (map.GetPosContent(xPos, yPos - 1) == Graphics.Player)
                {
                    return GameState.EnemyEncountered;
                }
                map.PutCharAtPos(xPos, yPos, Graphics.Empty);
                map.PutCharAtPos(xPos, yPos - 1, Graphics.Snake);
                yPos--;
                stepsFromStart--;
            }
            return GameState.Running;
        }
    }
}