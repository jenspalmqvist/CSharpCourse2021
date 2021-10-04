using RollSpelGrupp6.Structures;

namespace RollSpelGrupp6.Classes
{
    public class Monster : Figure
    {
        public bool IsBoss { get; set; }
        public int EquipmentDropChance = 40;
        public int PotionDropChance = 33;
        public int BaseHP { get; set; }

        public Monster(int level, int row, int col, bool isBoss = false)
        {
            Location = new Coordinate(row, col + 30);//offsetting game grid to right by 30
            IsBoss = isBoss;
            Level = level;
            BaseHP = 30;

            if (isBoss)
            {
                Name = "Anti-Vaccer: Karen";
            }
            else
            {
                Name = "Plattjordare";
            }

            HP = BaseHP + (10 * level);
            Dodge = 5;
        }

        //Preparations
        public void PrepareMonster()
        {
            Defence = Helmet.Defence + Armor.Defence;
            HP = Helmet.HP + Armor.HP;
        }
    }
}