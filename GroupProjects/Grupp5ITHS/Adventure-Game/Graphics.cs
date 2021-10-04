namespace Adventure_Game
{
    public abstract class Graphics
    {
        public const char Player = 'O';
        public const char WallHorison = '═';
        public const char WallVertical = '║';
        public const char CornerUpLeft = '╔';
        public const char CornerUpRight = '╗';
        public const char CornerDownLeft = '╚';
        public const char CornerDownRight = '╝';
        public const char Empty = ' ';
        public const char Coin = '$';
        public const char Enemy = '¤';
        public const char Snake = '~';
        public const char Rat = '+';

        public static bool IsWall(char wall)
        {
            switch (wall)
            {
                case WallHorison:
                case WallVertical:
                case CornerUpLeft:
                case CornerUpRight:
                case CornerDownLeft:
                case CornerDownRight:
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsEnemy(char enemy)
        {
            switch (enemy)
            {
                case Snake:
                case Rat:
                    return true;

                default:
                    return false;
            }
        }
    }
}