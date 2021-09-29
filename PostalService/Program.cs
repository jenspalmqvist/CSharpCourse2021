using System;
using System.Collections.Generic;
using System.Dynamic;

namespace PostalService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till Percys postkontor!");
            List<Parcel> parcels = new List<Parcel>(); // Ändrat till lista med Parcels för att kunna lägga till både brev och paket

            while (true)
            {
                Parcel parcel;
                Console.WriteLine();
                Console.WriteLine("Vad vill du skicka?");
                Console.WriteLine("1. Paket");
                Console.WriteLine("2. Brev");
                int parcelType = InputHelper.GetInt("Välj ett av alternativen ovan: ");
                switch (parcelType)
                {
                    case 1:
                        parcel = Package.CreatePackage(); // Flyttat inmatningen in i klasserna
                        break;

                    case 2:
                        parcel = Letter.CreateLetter(); // Flyttat inmatningen in i klasserna
                        break;

                    default:
                        continue;
                }
                parcels.Add(parcel);
                Console.ReadLine();
            }
        }
    }
}

/*
 * Postombud/Postservice:

- Pakethantering/-förvaring

- Paket/Brev
  - Avsändare
  - Mottagare
  - Vikt
  - Storlek

- Spårbara försändelser
  - Kolli-ID

- Försäkrade försändelser
  - Värde

 */