using System;
using System.Security.Cryptography.X509Certificates;

namespace Adventure_Game
{
    internal class CoinTracker
    {
        public CoinTracker()
        {
        }

        public int coinAmount = 0;

        public void TrackMap(Map map)
        {
            coinAmount = 0;
            for (int y = 0; y < map.GetYDimension(); y++)

            {
                for (int x = 0; x < map.GetXDimension(); x++)
                {
                    if (map.GetPosContent(y, x) == Graphics.Coin)

                        coinAmount++;
                }
            }
        }

        public GameState CoinCollected()
        {
            coinAmount--;
            if (coinAmount == 0)
            {
                return GameState.LevelComplete;
            }
            else
            {
                return GameState.Running;
            }
        }
    }
}