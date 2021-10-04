using System;
using System.Collections.Generic;
using System.Text;

namespace Rollspel
{
    public interface IActiveObject // Objekt som kör egen kod.
    {
        public char Symbol { get; set; }
        public char SymbolInvisible { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public void Step(); // Denna metod ska köras varje gång spelaren tar ett steg. Hanteras av LevelHandler.
        public void Reset(); // Återställer objektet till startläge.
    }

    public interface IPushable // Saker man kan knuffa framför sig.
    {
    }

    public interface IStashable // Saker man kan stoppa i inventory.
    {
    }
}
