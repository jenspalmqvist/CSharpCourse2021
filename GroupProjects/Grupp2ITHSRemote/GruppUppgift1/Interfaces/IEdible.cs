using System;
using System.Collections.Generic;
using System.Text;

namespace GruppUppgift1
{
    public interface IEdible
    {
        int HealingValue { get; set; }
        void Heal(Player player);
    }
}
