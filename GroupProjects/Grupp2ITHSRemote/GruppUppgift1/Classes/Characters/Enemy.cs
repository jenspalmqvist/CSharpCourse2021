using System;
using System.Collections.Generic;
using System.Text;

namespace GruppUppgift1
{
    public abstract class Enemy : Character
    {

        //Starting values initialized in constructor
        //const int STARTING_MAX_HP = 15;
        //const int STARTING_DMG = 4;
        //const int STARTING_DEFENSE = 1;

        public char EnemyCharacter { get; set; }
        public int TrackPlayerTime { get; set; }
        public Player Player { get; set; }
        public bool IsAlive { get; set; }
        public List<Enemy> Enemies { get; set; }
        public List<Enemy> DeadEnemies { get; set; }
        public List<Item> Loot { get; set; }
        public int xDirection { get; set; }
        public int yDirection { get; set; }

        //public Enemy()
        //{

        //}
        //public Enemy(int x, int y, char enemyCharacter, Player player, List<Enemy> enemies, List<Enemy> deadEnemies)
        //{
        //    PositionX = x;
        //    PositionY = y;
        //    EnemyCharacter = enemyCharacter;
        //    MaxHealth = STARTING_MAX_HP;
        //    CurrentHealth = MaxHealth;
        //    Damage = STARTING_DMG;
        //    AttackSkill = 5;
        //    Defense = STARTING_DEFENSE;
        //    DefenseSkill = 3;
        //    Player = player;
        //    TrackPlayerTime = 8;
        //    this.Enemies = enemies;
        //    this.DeadEnemies = deadEnemies;
        //    IsAlive = true;
        //    Name = "Goblin";
        //    Loot = new List<Item>() { new Bread() };
        //}
        public void Draw(Map map)
        {
            if (map.mapVisible[PositionY, PositionX])
            {
                Console.ForegroundColor = (IsAlive) ? ConsoleColor.Red : ConsoleColor.Gray;
                Console.SetCursorPosition(PositionX, PositionY);
                Console.Write(EnemyCharacter);
            }
        }

        public void Die()
        {
            IsAlive = false;
            DeadEnemies.Add(this);
            Enemies.Remove(this);
            Player.LootEnemy(Loot[0]);
        }
        public void Navigate(Map map)
        {
            Random rnd = new Random();
            if (xDirection == 0 && yDirection == 0)
            {
                xDirection = rnd.Next(-1, 2);
                yDirection = xDirection != 0 ? 0 : rnd.Next(0, 100) < 50 ? -1 : 1;
            }

            if (yDirection == 0 && map.map[PositionY][PositionX + xDirection] == '#')
            {
                if (map.map[PositionY + 1][PositionX] != '#' || map.map[PositionY - 1][PositionX] != '#')
                {
                    xDirection = 0;
                    yDirection = rnd.Next(0, 100) < 50 ? -1 : 1;
                }
                else
                {
                    yDirection = 0;
                    xDirection *= -1;
                }
                return;
            }
            else if (yDirection == 0)
            {
                if ((map.map[PositionY + 1][PositionX] != '#' || map.map[PositionY - 1][PositionX] != '#') && rnd.Next(0, 100) < 25)
                {
                    xDirection = 0;
                    yDirection = rnd.Next(0, 100) < 50 ? -1 : 1;
                }
                return;
            }
            if (xDirection == 0 && map.map[PositionY + yDirection][PositionX] == '#')
            {
                if (map.map[PositionY][PositionX + 1] != '#' || map.map[PositionY][PositionX - 1] != '#')
                {
                    yDirection = 0;
                    xDirection = rnd.Next(0, 100) < 50 ? -1 : 1;
                }
                else
                {
                    xDirection = 0;
                    yDirection *= -1;
                }
                return;
            }
            else if (xDirection == 0)
            {
                if ((map.map[PositionY][PositionX + 1] != '#' || map.map[PositionY][PositionX - 1] != '#') && rnd.Next(0, 100) < 25)
                {
                    yDirection = 0;
                    xDirection = rnd.Next(0, 100) < 50 ? -1 : 1;
                }
                return;
            }
        }
    }
}
