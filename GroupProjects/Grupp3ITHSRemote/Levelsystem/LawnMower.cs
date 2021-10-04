namespace Rollspel
{
    public class LawnMower : IActiveObject // TODO: Bug: Ibland efter reset rör den sig ett steg tidigare än normalt.
    {
        private int startX;
        private int startY;
        private int nextMove;

        public char Symbol { get; set; } = 'G';
        public char SymbolInvisible { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool Horizontal { get; set; }

        public LawnMower(int x, int y, bool horizontal)
        {
            startX = x;
            startY = y;
            Horizontal = horizontal;
            Reset();
        }

        public void Reset()
        {
            X = startX;
            Y = startY;
            nextMove = 0;
        }

        public void Step()
        {
            CheckPlayerKill();
            FollowPlayer();
            CheckPlayerKill();
        }

        // Ställer sig på samma höjd eller bredd som spelaren, med ett stegs eftersläpning.
        private void FollowPlayer()
        {
            if (nextMove != 0)
            {
                if ((Horizontal) && (CheckFree(X + nextMove, Y)))
                {
                    X += nextMove;
                }
                else if ((!Horizontal) && (CheckFree(X, Y + nextMove)))
                {
                    Y += nextMove;
                }
            }
            if (((Horizontal) && (X < Player.X) && (CheckFree(X + 1, Y)))
                || ((!Horizontal) && (Y < Player.Y) && (CheckFree(X, Y + 1))))
            {
                nextMove = 1;
            }
            else if (((Horizontal) && (X > Player.X) && (CheckFree(X - 1, Y)))
                || ((!Horizontal) && (Y > Player.Y) && (CheckFree(X, Y - 1))))
            {
                nextMove = -1;
            }
            else
            {
                nextMove = 0;
            }
        }

        private void CheckPlayerKill()
        {
            if ((X == Player.X) && (Y == Player.Y))
            {
                Player.Kill();
            }
        }

        // Troligtvis temporär, bättre att använda en universell metod.
        private bool CheckFree(int x, int y)
        {
            foreach (var item in LevelHandler.CurrentLevel.ActiveObjects)
            {
                if ((item.X == x) && (item.Y == y) && (item.Symbol != item.SymbolInvisible)) 
                { 
                    return false;  
                }
            }
            if (LevelHandler.CurrentLevel.Layout[x, y] == ' ')
            {
                return true;
            }
            return false;
        }
    }
}