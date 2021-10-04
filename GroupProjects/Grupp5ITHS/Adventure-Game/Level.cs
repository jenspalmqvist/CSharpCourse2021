using System.Collections.Generic;

namespace Adventure_Game
{
    internal class Level
    {
        public List<char[,]> Levels()
        {
            List<char[,]> levels = new List<char[,]>();
            levels.Add(grid1);
            levels.Add(grid2);
            levels.Add(grid3);
            return levels;
        }

        public char[,] grid1 =
            {
                {Graphics.CornerUpLeft,Graphics.WallHorison, Graphics.WallHorison, Graphics.WallHorison , Graphics.WallHorison , Graphics.WallHorison , Graphics.WallHorison , Graphics.WallHorison , Graphics.WallHorison , Graphics.WallHorison, Graphics.WallHorison, Graphics.CornerUpRight, },
                {Graphics.WallVertical,Graphics.Player,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallVertical, },
                {Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallVertical, },
                {Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Coin,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallVertical, },
                {Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.Snake,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallVertical, },
                {Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Rat,Graphics.Empty,Graphics.Empty,Graphics.WallVertical, },
                {Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallVertical, },
                {Graphics.WallVertical,Graphics.Coin,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallVertical, },
                {Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Rat,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallVertical, },
                {Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallVertical, },
                {Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Coin,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallVertical, },
                {Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallVertical, },
                {Graphics.CornerDownLeft, Graphics.WallHorison, Graphics.WallHorison, Graphics.WallHorison, Graphics.WallHorison, Graphics.WallHorison, Graphics.WallHorison, Graphics.WallHorison, Graphics.WallHorison, Graphics.WallHorison, Graphics.WallHorison, Graphics.CornerDownRight, }
            };

        public char[,] grid2 =
        {
                {Graphics.CornerUpLeft,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.CornerUpRight, },
                {Graphics.WallVertical,Graphics.Player,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Coin,Graphics.Empty,Graphics.WallVertical, },
                {Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallVertical, },
                {Graphics.WallVertical,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallVertical, },
                {Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Rat,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallVertical, },
                {Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallVertical, },
                {Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallVertical, },
                {Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallVertical, },
                {Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Snake,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallVertical, },
                {Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallVertical, },
                {Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallVertical, },
                {Graphics.CornerDownLeft,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.CornerUpRight,Graphics.Empty,Graphics.CornerUpLeft,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.CornerDownRight, },
                {Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallVertical,Graphics.Empty,Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty, },
                {Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallVertical,Graphics.Empty,Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty, },
                {Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallVertical,Graphics.Coin,Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty, },
                {Graphics.CornerUpLeft,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.CornerDownRight,Graphics.Empty,Graphics.CornerDownLeft,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.CornerUpRight, },
                {Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallVertical,Graphics.Empty,Graphics.Coin,Graphics.Empty,Graphics.WallVertical, },
                {Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.Snake,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallVertical, },
                {Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallVertical, },
                {Graphics.WallVertical,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Rat,Graphics.Empty,Graphics.WallVertical, },
                {Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallVertical, },
                {Graphics.WallVertical,Graphics.Empty,Graphics.Coin,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Snake,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallVertical, },
                {Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallVertical, },
                {Graphics.CornerDownLeft,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.CornerDownRight, },
        };

        public char[,] grid3 =
        {
                {Graphics.CornerUpLeft,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.CornerUpRight, },
                {Graphics.WallVertical,Graphics.Player,Graphics.Empty,Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallVertical, },
                {Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.Rat,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Coin,Graphics.WallVertical, },
                {Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.WallVertical, },
                {Graphics.WallVertical,Graphics.Empty,Graphics.Coin,Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.WallVertical, },
                {Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Coin,Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.WallVertical, },
                {Graphics.WallVertical,Graphics.Snake,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallVertical, },
                {Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallVertical, },
                {Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.Rat,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallVertical,Graphics.Empty,Graphics.Rat,Graphics.Empty,Graphics.WallVertical, },
                {Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallVertical, },
                {Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Coin,Graphics.Empty,Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.WallVertical, },
                {Graphics.WallVertical,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Empty,Graphics.Coin,Graphics.WallVertical, },
                {Graphics.CornerDownLeft,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.WallHorison,Graphics.CornerDownRight, },
        };
    }

    //╠
    //╔
    //╬
    //═
    //╚
    //╗

    //╝
    //║
}