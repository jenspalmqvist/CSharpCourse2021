using RollSpelGrupp6.Classes.UIs;
using RollSpelGrupp6.Structures;
using System;

namespace RollSpelGrupp6.Classes
{
    public class Figure
    {
        public string Name { get; set; }
        public Coordinate Location { get; set; }

        public int HP { get; set; }
        public int MaxHP { get; set; }

        public int Damage { get; set; }
        public int Defence { get; set; }
        public int Dodge { get; set; }
        public int Level { get; set; }

        public Weapon Weapon { get; set; }

        public Armor Armor { get; set; }
        public Helmet Helmet { get; set; }

        public void Preparations()
        {
            Defence += Helmet.Defence + Armor.Defence;
            MaxHP = HP + Helmet.HP + Armor.HP;
            HP = MaxHP;
        }

        public void DressUp()
        {
            Weapon myWeapon = new Weapon();
            myWeapon.SetLevel(Level);
            Helmet myHelmet = new Helmet();
            myHelmet.SetLevel(Level);
            Armor myArmor = new Armor();
            myArmor.SetLevel(Level);

            this.Weapon = myWeapon;
            this.Helmet = myHelmet;
            this.Armor = myArmor;
            this.Preparations();
        }

        public static void CheckStuff(Equipment equipment)
        {
            Console.WriteLine($"Type: {equipment.Name}");

            if (equipment is Weapon)
            {
                Console.WriteLine($"Damage: {equipment.LowDamage} - {equipment.HighDamage}");
                Console.WriteLine($"Crit Chance: {equipment.CritChance} %");
            }
            else
            {
                Console.WriteLine($"Defence: {equipment.Defence}");
                Console.WriteLine($"Extra stuff: {equipment.HP} HP");
            }

            Console.WriteLine();
        }

        public (int, int) DoDamage()
        {
            if (!IsHit())
            {
                return (0, 0);
            }
            int critHit = Generator.OneToHundred();
            Damage = Generator.RandomNumber(this.Weapon.LowDamage, this.Weapon.HighDamage);

            if (this.Weapon.CritChance >= critHit)
            {
                Damage *= 2;

                return (1, Damage);
            }
            return (9, Damage);
        }

        public int TakeDamage(int damage)
        {
            int damageTaken = damage - (Armor.Defence + Helmet.Defence);

            if (damageTaken < 0)
            {
                damageTaken = 0;
            }

            if (damage > (Armor.HP + Helmet.HP))
            {
                HP -= damageTaken;
            }

            if (HP < 0)
            {
                HP = 0;
            }

            return damageTaken;
        }

        public bool IsHit()
        {
            int hit = Generator.OneToHundred();
            if (hit < Dodge)
            {
                return false;
            }

            return true;
        }
    }
}