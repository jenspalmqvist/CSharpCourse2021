using System;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace Rollspel
{
    public abstract class Item : IActiveObject
    {
        public abstract char Symbol { get; set; }
        public abstract char SymbolInvisible { get; set; }
        public abstract int X { get; set; }
        public abstract int Y { get; set; }
        public abstract string Name { get; set; }

        public virtual void Use()
        {
            Console.WriteLine("Use this item!");
        }

        public abstract void Step();

        public abstract void Reset();
    }
}