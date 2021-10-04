using System;
using System.Collections.Generic;
using System.Text;

namespace Adventure_Game
{
    internal enum GameState
    {
        Running,
        CoinCollected,
        EnemyEncountered,
        LevelComplete,
        Victory,
        GameOver
    }
}