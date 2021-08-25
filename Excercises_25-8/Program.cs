using System;

namespace Excercises_25_8
{
    class Program
    {
        static void Main(string[] args)
        {
            AllowedToVote();
            AllowedToVoteOrBuyAlcohol();
            Translate();
            MultiplyFourNumbers();
            OddOrEven();
            SwapVariables();
            NameRetirementAndChar();
            ConvertTemperature();
        }

        private static void ConvertTemperature()
        {
            Console.Write("Skriv en temperatur: ");
            int temperature = int.Parse(Console.ReadLine());
            int fahrenheit = temperature * 9 / 5 + 32;
            int celcius = (temperature - 32) * 5 / 9;
            Console.WriteLine($"Siffrans motsvarighet i Fahrenheit är {fahrenheit} ");
        }

        private static void NameRetirementAndChar()
        {
            Console.Write("Vad heter du? ");
            string name = Console.ReadLine();
            Console.Write("Hur gammal är du? ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Vad är ditt favorittecken? ");
            string favoriteChar = Console.ReadLine();

            Console.WriteLine($"Du heter {name}");
            if (age > 65)
            {
                Console.WriteLine("Du har redan uppnått pensionsålder!");
            }
            else
            {
                Console.WriteLine($"Du har {65 - age} år kvar tills pensionsålder");
            }
            if (char.IsLetter(favoriteChar[0]))
            {
                Console.WriteLine($"Du gillar bokstäver!");
            }
            else
            {
                Console.WriteLine($"Du gillar inte bokstäver!");
            }
        }

        private static void SwapVariables()
        {
            Console.Write("Skriv in det första talet: ");
            int tal1 = int.Parse(Console.ReadLine());
            Console.Write("Skriv in det andra talet: ");
            int tal2 = int.Parse(Console.ReadLine());
            int tempVariabel = tal1;
            tal1 = tal2;
            tal2 = tempVariabel;

            Console.WriteLine($"Det första talet är nu {tal1} och det andra är {tal2}");
        }

        static void OddOrEven()
        {
            Console.Write("Skriv en siffra: ");
            int answer = int.Parse(Console.ReadLine());
            if (answer % 2 == 0)
            {
                Console.WriteLine("Talet är jämnt!");
            }
            else
            {
                Console.WriteLine("Talet är udda!");
            }
        }

        static void AllowedToVote()
        {
            Console.Write("Hur gammal är du? ");
            bool validAge = int.TryParse(Console.ReadLine(), out int age);
            if (validAge)
            {
                if (age >= 18)
                {
                    Console.WriteLine("Du får rösta!");
                }
                else
                    Console.WriteLine("Du får inte rösta än!");
            }
            else
            {
                Console.WriteLine("Felaktig inmatning!");
            }
        }

        static void AllowedToVoteOrBuyAlcohol()
        {
            Console.Write("Hur gammal är du? ");
            bool validAge = int.TryParse(Console.ReadLine(), out int age);
            if (validAge)
            {
                if (age >= 18)
                {
                    if (age >= 20)
                    {
                        Console.WriteLine("Du får handla på systemet!");
                    }
                    Console.WriteLine("Du får rösta!");
                }
                else
                    Console.WriteLine("Du får inte rösta eller handla på systemet än!");
            }
            else
            {
                Console.WriteLine("Felaktig inmatning!");
            }
        }

        static void Translate()
        {
            Console.Write("Skriv in ordet 'utvecklare' på engelska: ");
            string answer = Console.ReadLine();
            if (answer != "developer")
            {
                Console.WriteLine("Fel!");
            }
            else
            {
                Console.WriteLine("Rätt!");
            }
        }

        static void MultiplyFourNumbers()
        {
            Console.Write("Skriv in det första talet: ");
            int tal1 = int.Parse(Console.ReadLine());
            Console.Write("Skriv in det andra talet: ");
            int tal2 = int.Parse(Console.ReadLine());
            Console.Write("Skriv in det tredje talet: ");
            int tal3 = int.Parse(Console.ReadLine());
            Console.Write("Skriv in det fjärde talet: ");
            int tal4 = int.Parse(Console.ReadLine());

            int product = tal1 * tal2 * tal3 * tal4;

            Console.WriteLine($"Produkten av talen är {product}");
        }
    }
}