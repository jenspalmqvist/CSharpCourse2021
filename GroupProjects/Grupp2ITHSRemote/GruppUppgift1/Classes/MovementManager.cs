using System;
using System.Collections.Generic;
using System.Text;

namespace GruppUppgift1.Classes
{
    public class MovementManager
    {
        public Game GameInstance { get; set; }
        public MovementManager(Game gameInstance)
        {
            GameInstance = gameInstance;
        }
        public void MoveEnemy(Map map, Enemy enemy)
        {
            int distanceX = GameInstance.Player.PositionX - enemy.PositionX;
            int distanceY = GameInstance.Player.PositionY - enemy.PositionY;
            double distanceToPlayer = Math.Sqrt(Math.Pow(distanceX, 2) + Math.Pow(distanceY, 2));

            if (distanceToPlayer > 0 && distanceToPlayer < 5 && enemy.TrackPlayerTime > 0)
            {
                enemy.xDirection = (int)Math.Round(distanceX / distanceToPlayer);
                enemy.yDirection = (int)Math.Round(distanceY / distanceToPlayer);
                enemy.TrackPlayerTime--;
            }
            else
            {
                Random random = new Random();
                enemy.Navigate(GameInstance.Maps[GameInstance.CurrentMap]);
                enemy.TrackPlayerTime = random.Next(4, 8);
            }
            if (map.map[enemy.PositionY + enemy.yDirection][enemy.PositionX + enemy.xDirection] != '#')
            {
                if (enemy.PositionX + enemy.xDirection == GameInstance.Player.PositionX && enemy.PositionY + enemy.yDirection == GameInstance.Player.PositionY)
                {
                    CombatHandler.ResolveAttack(enemy, GameInstance.Player);
                }
                else
                {
                    bool canMove = true;
                    for (int i = 0; i < GameInstance.Enemies.Count; i++)
                    {
                        if (enemy.PositionX + enemy.xDirection == GameInstance.Enemies[i].PositionX && enemy.PositionY + enemy.yDirection == GameInstance.Enemies[i].PositionY)
                        {
                            canMove = false;
                            GameInstance.Enemies[i].xDirection *= -1;
                            GameInstance.Enemies[i].yDirection *= -1;
                        }
                    }
                    if (canMove)
                    {
                        enemy.PositionX += enemy.xDirection;
                        enemy.PositionY += enemy.yDirection;
                    }
                }
            }
        }

        public void CheckMovement(int xMovement, int yMovement)
        {
            if (GameInstance.Maps[GameInstance.CurrentMap].map[GameInstance.Player.PositionY + yMovement][GameInstance.Player.PositionX + xMovement] != '#' &&
                GameInstance.Maps[GameInstance.CurrentMap].map[GameInstance.Player.PositionY + yMovement][GameInstance.Player.PositionX + xMovement] != '|' &&
                GameInstance.Maps[GameInstance.CurrentMap].map[GameInstance.Player.PositionY + yMovement][GameInstance.Player.PositionX + xMovement] != '_')
            {
                bool canMove = true;
                for (int i = 0; i < GameInstance.Enemies.Count; i++)
                {
                    if (GameInstance.Enemies[i].PositionX == GameInstance.Player.PositionX + xMovement &&
                        GameInstance.Enemies[i].PositionY == GameInstance.Player.PositionY + yMovement)
                    {
                        CombatHandler.ResolveAttack(GameInstance.Player, GameInstance.Enemies[i]);
                        canMove = false;
                    }
                }
                if (canMove)
                {
                    GameInstance.Player.Move(xMovement, yMovement, GameInstance.Maps[GameInstance.CurrentMap]);
                }
                GameInstance.Enemies.ForEach(enemy => MoveEnemy(GameInstance.Maps[GameInstance.CurrentMap], enemy));
                GameInstance.UpdateGameField();
            }
        }
    }
}
