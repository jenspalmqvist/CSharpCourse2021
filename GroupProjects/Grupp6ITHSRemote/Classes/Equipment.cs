using System;
using System.Collections.Generic;
using System.Text;

namespace RollSpelGrupp6.Classes
{
    public class Equipment
    {
        public Random Rnd { get; set; }
        public Player Player { get; set; }

        public string Name { get; set; }
        public int Level { get; set; }
        public int DropChance { get; set; }

        public int Defence { get; set; }
        public int LowDefence { get; set; }
        public int HighDefence { get; set; }

        public int HP { get; set; }
        public int LowHP { get; set; }
        public int HighHp { get; set; }

        public int LowDamage { get; set; }
        public int HighDamage { get; set; }

        public int CritChance { get; set; }
        public int LowCrit { get; set; }
        public int HighCrit { get; set; }

        // Equipments Level bör finnas som en property då vi vill använda den i ToString() för att visa i Inventory
        //public override string ToString()
        //{
        //    return $"{Name} (Lv. {Level})";
        //}
    }

    
    public abstract class DefenseEquipment : Equipment
    {
        public abstract void init();
        public abstract void SetLevel(int level);
        public abstract void IncrementStats();
    }

    public class Helmet : DefenseEquipment
    {
        public Helmet()
        {
            init();
            SetLevel(1);
        }

        public override void IncrementStats()
        {
            LowDefence += 2;
            HighDefence += 2;
            Defence = Generator.RandomNumber(LowDefence, HighDefence);

            LowHP += 2;
            HighHp += 2;
            HP = Generator.RandomNumber(LowHP, HighHp);
        }

        public override void init()
        {
            Name = "Helmet";

            LowDefence = 3;
            HighDefence = 10;
            Defence = Generator.RandomNumber(LowDefence, HighDefence);

            LowHP = 5;
            HighHp = 12;
            HP = Generator.RandomNumber(LowHP, HighHp);

            //DropChance = 33;
        }

        public override void SetLevel(int level)
        {
            Level = level;
            if (level > 1)
            {
                for (int i = 0; i < level; i++)
                {
                    IncrementStats();
                }
            }
        }
    }

    public class Armor : DefenseEquipment
    {
        public Armor()
        {
            init();
        }

        public override void IncrementStats()
        {
            LowDefence += 4;
            HighDefence += 4;
            Defence = Generator.RandomNumber(LowDefence, HighDefence);

            LowHP += 4;
            HighHp += 4;
            HP = Generator.RandomNumber(LowHP, HighHp);
        }

        public override void init()
        {
            Name = "Armor";

            LowDefence = 10;
            HighDefence = 25;
            Defence = Generator.RandomNumber(LowDefence, HighDefence);

            LowHP = 10;
            HighHp = 20;
            HP = Generator.RandomNumber(LowHP, HighHp);

            //DropChance = 33;
        }

        public override void SetLevel(int level)
        {
            Level = level;
            if (level > 1)
            {
                for (int i = 0; i < level; i++)
                {
                    IncrementStats();
                }
            }
        }
    }

    internal class Potion : Equipment
    {
    }
}