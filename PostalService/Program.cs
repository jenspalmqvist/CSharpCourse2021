using System;
using System.Collections.Generic;
using System.Dynamic;
using static PostalService.InputHelper;

namespace PostalService
{
    class Program
    {
        static void Main(string[] args)
        {
            var organization = CreateOrganization();
            Console.WriteLine("Välkommen till Percys postkontor!");
            while (true)
            {
                PostOffice currentOffice = organization.SelectPostOffice();

                //currentOffice.CreateLetter();
                //currentOffice.CreateLetter();
                currentOffice.CreateTraceableLetter();

                string location = organization.TrackParcel(1234);
                Console.WriteLine(location);
                organization.SendParcels();
                location = organization.TrackParcel(1234);
                Console.WriteLine(location);

                Console.ReadLine();
            }
        }

        static PostalOrganization CreateOrganization()
        {
            PostalOrganization organization = new PostalOrganization();
            organization.PostOffices.Add(new PostOffice("Stockholm", 10000, 20000));
            organization.PostOffices.Add(new PostOffice("Resten", 20000, 99999));
            return organization;
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