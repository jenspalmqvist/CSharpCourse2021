using System;
using System.Collections.Generic;
using System.Text;

namespace GruppUppgift1
{
    public abstract class Item
    {
        public string ItemName { get; set; }
        public int SatchelSlotsRequired { get; set; }
        public int UsesLeft { get; set; }
        public char ItemChar { get; set; } = '$';
        public int PosX { get; set; }
        public int PosY { get; set; }
        public ConsoleColor Color { get; set; } = ConsoleColor.Magenta; // Använda för rarity på items? Common/Rare/Epic
        public bool AlwaysVisible { get; set; } = true; // Debug

        public Item()
        {

        }
        public Item(char itemChar, ConsoleColor itemColor)
        {
            ItemChar = itemChar;
            Color = itemColor;
        }
        public void Draw(Map map)
        {
            if (map.mapVisible[PosY, PosX] || !AlwaysVisible)
            {
                Console.SetCursorPosition(PosX, PosY);
                Console.ForegroundColor = Color;
                Console.Write(ItemChar);
            }
        }
    }
}
