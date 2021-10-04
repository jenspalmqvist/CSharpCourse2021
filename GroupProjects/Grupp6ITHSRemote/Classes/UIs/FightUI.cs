using RollSpelGrupp6.Classes.UIs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace RollSpelGrupp6.Classes
{
    internal class FightUI
    {
        public Player Player { get; set; }
        public Monster Monster { get; set; }

        public Generator Generator { get; set; }

        public FightUI(Generator generator)
        {
            Generator = generator;
        }

        public bool Combat(Player player, Monster monster)
        {
            bool winner = true;
            Player = player;
            Monster = monster;
            int rond = 0;
            bool combat = true;

            while (combat)
            {
                if (monster.IsBoss)
                {
                    Console.Write("[ ");
                    Printer.PrintInColor(ConsoleColor.DarkRed, "BOSS FIGHT", false);
                    Console.Write(" ]\n");
                }
                if (combat)
                {
                    rond++;
                    Console.Write("Du möter en ");
                    Printer.PrintInColor(ConsoleColor.DarkYellow, $"{Monster.Name}");
                    Console.Write($"\n<<<[ "); Printer.PrintInColor(ConsoleColor.Green, $"ROND {rond}", false); Console.WriteLine(" ]>>>\n");
                }

                (int, int) damage = Player.DoDamage();

                PrintFightUIHeader();
                PrintPlayerAttackResults(damage);

                if (Monster.HP < 1)
                {
                    Player.Score = monster.IsBoss ? Player.Score + 3 : Player.Score + 1;
                    if (Player.HighScore < Player.Score)
                    {
                        Player.HighScore = Player.Score;
                    }
                    PlayerDatabase.UpdateListOfTop7Players(Player);
                    Printer.PrintInColor(ConsoleColor.DarkYellow, $"{Monster.Name}", false);
                    Console.WriteLine($" har dräpts.");
                    //Drop();
                    if (!Drop())
                    {
                        Console.ReadKey();
                    }
                    Player.Experience = monster.IsBoss ? Player.Experience + 3 : Player.Experience + 1;
                    if (Player.Experience >= Player.ExperienceBreakpoint)
                    {
                        Player.IncreaseLevel();
                    }
                    combat = false;
                    break;
                }
                else
                {
                    damage = Monster.DoDamage();

                    PrintMonsterAttackResults(damage);
                }

                if (Player.HP < 1)
                {
                    Printer.PrintInColor(ConsoleColor.DarkCyan, $"\n{Player.Name}", false);
                    Printer.PrintInColor(ConsoleColor.DarkRed, " har avlidit. Beklagar.");
                    Player.Lives.LivesLeft--;

                    Player.HP = Player.MaxHP;
                    winner = false;
                    combat = false;
                    //break;
                }

                // Console.WriteLine($"\nEfter Combat-Metoden har {enemy.Name} {enemy.HP} HP kvar.\n");
                Console.WriteLine("===================================>");
                Console.WriteLine("Tryck för att fortsätta \n");
                Console.ReadKey();
                Console.Clear();
            }
            return winner;
        }

        private void PrintPlayerAttackResults((int, int) damage)
        {
            Printer.PrintInColor(ConsoleColor.DarkCyan, $"{Player.Name}", false);
            Console.WriteLine(" anfaller:\n");
            if (damage.Item1 is 1)
            {
                Printer.PrintInColor(ConsoleColor.Green, "Kritisk träff!\n");
            }
            else if (damage.Item1 is 0)
            {
                Printer.PrintInColor(ConsoleColor.Red, "Miss!");
            }
            Printer.PrintInColor(ConsoleColor.DarkCyan, $"{Player.Name}", false);
            Console.Write(" åsamkade ");
            Printer.PrintInColor(ConsoleColor.DarkYellow, $"{Monster.Name}", false);
            Console.WriteLine($" {Monster.TakeDamage(damage.Item2)} skada\n");
            Printer.PrintInColor(ConsoleColor.DarkYellow, $"{Monster.Name}", false);
            Console.WriteLine($" har {Monster.HP} HP left.");
            Console.WriteLine("------------------------------------\n");
        }

        private void PrintMonsterAttackResults((int, int) damage)
        {
            Printer.PrintInColor(ConsoleColor.DarkYellow, $"{Monster.Name}", false);
            Console.WriteLine(" anfaller:\n");
            if (damage.Item1 is 1)
            {
                Printer.PrintInColor(ConsoleColor.Red, "Kritisk träff!\n", false);
            }
            else if (damage.Item1 is 0)
            {
                Printer.PrintInColor(ConsoleColor.Green, "Miss!");
            }
            Printer.PrintInColor(ConsoleColor.DarkYellow, $"{Monster.Name}", false);
            Console.Write(" åsamkade ");
            Printer.PrintInColor(ConsoleColor.DarkCyan, $"{Player.Name}", false);
            Console.WriteLine($" {Player.TakeDamage(damage.Item2)} skada\n");
            Printer.PrintInColor(ConsoleColor.DarkCyan, $"{Player.Name}", false);
            Console.WriteLine($" har {Player.HP} HP left.");
        }

        private void PrintFightUIHeader()
        {
            Printer.PrintInColor(ConsoleColor.DarkCyan, $"{Player.Name}: ", false);
            Console.Write($"{Player.HP} HP   |");
            Printer.PrintInColor(ConsoleColor.DarkYellow, $"   {Monster.Name}: ", false);
            Console.WriteLine($"{Monster.HP} HP");
            Console.WriteLine("===================================>\n");
        }

        public bool Drop()
        {
            var dropChanceList = new int[2];
            CreateDropList(dropChanceList);

            if (DropOrNot(dropChanceList[0]))
            {
                Printer.PrintInColor(ConsoleColor.DarkYellow, $"{Monster.Name}", false);
                Console.WriteLine(" droppade loot ");
                Console.ReadKey();
                Console.Clear();
                TypeOfDrop();
                return true;
            }
            else if (DropPotions(dropChanceList[1]))
            {
                Console.ReadKey();
                return true;
            }

            return false;
        }

        public bool DropPotions(int mark)
        {
            if (mark >= Monster.PotionDropChance)
            {
                Player.Potions++;
                Printer.PrintInColor(ConsoleColor.DarkYellow, $"{Monster.Name}", false);
                Console.WriteLine($" tappade en HP-flaska");
                return true;
            }
            return false;
        }

        public void TypeOfDrop()
        {
            int typeOfEquipmentDrop = Generator.RandomNumber(1, 3);
            if (typeOfEquipmentDrop == 1)
            {
                CompareWeapon();
                bool exchangeEquipment = SwitchOrNot();
                if (exchangeEquipment == true)
                {
                    Player.Weapon = Monster.Weapon;
                }
            }
            else if (typeOfEquipmentDrop == 2)
            {
                CompareArmor(Player.Helmet, Monster.Helmet);
                bool exchangeEquipment = SwitchOrNot();
                if (exchangeEquipment == true)
                {
                    Player.Weapon = Monster.Weapon;
                }
            }
            else if (typeOfEquipmentDrop == 3)
            {
                CompareArmor(Player.Armor, Monster.Armor);
                bool exchangeEquipment = SwitchOrNot();
                if (exchangeEquipment == true)
                {
                    Player.Weapon = Monster.Weapon;
                }
            }
        }

        public int[] CreateDropList(int[] dropChanceList)
        {
            for (int i = 0; i < dropChanceList.Length; i++)
            {
                dropChanceList[i] = Generator.OneToHundred();
            }
            return dropChanceList;
        }

        public bool DropOrNot(int mark)
        {
            if (mark >= Monster.EquipmentDropChance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SwitchOrNot()
        {
            while (true)
            {
                Console.Write("\nVill du byta? J/N: ");

                char svar = Console.ReadKey().KeyChar;
                //svar.ToUpper();
                if (Char.ToUpper(svar) == 'J')
                {
                    return true;
                }
                else if (Char.ToUpper(svar) == 'N')
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Felaktig knapptryckning. Svara 'J' eller 'N'");
                }
            }
        }

        public void CompareWeapon()
        {
            Console.WriteLine("\nDenna har du på dig");
            Console.WriteLine("▼ ▼ ▼ ▼ ▼ ▼ ▼ ▼ ▼ ▼ ▼\n");
            Console.Write($"Typ av utrustning: "); Printer.PrintInColor(ConsoleColor.Magenta, Player.Weapon.Name);
            Console.Write($"\nSkada: "); BestEquipment(Player.Weapon.LowDamage, Monster.Weapon.LowDamage, false); Console.Write("-");
            BestEquipment(Player.Weapon.HighDamage, Monster.Weapon.HighDamage);
            Console.Write($"\nCritical hit chance: "); BestEquipment(Player.Weapon.CritChance, Monster.Weapon.CritChance);

            Console.WriteLine("\n\nDenna kan du byta till");
            Console.WriteLine("▼ ▼ ▼ ▼ ▼ ▼ ▼ ▼ ▼ ▼ ▼\n");
            Console.Write($"Typ av utrustning: "); Printer.PrintInColor(ConsoleColor.Magenta, Player.Weapon.Name);
            Console.Write($"\nSkada: "); BestEquipment(Monster.Weapon.LowDamage, Player.Weapon.LowDamage, false); Console.Write("-");
            BestEquipment(Monster.Weapon.HighDamage, Player.Weapon.HighDamage);
            Console.Write($"\nCritical hit chance: "); BestEquipment(Monster.Weapon.CritChance, Player.Weapon.CritChance);
        }

        public void CompareArmor(Equipment playerEquipment, Equipment monsterEquipment)
        {
            Console.WriteLine("\nDenna har du på dig");
            Console.WriteLine("▼ ▼ ▼ ▼ ▼ ▼ ▼ ▼ ▼ ▼ ▼\n");
            Console.Write($"Typ av utrustning: "); Printer.PrintInColor(ConsoleColor.Magenta, playerEquipment.Name);
            Console.Write($"\nSkydd: "); BestEquipment(playerEquipment.Defence, monsterEquipment.Defence);
            Console.WriteLine();
            Console.Write($"Extra HP: "); BestEquipment(playerEquipment.HP, monsterEquipment.HP);

            Console.WriteLine("\n\nDenna kan du byta till");
            Console.WriteLine("▼ ▼ ▼ ▼ ▼ ▼ ▼ ▼ ▼ ▼ ▼\n");
            Console.Write($"Typ av utrustning: "); Printer.PrintInColor(ConsoleColor.Magenta, monsterEquipment.Name);
            Console.Write($"\nSkydd: "); BestEquipment(monsterEquipment.Defence, playerEquipment.Defence);
            Console.WriteLine();
            Console.Write($"Extra HP: "); BestEquipment(monsterEquipment.HP, playerEquipment.HP);
        }

        public static void BestEquipment(int equipment1, int equipment2, bool newLine = true)
        {
            if (equipment1 > equipment2)
            {
                Printer.PrintInColor(ConsoleColor.DarkGreen, $"{equipment1}", newLine);
            }
            else if (equipment1 < equipment2)
            {
                Printer.PrintInColor(ConsoleColor.DarkRed, $"{equipment1}", newLine);
            }
            else
            {
                Printer.PrintInColor(ConsoleColor.Yellow, $"{equipment1}", newLine);
            }
        }
    }
}