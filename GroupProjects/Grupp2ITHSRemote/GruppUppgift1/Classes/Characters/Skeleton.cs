using System;
using System.Collections.Generic;
using System.Text;

namespace GruppUppgift1
{
    class Skeleton : Enemy
    {
        public Skeleton(int x, int y, Player player, List<Enemy> enemies, List<Enemy> deadEnemies)
        {
            Random random = new Random();

            PositionX = x;
            PositionY = y;
            IsAlive = true;

            EnemyCharacter = '%';
            Name = "Skeleton";

            MaxHealth = random.Next(8, 14);
            Damage = random.Next(6, 10);
            AttackSkill = random.Next(5, 8);
            Defense = random.Next(2, 5);
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
