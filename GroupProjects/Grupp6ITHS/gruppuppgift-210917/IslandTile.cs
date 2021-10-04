using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gruppuppgift_210917
{
    class IslandTile : IWorldObject
    {
        public IslandTile()
        {
            BackgroundColor = ConsoleColor.DarkGreen;
            InformationAboutObject = "Grass";
            Item = null;
        }

        public string Item { get; set; }
        public string RequestedItem { get; set; }
        public string MessageForRequestedItem { get; set; }
        public string InformationAboutObject { get; set; }
        public char ItemIcon { get; set; }
        public ConsoleColor BackgroundColor { get; set; }
        private static List<string> availableItems = new List<string>() {
            // "With the treasure map you shall be able to find \nthe metal detector so u can locate the key",
            " Now that you found the metal detector you will \n" +
            "| need it for the next island where the shovel is. \n",
            " Someone has forgotten their shovel on the island, \n" +
            "| you can use it combained with the metal detector \n" +
            "| to find out where the key is located.                        ",
            " You walk around on the island and the metal detector \n" +
            "| beeps, use your shovel to dig up the key!! With the key\n" +
            "| you have acquired it's time to find Jesus secret sex dungeon\n" +
            "| where you can find the legendary hard boiled egg!!  ",
            " Make sure you take the hard boiled egg to Jesus so he \n" +
            "| can spare your life and make sure that you are worthy!!  \n" +
            "|                                                               \n" +
            "|                                                                ",
            "                     Jesus Will save you!!!                   \n" +
            "|                                                               \n" +
            "|                                                                "};

        private static List<string> usedItems = new List<string>() {
            "Treasure Map",
            "Metal Detector",
            "Shovel",
            "Key",
            "Hard Boiled Egg",
            "Jesus"};
        public void AddItemInformation()
        {
            RequestedItem = usedItems[0];
            MessageForRequestedItem = availableItems[0];
            usedItems.RemoveAt(0);
            availableItems.RemoveAt(0);
            Item = usedItems[0];
        }
    }
}
