using System;

namespace gruppuppgift_210917
{
    internal class BoatTile : IWorldObject
    {
        public BoatTile()
        {
            BackgroundColor = ConsoleColor.DarkMagenta;
            InformationAboutObject = "Your Boat";
            Item = null;
        }

        public string Item { get; set; }
        public string RequestedItem { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string MessageForRequestedItem { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string InformationAboutObject { get; set; }
        public ConsoleColor BackgroundColor { get; set; }
    }
}