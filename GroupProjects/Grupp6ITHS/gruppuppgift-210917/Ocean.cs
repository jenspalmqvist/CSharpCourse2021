using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gruppuppgift_210917
{
    internal class Ocean : IWorldObject
    {
        public string Item { get; set; }
        public string RequestedItem { get; set; }
        public string MessageForRequestedItem { get; set; }
        public string InformationAboutObject { get; set; }
        public ConsoleColor BackgroundColor { get; set; }

        public Ocean()
        {
            InformationAboutObject = "You are sailing the seas.";
            BackgroundColor = ConsoleColor.Blue;
            Item = null;
            RequestedItem = null;
            MessageForRequestedItem = null;
        }
    }
}