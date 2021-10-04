namespace Adventure_Game
{
    internal class Enemy
    {
        //public int enemyXPos;
        //public int enemyYPos;
        //private string lastMove = "right";

        //public Enemy(int startingX, int startingY)
        //{
        //    enemyXPos = startingX;
        //    enemyYPos = startingY;
        //}

        //public GameState Move(Map map)
        //{
        //    if (lastMove == "right")
        //    {
        //        bool lost = false;
        //        if (map.GetPosContent(enemyXPos - 1, enemyYPos) == Graphics.Player)
        //        {
        //            lost = true;
        //        }
        //        map.PutCharAtPos(enemyXPos - 1, enemyYPos, Graphics.Enemy);
        //        map.PutCharAtPos(enemyXPos, enemyYPos, Graphics.Empty);
        //        enemyXPos -= 1;
        //        lastMove = "left";
        //        if (lost == true)
        //        {
        //            return GameState.Lose;
        //        }
        //    }
        //    else
        //    {
        //        bool lost = false;

        //        if (map.GetPosContent(enemyXPos + 1, enemyYPos) == Graphics.Player)
        //        {
        //            lost = true;
        //        }
        //        map.PutCharAtPos(enemyXPos + 1, enemyYPos, Graphics.Enemy);
        //        map.PutCharAtPos(enemyXPos, enemyYPos, Graphics.Empty);
        //        enemyXPos += 1;
        //        lastMove = "right";
        //        if (lost == true)
        //        {
        //            return GameState.Lose;
        //        }
        //    }
        //    return GameState.Running;
        //}
    }
}