using System;

namespace Adventure_Game
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var game = new Game();

            GameState gameState = GameState.Running;

            while (gameState == GameState.Running)
            {
                gameState = game.Update();
                if (gameState == GameState.Victory) Console.WriteLine("You beat the game, congratulations!");
                if (gameState == GameState.GameOver) Console.WriteLine("You lose! Game Over");
            }
        }
    }
}