using System;
using System.ComponentModel;
using System.Drawing;

namespace gruppuppgift_210917
{
    public interface IWorldObject
    {
        public string Item { get; set; }
        public string RequestedItem { get; set; }
        public string MessageForRequestedItem { get; set; }
        public string InformationAboutObject { get; set; }
        public ConsoleColor BackgroundColor { get; set; }
    }
}