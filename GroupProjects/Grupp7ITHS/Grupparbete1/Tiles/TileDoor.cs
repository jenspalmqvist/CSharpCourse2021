using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupparbete1.Tiles
{
    public class TileDoor : TileBase
    {
        public TileDoor() : base()
        {
            IsWalkable = false;
            BlocksFOV = true;
            Icon = '/';
        }

        public void Open()
        {
            IsWalkable = true;
            BlocksFOV = false;
            Icon = '.';
        }
    }
}
