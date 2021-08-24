using System;
using System.Collections.Generic;
using System.Linq;

namespace InputAndLoops
{
    class Program
    {
        static void Main(string[] args)
        {
            string answer = "";
            var products = new List<string>();
            while (true)
            {
                Console.WriteLine("Ange en produkt med formatet (bokstäver)-(siffror), skriv 'exit' för att avsluta.");
                answer = Console.ReadLine().Trim();
                if (answer.ToLower() == "exit")
                {
                    break;
                }

                if (!answer.Contains('-'))
                {
                    Console.WriteLine("Inget bindestreck!");
                    continue;
                }
                var splitAnswer = answer.Split('-');
                var areLetters = splitAnswer[0].All(char.IsLetter);
                var areNumbers = int.TryParse(splitAnswer[1], out int result);

                //var splitIndex = answer.IndexOf('-');
                //var preSplit = answer.Substring(0, splitIndex);
                //var postSplit = answer.Substring(splitIndex + 1);

                //var letterRegex = new Regex(@"^[A-Za-zåäöÅÄÖ]+$");
                //var numbersRegex = new Regex(@"^[2-4]\d{2}$");

                //var areLetters = letterRegex.IsMatch(preSplit);
                //var areNumbers = numbersRegex.IsMatch(postSplit);

                if (areNumbers)
                {
                    if (result < 200 || result > 500)
                    {
                        Console.WriteLine("Fel till höger om strecket!");
                        continue;
                    }
                }
                if (!areLetters)
                {
                    Console.WriteLine("Fel till vänster om strecket!");
                    continue;
                }

                products.Add(answer);
            }
            Console.WriteLine("Här är dina produkter:");
            foreach (string product in products)
            {
                Console.WriteLine(product);
            }
        }
    }
}