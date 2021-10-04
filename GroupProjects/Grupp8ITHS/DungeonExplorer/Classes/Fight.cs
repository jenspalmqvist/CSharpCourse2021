using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Fight
    {
        public static void Fights()
        {
            NPC currentNpc = PickRandomNpc();
            PrintEncounter(currentNpc);
            bool fightOngoing = true;
            while (fightOngoing)
            {
                Console.Clear();
                PrintPlayerOptions(currentNpc);
                if (int.TryParse(Console.ReadLine(), out int playerOption) && playerOption == 1 || playerOption == 2) { }
                else { Console.WriteLine("\nWrong input!"); Console.WriteLine("Try again, choose between 1-2!"); Console.ReadKey(); }
                Random random = new Random();
                int rnd = random.Next(1, 11);

                switch (playerOption)
                {
                    case 1:
                        if (rnd == 1)
                        {
                            NpcDamage(currentNpc);
                            PrintMiss(currentNpc);
                            if (CheckLoss()) { fightOngoing = false; }
                        }
                        else if (rnd == 2 || rnd == 3)
                        {
                            PlayerCrit(currentNpc);
                            PrintCritDmg(currentNpc);
                            if (CheckWin(currentNpc)) { fightOngoing = false; }
                            if (fightOngoing)
                            {
                                NpcDamage(currentNpc);
                                PrintNpcDamage(currentNpc);
                                if (CheckLoss()) { fightOngoing = false; }
                            }
                        }
                        else
                        {
                            PlayerAtk(currentNpc);
                            PrintDmg(currentNpc);
                            if (CheckWin(currentNpc)) { fightOngoing = false; }
                            if (fightOngoing)
                            {
                                NpcDamage(currentNpc);
                                PrintNpcDamage(currentNpc);
                                if (CheckLoss()) { fightOngoing = false; }
                            }
                        }
                        break;

                    case 2:
                        if (rnd < 4)
                        {
                            NpcDamage(currentNpc);
                            PrintFailedEscape(currentNpc);
                            if (CheckLoss()) { fightOngoing = false; }
                        }
                        else
                        {
                            Console.WriteLine("You've managed to escape!");
                            Console.ReadKey();
                            fightOngoing = false;
                        }
                        break;
                }
            }
        }
        public static void PrintEncounter(NPC currentNpc)
        {
            Console.Clear();
            Console.WriteLine("You have encountered " + currentNpc.Name + "!");
            Console.WriteLine("Prepare to fight it!\n\nPress any button to continue");
            Thread.Sleep(2000);
            Console.ReadKey();
        }
        public static void PrintPlayerOptions(NPC currentNpc)
        {
            Console.WriteLine(Game.player.Name + " Health: " + Game.player.Health + "    " + currentNpc.Name + " Health: " + currentNpc.Health);
            Console.WriteLine(Game.player.Name + " Damage: " + Game.player.BaseDamage + "     " + currentNpc.Name + " Damage: " + currentNpc.Damage);
            Console.Write("\nSelect - [1] Attack or [2] Escape: ");
        }
        public static void PrintCritDmg(NPC currentNpc)
        {
            Console.WriteLine("\nCrtical Attack hit!");
            Console.WriteLine("\nYou've hit the" + currentNpc.Name + "for " + (Game.player.BaseDamage * 2) + " damage!");
        }
        public static void PrintDmg(NPC currentNpc)
        {
            Console.WriteLine("\nAttack hit!");
            Console.WriteLine("\nYou've hit the " + currentNpc.Name + " for " + Game.player.BaseDamage + " damage!");
        }
        public static void PrintMiss(NPC currentNpc)
        {
            Console.WriteLine("\nYou've missed!");
            Console.WriteLine(currentNpc.Name + " hit you for " + currentNpc.Damage + " damage!");
            Console.WriteLine("\nPress any button to continue!");
            Console.ReadKey();
        }
        public static void PrintNpcDamage(NPC currentNpc)
        {
            Console.WriteLine(currentNpc.Name + " hit you for " + currentNpc.Damage + " damage!");
            Console.WriteLine("\nPress any button to continue!");
            Console.ReadKey();
        }
        public static void PrintFailedEscape(NPC currentNpc)
        {
            Console.WriteLine("\nYou've failed to escape");
            Console.WriteLine(currentNpc.Name + " hit you for " + currentNpc.Damage + " damage!");
            Console.WriteLine("\nPress any button to continue!");
            Console.ReadKey();
        }
        public static void NpcDamage(NPC currentNpc)
        {
            Game.player.Health = Game.player.Health - currentNpc.Damage;
        }
        private static void PlayerCrit(NPC currentNpc)
        {
            currentNpc.Health = currentNpc.Health - (Game.player.BaseDamage * 2);
        }
        private static void PlayerAtk(NPC currentNpc)
        {
            currentNpc.Health = currentNpc.Health - Game.player.BaseDamage;
        }
        private static NPC PickRandomNpc()
        {
            Random random = new Random();
            NPC randomNpc = Game.NPCList[random.Next(0, Game.NPCList.Count)];
            NPC newNpc = new NPC();
            newNpc.Name = randomNpc.Name;
            newNpc.Health = randomNpc.Health;
            newNpc.Damage = randomNpc.Damage;
            return newNpc;
        }
        private static bool CheckWin(NPC currentNpc)
        {
            if (currentNpc.Health <= 0)
            {
                Console.WriteLine("\nYou have won the fight!");
                Console.ReadKey();
                return true;
            }
            return false;
        }
        private static bool CheckLoss()
        {
            if (Game.player.Health <= 0)
            {
                Console.WriteLine("\nYou have lost the fight!");
                Console.ReadKey();
                return true;
            }
            return false;
        }
    }
}
