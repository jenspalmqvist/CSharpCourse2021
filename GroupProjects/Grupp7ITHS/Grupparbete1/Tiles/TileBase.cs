using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupparbete1.Tiles
{
    /// <summary>
    /// Abstrakt grundklass som representerar en ruta på spelbrädet.
    /// </summary>
    public abstract class TileBase
    {
        public bool IsWalkable { get; protected set; }
        public bool BlocksFOV { get; protected set; }
        public char Icon { get; protected set; }
        protected TileBase()
        {
        }
    }
}
