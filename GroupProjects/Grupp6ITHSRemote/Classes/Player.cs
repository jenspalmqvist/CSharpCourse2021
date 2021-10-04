using RollSpelGrupp6.Structures;
using System;

namespace RollSpelGrupp6.Classes
{
    public class Player : Figure, IComparable<Player>
    {
        public int HighScore { get; set; }
        public int Score { get; set; }
        public Lives Lives { get; set; }
        public int Potions { get; set; }
        public int baseHP { get; set; }
        public int baseDefense { get; set; }
        public Inventory PlayerInventory { get; set; }
        public int Experience { get; set; }
        public int ExperienceBreakpoint { get; set; }
        public Coordinate NewPlayerLocation { get; set; }

        public Player()
        {
            Score = 0;
            baseHP = 100;
            baseDefense = 20;
            Defence += baseDefense;
            Lives = new Lives();
            PlayerInventory = new Inventory();
            Location = new Coordinate(1, 1 + 30);//offsetting game grid to right by 30
            Name = "Sir Kurt";
            Level = 1;
            HP = baseHP;
            Dodge = 5;
            Experience = 0;
            ExperienceBreakpoint = 2;
            Potions = 3;
        }

        public void IncreaseLevel()
        {
            Level++;
            Experience -= ExperienceBreakpoint;
            ExperienceBreakpoint = ExperienceBreakpoint * 3 / 2;
            MaxHP = MaxHP * 11 / 10;
            HP = MaxHP;
        }

        public void TakePotion()
        {
            Potions--;
            HP = MaxHP;
        }

        public void ResetPlayer()
        {
            Lives.LivesLeft = 3;
            Score = 0;
            baseHP = 100;
            Location = new Coordinate(1, 1 + 30);//offsetting game grid to right by 30
            Level = 1;
            HP = baseHP;
            Dodge = 5;
            Experience = 0;
            ExperienceBreakpoint = 2;
            Potions = 3;
        }

        public int CompareTo(Player player)
        {
            return HighScore.CompareTo(player.HighScore);
        }

        public override bool Equals(object obj)
        {
            return obj is Player player &&
                   Name == player.Name &&
                   HighScore == player.HighScore;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, HighScore);
        }
    }
}