using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grupparbete1.GameObjects;
using Grupparbete1.MapData;

namespace Grupparbete1
{
    public class Riddle
    {
        private string _text;
        private ConsoleKey _correctAnswerKey;
        private string _answerString;
        private bool _wasLastAnswerWrong;

        public static List<Riddle> Generate()
        {
            var riddleList = new List<Riddle>();

            List<string> riddleTexts = new List<string>()
            {
                "I am always hungry and will die if not fed, but whatever I touch will soon turn red. What am I?",
                "I have lakes with no water, mountains with no stone, and cities with no buildings. What am I?",
                "I have eyes but I can't see. I live in the dark until you need me. What am I?"
            };

            List<ConsoleKey> riddleAnswerKeys = new List<ConsoleKey>()
            {
                ConsoleKey.D2,
                ConsoleKey.D1,
                ConsoleKey.D2
            };

            List<string> riddleAnswerStrings = new List<string>()
            {
                "Probably not a cat#Fire#Almost a dog?",
                "A map#A desert",
                "Batman#A potato"
            };

            if (riddleTexts.Count == riddleAnswerKeys.Count && riddleTexts.Count == riddleAnswerStrings.Count)
            {
                for(int i = 0; i < riddleTexts.Count; i++)
                {
                    riddleList.Add(new Riddle(riddleTexts[i], riddleAnswerKeys[i], riddleAnswerStrings[i]));
                }
            }

            return riddleList;
        }

        public Riddle(string text, ConsoleKey correctAnswerKey, string answerString)
        {
            _text = text;
            _correctAnswerKey = correctAnswerKey;
            _answerString = answerString;
            _wasLastAnswerWrong = false;
        }

        public void PrintRiddle()
        {
            Program.Game.MessageLog.ClearQueue();

            if (_wasLastAnswerWrong) 
            {
                Program.Game.MessageLog.Add("Fel svar, gissa igen.");
            }

            Program.Game.MessageLog.Add(_text);

            var answerOptions = _answerString.Split('#');

            for (int i = 0; i < answerOptions.Length; i++)
            {
                Program.Game.MessageLog.Add($"{i + 1}. {answerOptions[i]}");
            }

            Console.SetCursorPosition(1, Console.GetCursorPosition().Top + 1);
        }
        public void Guess(ConsoleKey input)
        {
            if (input == _correctAnswerKey)
            {
                Program.Game.MessageLog.Add("Rätt svar!");
                Program.Game.CurrentMode = ControlMode.Movement;
                Program.Game.GameMap.CurrentRoom.ExitDoor.Open();
                Program.Game.GameMap.GameObjects.Remove(Program.Game.GameMap.CurrentRiddleTablet);
                
            }
            else
            {
                _wasLastAnswerWrong = true;
                PrintRiddle();
            }

        }
    }
}
