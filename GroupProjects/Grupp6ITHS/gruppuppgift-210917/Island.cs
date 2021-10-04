using System;
using System.Collections.Generic;

namespace gruppuppgift_210917
{
    public class Island : IWorldObject
    {
        public IslandWorld IslandMap { get; set; }
        public string Item { get; set; }
        public string ItemOnIsland { get; set; }
        public string RequestedItem { get; set; }
        public string MessageForRequestedItem { get; set; }
        public string InformationAboutObject { get; set; }
        public ConsoleColor BackgroundColor { get; set; }
       
        

        public Island()
        {
            InformationAboutObject = "Your ship is next to an island.";
            BackgroundColor = ConsoleColor.Green;
            IslandMap = new IslandWorld();
        }

       
        public void PrintInfoAboutObject()
        {
            Console.WriteLine(MessageForRequestedItem);
        }
    }
}
