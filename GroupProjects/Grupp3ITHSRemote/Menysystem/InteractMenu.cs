using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rollspel
{
    public class InteractiveMenu
    {
        public enum Uses
        {
            Inventory,
            Eat,
            Kick,
            Nothing
        }

        public static int AnchorX { get; set; } = 4;
        public static int AnchorY { get; set; } = 29;
        public static int MenuWidth { get; set; } = 81;
        public static int MenuHeight { get; set; } = 15;
        public string Message { get; set; }
        public Uses Do { get; set; }

        public InteractiveMenu(string message, Uses use)
        {
            Message = message;
            Do = use;
        }

        public void PrintChoices(Dictionary<string, Uses> choices, Item selecteditem)
        {
            bool stop = false;
            while (!stop)
            {
                int counter = 0;
                foreach (var item in choices)
                {
                    counter++;
                    Console.SetCursorPosition(AnchorX+1, AnchorY+4);
                    Console.WriteLine(counter + ". " + item.Key);
                }

                Regex rx = new Regex(@"[1-3]");
                Console.SetCursorPosition(AnchorX+1, AnchorY + 5);
                string userChoice = Console.ReadLine();
                bool isNumber = rx.IsMatch(userChoice);
                int userChoiceInt = 0;
                if (isNumber)
                {
                    userChoiceInt = Convert.ToInt32(userChoice);
                }
                else
                {
                    Console.SetCursorPosition(AnchorX, AnchorY + 1);
                    Console.WriteLine("Felaktig inmatning! Välj mellan 1 och 3.");
                    continue;
                }

                switch (choices.ElementAt(userChoiceInt - 1).Value)
                {
                    case Uses.Nothing:
                        Console.SetCursorPosition(AnchorX, AnchorY + 2);
                        Console.WriteLine($"Du kan inte {choices.ElementAt(userChoiceInt - 1).Key.ToLower()} här.");
                        continue;

                    case Uses.Eat:
                        // Kod för att äta
                        break;

                    case Uses.Inventory:
                        // Kod för att lägga till i inventory
                        break;

                    case Uses.Kick:

                        selecteditem.Use();

                        stop = true;

                        break;
                }
            }
        }
    }
}