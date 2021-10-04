using ConsoleTables;

namespace RollSpelGrupp6
{
    public class Lives
    {
        public int LivesLeft { get; set; }
        //public ConsoleTables.ConsoleTable TableOfLives { get; set; }

        public Lives()
        {
            LivesLeft = 3;
        }

        public void PrintLives()
        {
            ConsoleTables.ConsoleTable tableOfLives;
            switch (LivesLeft)
            {
                case 0:
                    tableOfLives = new ConsoleTable("Lives", " ", " ", " ");
                    break;

                case 1:
                    tableOfLives = new ConsoleTable("Lives", "*", " ", " ");
                    break;

                case 2:
                    tableOfLives = new ConsoleTable("Lives", "*", "*", " ");
                    break;

                default:
                    tableOfLives = new ConsoleTable("Lives", "*", "*", "*");
                    break;
            }
            tableOfLives.Write(Format.Alternative);
        }
    }
}