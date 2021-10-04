using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService
{
    static class InputHelper
    {
        static public Address GetAddress(AddressType addressType)
        {
            // om addressType är AddressType.Sender sätts addressee till "Avsändarens", annars till "Mottagarens"
            string addressee = addressType == AddressType.Sender ? "Avsändarens" : "Mottagarens";

            /*
             * Ternaryn ( dvs 'addressType == AddressType.Sender ? "Avsändarens" : "Mottagarens"' ) motsvarar:
             * if(addressType == AddressType.Sender)
             * {
             * addressee = "Avsändarens";
             * }
             * else
             * {
             * addressee = "Mottagarens";
             * }
             */

            Console.Write($"{addressee} namn:");
            string name = Console.ReadLine();
            Console.Write($"{addressee} gatuadress:");
            string streetAddress = Console.ReadLine();
            int zipCode = GetInt($"{addressee} postnummer:");
            Console.Write($"{addressee} stad:");
            string city = Console.ReadLine();
            return new Address(name, streetAddress, zipCode, city);
        }

        static public double GetDouble(string question)
        {
            (int left, int top) = Console.GetCursorPosition(); // Koordinater för skrivhuvudet när vi kommer in i metoden
            double result;
            bool validInput;
            do
            {
                Console.Write(question);
                validInput = double.TryParse(Console.ReadLine(), out result);
                if (!validInput)
                {
                    ClearCurrentLine(left, top); // Om inmatningen inte är korrekt, töm raden vi var på när vi kom in i metoden
                }
            } while (!validInput);
            return result;
        }

        static public int GetInt(string question)
        {
            (int left, int top) = Console.GetCursorPosition();  // Koordinater för skrivhuvudet när vi kommer in i metoden

            int result;
            bool validInput;
            do
            {
                Console.Write(question);
                validInput = int.TryParse(Console.ReadLine(), out result);
                if (!validInput)
                {
                    ClearCurrentLine(left, top); // Om inmatningen inte är korrekt, töm raden vi var på när vi kom in i metoden
                }
            } while (!validInput);
            return result;
        }

        static public int GetInt(string question, int min, int max)
        {
            (int left, int top) = Console.GetCursorPosition();  // Koordinater för skrivhuvudet när vi kommer in i metoden

            int result;
            bool validInput;
            do
            {
                Console.Write(question);
                validInput = int.TryParse(Console.ReadLine(), out result);
                if (!validInput || (result < min || result > max))
                {
                    ClearCurrentLine(left, top); // Om inmatningen inte är korrekt, töm raden vi var på när vi kom in i metoden
                }
            } while (!validInput);
            return result;
        }

        static void ClearCurrentLine(int left, int top)
        {
            Console.SetCursorPosition(left, top); // Sätt skrivhuvudet på stället det var på innan vi ställde frågan
            Console.Write(new String(' ', Console.WindowWidth)); // Skapa en sträng med ' ' (mellanslag) som är lika bred som fönstret
            Console.SetCursorPosition(left, top); // Sätt skrivhuvudet på stället det var på innan vi ställde frågan igen så att frågan skrivs ut på samma plats som innan.
        }
    }
}