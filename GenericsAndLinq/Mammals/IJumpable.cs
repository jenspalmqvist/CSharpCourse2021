using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsAndLinq
{
    public interface IJumpable
    {
        public int JumpingHeight { get; set; }

        public string Jump(int height);

        public string Jump();
    }
}