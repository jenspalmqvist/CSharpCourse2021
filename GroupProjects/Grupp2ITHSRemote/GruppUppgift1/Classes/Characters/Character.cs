using System;
using System.Collections.Generic;
using System.Text;

namespace GruppUppgift1
{
    public abstract class Character
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int Damage { get; set; }
        public int AttackSkill { get; set; }
        public int Defense { get; set; }
        public int DefenseSkill { get; set; }
        public string Name { get; set; }
    }
}
