using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gruppuppgift_210917
{
    class WaterTile : IWorldObject
    {
        public WaterTile()
        {
            BackgroundColor = ConsoleColor.DarkBlue;
            InformationAboutObject = "Water";
            Item = null;
        }

        public string Item { get; set; }
        public string RequestedItem { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string MessageForRequestedItem { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string InformationAboutObject { get; set; }
        public ConsoleColor BackgroundColor { get; set; }
    }
}
