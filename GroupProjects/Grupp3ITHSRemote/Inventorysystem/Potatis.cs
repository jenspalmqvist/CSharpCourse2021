using System;

namespace Rollspel
{
    public class Potatis : Item, IEdible, IKickable
    {
        private int startX;
        private int startY;
        private char symbol = 'O';

        public override char Symbol { get; set; }
        public override char SymbolInvisible { get; set; } = ' ';
        public override int X { get; set; }
        public override int Y { get; set; }
        public override string Name { get; set; } = "Potatis";
        public bool InInventory { get; set; } = false;

        public Potatis(int x, int y)
        {
            startX = x;
            startY = y;
            Reset();
        }

        public override void Use()
        {
            Console.SetCursorPosition(InteractiveMenu.AnchorX+1, InteractiveMenu.AnchorY + 6);
            Console.WriteLine("Tryck på piltangenterna för att välja riktning");
            bool canPlace = false;
            while (!canPlace)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        if (CheckFree(Player.X, Player.Y - 1))
                        {
                            canPlace = true;
                            X = Player.X;
                            Y = Player.Y - 1;
                            Symbol = symbol;
                            Inventory.ItemList.Remove(this);

                        }
                        else
                        {
                            Console.WriteLine("Platsen upptagen");
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (CheckFree(Player.X, Player.Y + 1))
                        {
                            canPlace = true;
                            X = Player.X;
                            Y = Player.Y + 1;
                            Symbol = symbol;
                            Inventory.ItemList.Remove(this);
                        }
                        else
                        {
                            Console.WriteLine("Platsen upptagen");
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (CheckFree(Player.X - 1, Player.Y))
                        {
                            canPlace = true;
                            X = Player.X - 1;
                            Y = Player.Y;
                            Symbol = symbol;
                            Inventory.ItemList.Remove(this);

                        }
                        else
                        {
                            Console.WriteLine("Platsen upptagen");
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if (CheckFree(Player.X + 1, Player.Y))
                        {
                            canPlace = true;
                            X = Player.X + 1;
                            Y = Player.Y;
                            Symbol = symbol;
                            Inventory.ItemList.Remove(this);
                        }
                        else
                        {
                            Console.WriteLine("Platsen upptagen");
                        }
                        break;

                    case ConsoleKey.Escape:
                        // avbryt
                        return;
                }
            }
            Inventory.PrintInventory();
            Program.DrawEmpty(InteractiveMenu.AnchorX, InteractiveMenu.AnchorY, InteractiveMenu.MenuWidth - 2, InteractiveMenu.MenuHeight - 2);
            LevelHandler.DrawLevel(LevelHandler.CurrentLevel);
        }

        public override void Reset()
        {
            X = startX;
            Y = startY;
            Symbol = symbol;
            InInventory = false;
        }

        public override void Step()
        {
            if ((Player.X == X) && (Player.Y == Y) && (!InInventory))
            {
                PickUp();
            }
        }

        private void PickUp()
        {
            Inventory.AddToInventory(this);
            InInventory = true;
            Symbol = SymbolInvisible;
        }

        private bool CheckFree(int x, int y)
        {
            if (LevelHandler.CurrentLevel.Layout[x, y] == ' ')
            {
                return true;
            }
            return false;
        }
    }
}