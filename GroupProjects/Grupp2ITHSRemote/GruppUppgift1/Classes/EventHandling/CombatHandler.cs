using System;
using System.Collections.Generic;
using System.Text;

namespace GruppUppgift1
{
    public static class CombatHandler
    {
        private static Character _attacker;
        private static Character _defender;
        private static int xPos = 80;
        private static int yPos = 2;
        private static int messageWidth = 35;
        private static int roundCounter = 0;
        private static int diceRollMax = 12;


        public static void ResetCombatHandler()
        {
            roundCounter = 0;
            EventDialogBox.Clear(xPos, yPos, 40, 20);
        }

        public static void ResolveAttack(Character attacker, Character defender)
        {
            _attacker = attacker;
            _defender = defender;

            Player player;
            Random rnd = new Random();
            int diceRoll = rnd.Next(1, diceRollMax);

            if (diceRoll == 1)
            {
                _defender.CurrentHealth -= _attacker.Damage;
                CriticalHitMessage(_attacker.Damage);
            }
            else if (diceRoll < (_attacker.AttackSkill - _defender.DefenseSkill))
            {
                int damageDelt = (_attacker.Damage*rnd.Next(7, 11)/10 - _defender.Defense > 0) ? _attacker.Damage - _defender.Defense : 0;
                _defender.CurrentHealth -= damageDelt;
                HitMessage(damageDelt);
            }
            else if (diceRoll == diceRollMax && _attacker is Player)
            {
                CriticalMissMessage();
                player = (Player)_attacker;
                if (player.EquipedWeapon != null)
                {
                    player.EquipedWeapon.UsesLeft--;
                }
                else
                {
                    player.CurrentHealth--;
                }
            }
            else
            {
                MissMessage();
            }
            if (_defender.CurrentHealth <= 0)
            {
                DeathMessage();

                if (_defender is Enemy)
                {
                    Enemy enemy = (Enemy)_defender;
                    enemy.Die();
                }
            }
            
        }
        private static void HitMessage(int damage)
        {
            string message;

            if (_attacker is Player)
            {
                message = $"{_attacker.Name} hit the {_defender.Name.ToLower()} for {damage} damage.";
                BuildAndPrintString(message, ConsoleColor.Green);
            }
            else
            {
                message = $"{_attacker.Name} hits {_defender.Name.ToLower()} for {damage} damage.";
                BuildAndPrintString(message, ConsoleColor.Red);
            }
        }

        private static void MissMessage()
        {
            string message;

            if (_attacker is Player)
            {
                message = $"You swing your weapon in the vicinty of the {_defender.Name.ToLower()}.";
                BuildAndPrintString(message, ConsoleColor.White);
            }
            else
            {
                message = $"The {_attacker.Name.ToLower()} swings its weapon, hitting nothing.";
                BuildAndPrintString(message, ConsoleColor.White);
            }
        }

        private static void CriticalHitMessage(int damage)
        {
            string message;

            if (_attacker is Player)
            {
                message = $"{_attacker.Name} hit the {_defender.Name.ToLower()} for {damage} damage.";
                BuildAndPrintString(message, ConsoleColor.Green);
            }
            else
            {
                message = $"{_attacker.Name} hits {_defender.Name.ToLower()} for {damage} damage.";
                BuildAndPrintString(message, ConsoleColor.Red);
            }
        }

        private static void CriticalMissMessage()
        {
            string message;

            if (_attacker is Player)
            {
                message = $"{_attacker.Name} hit the ground with all your might.";
                BuildAndPrintString(message, ConsoleColor.Red);
            }
            else
            {
                message = $"The {_attacker.Name.ToLower()} swings wildly in the air, streching a muscle.";
                BuildAndPrintString(message, ConsoleColor.Green);
            }
        }

        private static void DeathMessage()
        {
            string message;

            if (_attacker is Player)
            {
                message = $"The {_defender.Name.ToLower()} falls dead to the ground.";
                BuildAndPrintString(message, ConsoleColor.Green);
            }
            else
            {
                message = $"{_defender.Name} fall dead to the ground. The last thing you see is a laughing {_attacker.Name.ToLower()}";
                BuildAndPrintString(message, ConsoleColor.Red);
            }
        }

        private static void BuildAndPrintString(string message, ConsoleColor color)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string[] wordArray = message.Split();
            List<string> messageList = new List<string>();

            for (int i = 0; i < wordArray.Length; i++)
            {
                stringBuilder.Append(wordArray[i]);
                stringBuilder.Append(' ');

                if(i == wordArray.Length - 1)
                {
                    messageList.Add(new string(stringBuilder.ToString()));
                    stringBuilder.Clear();
                }
                else if (stringBuilder.Length + wordArray[i].Length >= messageWidth)
                {
                    messageList.Add(new string(stringBuilder.ToString()));
                    stringBuilder.Clear();
                }
            }

            for (int i = 0; i < messageList.Count; i++)
            {
                roundCounter++;
                EventDialogBox.Print(messageList[i], xPos, yPos + roundCounter, false, color);
            }
        }

    }
}
