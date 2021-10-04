using System;
using System.Collections.Generic;
using System.Text;

namespace GruppUppgift1.Classes.Characters
{
    class BlindKnight : Enemy
    {
        public BlindKnight(int x, int y, Player player, List<Enemy> enemies, List<Enemy> deadEnemies)
        {
            Random random = new Random();

            PositionX = x;
            PositionY = y;
            IsAlive = true;

            EnemyCharacter = 'K';
            Name = "Blind knight";

            MaxHealth = random.Next(15, 23);
            Damage = random.Next(8, 13);
            AttackSkill = random.Next(1, 2);
            Defense = random.Next(10, 15);
            DefenseSkill = random.Next(1, 2);

            CurrentHealth = MaxHealth;

            TrackPlayerTime = 8;
            Player = player;
            this.Enemies = enemies;
            this.DeadEnemies = deadEnemies;


            Loot = new List<Item>() { new Bread() };
        }
    }
}
