using System;
using System.Collections.Generic;
using System.Text;

namespace GruppUppgift1
{
    public class Key : Item
    {
        public int Durability { get; set; } = 1;
        public ConsoleColor Color { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int DoorPosX { get; set; }
        public int DoorPosY { get; set; }
        public bool PickedUp { get; set; } = false;
        public int Map { get; set; }
        public char DoorChar { get; set; }

        public Key()
        {

        }
        public Key(int map, int durability, ConsoleColor color, int posX, int posY, int doorPosX, int doorPosY, char doorChar)
        {
            Map = map;
            Durability = durability;
            Color = color;
            PosX = posX;
            PosY = posY;
            DoorPosX = doorPosX;
            DoorPosY = doorPosY;
            DoorChar = doorChar;
        }
        public void Draw(Map map, Player player) // Lägger även in dörrarna här så länge..
        {
            if (player.PositionX == PosX && player.PositionY == PosY && map.map[PosY][PosX] == '£' && PickedUp == false) // Plocka upp nyckel.
            {
                PrintDialog(PosX + 1, PosY - 1, "You found a key!", Color, true, map);
                map.map[PosY][PosX] = ' '; // Behövs egentligen inte om vi använder bool PickedUp.
                PickUp(player);
            }
            if (map.mapVisible[PosY, PosX] && PickedUp == false) // Rendera nyckel
            {
                Console.SetCursorPosition(PosX, PosY);
                Console.ForegroundColor = Color;
                map.map[PosY][PosX] = '£';
                Console.Write("£"); // Nyckel
            }
            if (map.mapVisible[DoorPosY, DoorPosX] && Durability >= 1) // Rendera dörr
            {
                Console.SetCursorPosition(DoorPosX, DoorPosY);
                Console.ForegroundColor = Color;
                map.map[DoorPosY][DoorPosX] = DoorChar; // Behövs för att KeyboardHandler() ska veta att vi ej får gå där..
                Console.Write(DoorChar); // Dörr
                if (player.PositionX == DoorPosX - 1 && player.PositionY == DoorPosY && PickedUp == true || // Öppna dörr
                    player.PositionX == DoorPosX + 1 && player.PositionY == DoorPosY && PickedUp == true ||
                    player.PositionX == DoorPosX && player.PositionY == DoorPosY - 1 && PickedUp == true ||
                    player.PositionX == DoorPosX && player.PositionY == DoorPosY + 1 && PickedUp == true)
                {
                    map.map[DoorPosY][DoorPosX] = ' '; // Gör det möjligt att gå förbi positionen igen.
                    PrintDialog(player.PositionX + 1, player.PositionY - 1, "Door unlocked.", ConsoleColor.Green, true, map);
                    Use(player);
                }
            }
            if (player.PositionX == DoorPosX - 1 && player.PositionY == DoorPosY && PickedUp == false || // Visa dialog om stängd dörr.
                player.PositionX == DoorPosX + 1 && player.PositionY == DoorPosY && PickedUp == false ||
                player.PositionX == DoorPosX && player.PositionY == DoorPosY - 1 && PickedUp == false ||
                player.PositionX == DoorPosX && player.PositionY == DoorPosY + 1 && PickedUp == false)
            {
                PrintDialog(player.PositionX + 1, player.PositionY - 1, "Door is locked.", ConsoleColor.Red, true, map);
            }
        }

        public void PickUp(Player player)
        {
            PickedUp = true;
            player.Inventory.AddKey(this);
        }
        public void Use(Player player) // Denna kanske man kan använda om Durability = 0, deleta nyckelobjektet och ta bort från inventory (ifall en nyckel ska fungera till fler dörrar).
        {
            Durability--;
            if (Durability <= 0)
            {
                player.Inventory.DropKey(this);
            }
        }
        public void PrintDialog(int posX, int posY, string msg, ConsoleColor color, bool border, Map map)
        {
                Dialog d = new Dialog(posX, posY, msg, color, border, map);
                d.Print();
        }
    }
}
