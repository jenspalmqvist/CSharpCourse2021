using System;
using System.Collections.Generic;

namespace PostalService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till Percys postkontor!");
            List<Letter> letters = new List<Letter>();
            while (true)
            {
                Console.Write("Avsändares namn:");
                string senderName = Console.ReadLine();
                Console.Write("Avsändares gatuadress:");
                string senderStreetAddress = Console.ReadLine();
                Console.Write("Avsändares postnummer:");
                int.TryParse(Console.ReadLine(), out int senderZipCode);
                Console.Write("Avsändares stad:");
                string senderCity = Console.ReadLine();
                Address senderAddress = new Address(senderName, senderStreetAddress, senderZipCode, senderCity);

                Console.Write("Mottagares namn:");
                string recipientName = Console.ReadLine();
                Console.Write("Mottagares gatuadress:");
                string recipientStreetAddress = Console.ReadLine();
                Console.Write("Mottagares postnummer:");
                int.TryParse(Console.ReadLine(), out int recipientZipCode);
                Console.Write("Mottagares stad:");
                string recipientCity = Console.ReadLine();
                Address recipientAddress = new Address(recipientName, recipientStreetAddress, recipientZipCode, recipientCity);

                Console.Write("Paketets vikt:");
                double.TryParse(Console.ReadLine(), out double packageWeight);
                Console.Write("Paketets storlek:");
                double.TryParse(Console.ReadLine(), out double packageSize);

                Letter letter = new Letter(recipientAddress, senderAddress, packageWeight, packageSize);
                letters.Add(letter);
            }
        }
    }
}

/*
 Brev och pakethantering:

- Address
- Portotabell
- Information om paket/brev:
  - Avsändare / Mottagare
  - Produktnamn
  - Ombud/hemleverans
  - Kolli-ID
  - Storlek
  - Vikt
  - Skickat eller inte
- Metod för att skicka försändelsen
- Postcentral/postkontor
 */