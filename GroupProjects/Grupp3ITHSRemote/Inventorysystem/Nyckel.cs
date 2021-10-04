using System;
using System.Collections.Generic;
using System.Text;

namespace Rollspel
{
    internal class Nyckel : Item
    {
        private int startX;
        private int startY;
        private bool startVisible;
        private char symbol = 'N';
        private char symbolInvisible = ' ';

        public override char Symbol { get; set; }
        public override char SymbolInvisible { get; set; }
        public override int X { get; set; }
        public override int Y { get; set; }
        public override string Name { get; set; } = "Nyckel";
        public bool InInventory { get; set; } = false;

        public Nyckel(int x, int y, bool visible)
        {
            startX = x;
            startY = y;
            startVisible = visible;
            Reset();
        }

        public override void Use()
        {
            
        }

        public override void Reset()
        {
            X = startX;
            Y = startY;
            if (startVisible)
            {
                Symbol = symbol;
            }
            else
            {
                Symbol = symbolInvisible; 
            }
            InInventory = false;
        }

        public override void Step()
        {
            CheckFind();
        }

        private void PickUp()
        {
            Inventory.AddToInventory(this);
            InInventory = true;
            Symbol = symbolInvisible;
        }
        public void CheckFind() { 

        if ((!InInventory)
            && ((X == Player.X + 1 && Y == Player.Y) 
            || (X == Player.X - 1 && Y == Player.Y) 
            || (X == Player.X && Y == Player.Y + 1) 
            || (X == Player.X && Y == Player.Y - 1)))
            {
                PickUp();
            }
        }

    }
}