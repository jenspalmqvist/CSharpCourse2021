using System;
using System.Collections.Generic;
using System.Text;

namespace Rollspel
{
    public class Level
    {
        public string Name { get; set; }
        public char[,] Layout { get; set; } // Hur kartan/banan ser ut.
        public string Message { get; set; } // Text som kommer fram när man går in i banan.
        public int StartX { get; set; } // Startposition för spelaren.
        public int StartY { get; set; } // Startposition för spelaren.
        public List<IActiveObject> ActiveObjects { get; set; } = new List<IActiveObject>(); // Lista med objekt som kör egen kod (på aktuell bana).
        public int Steps { get; set; } = 0; // Räkneverk som ökas för varje steg man tar.
    }
}
