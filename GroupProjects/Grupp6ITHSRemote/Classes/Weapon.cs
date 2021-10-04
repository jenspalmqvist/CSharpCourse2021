using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace RollSpelGrupp6.Classes
{
    public class Weapon : Equipment
    {
        public int LowDamageBottom { get; set; }
        public int LowDamageTop { get; set; }

        public int HighDamageBottom { get; set; }
        public int HighDamageTop { get; set; }

       


        public Weapon()
        {
            init();
            SetLevel(1);
        }

        //Initierar vapnet till en ursprungsversion
        private void init()
        {
            Name = "Sword";
            
            LowDamageBottom = 15;
            LowDamageTop = 25;
            LowDamage = Generator.RandomNumber(LowDamageBottom, LowDamageTop);

            HighDamageBottom = 40;
            HighDamageTop = 50;
            HighDamage = Generator.RandomNumber(HighDamageBottom, HighDamageTop);

            LowCrit = 1;
            HighCrit = 10;
            CritChance = Generator.RandomNumber(LowCrit, HighCrit);

            

            DropChance = 33;
        }

        //Räknar om statsen att överrensstämma med Level
        public void SetLevel(int level)
        {
            Level = level;

            if (level > 1)
            {
                for (int i = 0; i < Level; i++)
                {
                    IncrementDamage();

                    LowCrit++;
                    HighCrit++;
                    CritChance = Generator.RandomNumber(LowCrit, HighCrit);
                    //Nån specielgrej var tredje level kanske?
                    if (Level % 3 == 0)
                    {

                    }
                }
            }
        }
        private void IncrementDamage()
        {
            LowDamage *= 11;
            HighDamage *= 11;
            LowDamage /= 10;
            HighDamage /= 10;
        }
    }
}
