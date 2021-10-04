using System;
using System.Collections.Generic;
using System.Text;

namespace GruppUppgift1
{
    class Troll : Enemy
    {
       
        public Troll(int x, int y, Player player, List<Enemy> enemies, List<Enemy> deadEnemies)
        {
            Random random = new Random();

            PositionX = x;
            PositionY = y;
            IsAlive = true;

            EnemyCharacter = 'Ö';
            Name = "Troll";

            MaxHealth = random.Next(25, 35);
            Damage = random.Next(10, 15);
            AttackSkill = random.Next(2, 5);
            Defense = random.Next(6, 10);
            DefenseSkill = random.Next(1, 4);

            CurrentHealth = MaxHealth;

            TrackPlayerTime = 8;
            Player = player;
            this.Enemies = enemies;
            this.DeadEnemies = deadEnemies;
            
            
            Loot = new List<Item>() { new Bread() };
        }
    }
}
