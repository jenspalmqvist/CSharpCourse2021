using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Group1Game
{
    public class Player
    {
        //public int[,] currentPosition { get; set; } = new int[5, 5];
        //(int, int) currentPos = (0, 0);

        //public (int, int) currentPos { get; set; } = (0,0);

        public int playerRow { get; set; } = 0;
        public int playerColumn { get; set; } = 0;
        public int NumberOfMoves { get; set; } = 3;
        public int NumberOfPickaxes { get; set; } = 0;
        public int shoes { get; set; } = 0;
        

        Item newitem = new Item();

        public void GetInventory()
        {
            List<Item> Inventory = new List<Item>();
            Inventory.Add(newitem);      
        }

        public Player()
        {
    
        }
        public void GetDistanceWithSpeedShoes()
        {
            NumberOfMoves++;
            shoes++;

        }
        public void PickUpPickaxe()
        {
            NumberOfPickaxes++;
        }
        public void UsePickaxe()
        {
            NumberOfPickaxes--;
        }
        public string Name { get; set; } = "Nonamer";
        public string BoardSign { get; set; }

    }
}

