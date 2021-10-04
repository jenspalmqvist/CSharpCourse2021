using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace RollSpelGrupp6.Classes
{
    public class PlayerDatabase
    {
        private static Dictionary<string, Player> PlayersData = new Dictionary<string, Player>();

        private static string DatabaseName = "PlayersDatabase.json";
        public static List<Player> ListOfTop10Players { get; set; }

        public PlayerDatabase()
        {
            PlayersData = new Dictionary<string, Player>();
        }

        public static void ReadFromPlayerDatabase()
        {
            string playersDataAsJSONString = File.ReadAllText(DatabaseName);
            if (playersDataAsJSONString.Length > 0)
            {
                PlayersData = JsonConvert.DeserializeObject<Dictionary<string, Player>>(playersDataAsJSONString);
            }
            GetTop7Players();
        }

        public static void WriteToPlayerDatabase()
        {
            string playersDataAsJSONString = JsonConvert.SerializeObject(PlayersData);
            File.WriteAllText(DatabaseName, playersDataAsJSONString);
        }

        public static void AddUserToPlayerDatabase(string username, Player player)
        {
            if (PlayersData.TryAdd(username, player))
            {
                return;
            }
            PlayersData[username] = player;
        }

        public static Player GetUserFromPlayerDatabase(string username)
        {
            Player playerToReturn;
            if (PlayersData.TryGetValue(username, out playerToReturn))
            {
                return playerToReturn;
            }
            playerToReturn = new Player();
            playerToReturn.Name = username;
            playerToReturn.DressUp();
            return playerToReturn;
        }

        public static void GetTop7Players()
        {
            ListOfTop10Players = PlayersData.Values.ToList();
            ListOfTop10Players.Sort();
            ListOfTop10Players.Reverse();
            if (ListOfTop10Players.Count > 7)
            {
                ListOfTop10Players = ListOfTop10Players.GetRange(0, 7);
            }
        }

        public static void UpdateListOfTop7Players(Player player)
        {
            if (ListOfTop10Players.Contains(player))
            {
                ListOfTop10Players.Sort();
                ListOfTop10Players.Reverse();
                return;
            }
            if (player.HighScore >= ListOfTop10Players[^1].HighScore)
            {
                ListOfTop10Players.Add(player);
                ListOfTop10Players.Sort();
                ListOfTop10Players.Reverse();
            }
            if (ListOfTop10Players.Count > 7)
            {
                ListOfTop10Players = ListOfTop10Players.GetRange(0, 7);
            }
        }
    }
}