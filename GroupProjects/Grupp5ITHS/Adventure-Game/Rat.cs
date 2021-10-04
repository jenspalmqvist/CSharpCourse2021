using System;
using System.Collections.Generic;
using System.Text;

namespace Adventure_Game
{
    internal class Rat : IEnemy
    {
        public int xPos { get; set; }
        public int yPos { get; set; }
        private string lastMove = "left";

        //Ändrar från ypos, xpos till tvärtom.

        public Rat(int xPos, int yPos)
        {
            this.yPos = yPos;
            this.xPos = xPos;
        }

        //Testat att ändra från xPos till yPos.
        //Lade till så att den sparar den nya positionen.
        public GameState Move(Map map)
        {
            if (lastMove == "left")
            {
                if (map.GetPosContent(xPos - 1, yPos) == Graphics.Player)
                {
                    return GameState.EnemyEncountered;
                }
                map.PutCharAtPos(xPos, yPos, Graphics.Empty);
                map.PutCharAtPos(xPos - 1, yPos, Graphics.Rat);
                lastMove = "upp";
                xPos -= 1;
                //upp
            }
            else if (lastMove == "upp")
            {
                if (map.GetPosContent(xPos, yPos + 1) == Graphics.Player)
                {
                    return GameState.EnemyEncountered;
                }
                map.PutCharAtPos(xPos, yPos, Graphics.Empty);
                map.PutCharAtPos(xPos, yPos + 1, Graphics.Rat);
                lastMove = "right";
                yPos += 1;
                // right
            }
            else if (lastMove == "right")
            {
                if (map.GetPosContent(xPos + 1, yPos) == Graphics.Player)
                {
                    return GameState.EnemyEncountered;
                }
                map.PutCharAtPos(xPos, yPos, Graphics.Empty);
                map.PutCharAtPos(xPos + 1, yPos, Graphics.Rat);
                lastMove = "down";
                xPos += 1;
                //down
            }
            else if (lastMove == "down")
            {
                if (map.GetPosContent(xPos, yPos - 1) == Graphics.Player)
                {
                    return GameState.EnemyEncountered;
                }
                map.PutCharAtPos(xPos, yPos, Graphics.Empty);
                map.PutCharAtPos(xPos, yPos - 1, Graphics.Rat);
                lastMove = "left";
                yPos -= 1;
                //left
            }
            return GameState.Running;
        }
    }
}