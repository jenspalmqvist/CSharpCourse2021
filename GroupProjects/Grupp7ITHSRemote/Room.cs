using System;
using System.Collections.Generic;
using System.Text;

namespace Projektarbete_grp7
{
    class Room : Location
    {
        public List<Location> Paths { get; set; } //Kanske kan göra det till en private list bara...

        public Room(string description)
        {
            Description = description;
            Paths = new List<Location>();
        }
        public override void EnterLocation()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Description);
            Console.ResetColor();

            int playerInput = Program.GetPlayerInput(Paths.Count);
            ChoosePath(playerInput);
        }

        public void AddPath(Location location)
        {
            Paths.Add(location);
        }

        private void ChoosePath(int pathIndex)
        {
            Paths[pathIndex - 1].EnterLocation();
        }
    }
}
