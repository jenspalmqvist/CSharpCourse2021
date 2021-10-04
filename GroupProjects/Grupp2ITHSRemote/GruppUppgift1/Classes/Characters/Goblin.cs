using System;
using System.Collections.Generic;
using System.Text;

namespace GruppUppgift1.Classes.Characters
{
    class Goblin : Enemy
    {
        public Goblin(int x, int y, Player player, List<Enemy> enemies, List<Enemy> deadEnemies)
        {
            Random random = new Random();

            PositionX = x;
            PositionY = y;
            IsAlive = true;

            EnemyCharacter = 'g';
            Name = "Goblin";

            MaxHealth = random.Next(5, 10);
            Damage = random.Next(3, 6);
            AttackSkill = random.Next(5, 8);
            Defense = random.Next(1, 4);
            DefenseSkill = random.Next(3, 6);

            CurrentHealth = MaxHealth;

            TrackPlayerTime = 8;
            Player = player;
            this.Enemies = enemies;
            this.DeadEnemies = deadEnemies;


            Loot = new List<Item>() { new Bread() };
        }
    }
}
