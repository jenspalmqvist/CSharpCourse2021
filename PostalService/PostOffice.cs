using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static PostalService.InputHelper;

namespace PostalService
{
    class PostOffice
    {
        public List<Parcel> OutgoingParcels { get; set; } = new List<Parcel>();
        public List<Parcel> RecievedParcels { get; set; } = new List<Parcel>();
        public string OfficeName { get; set; }
        public int HandlesZipCodesFrom { get; set; }
        public int HandlesZipCodesUpTo { get; set; }

        public PostOffice(string name, int zipcodesFrom, int zipCodesUpTo)
        {
            OfficeName = name;
            HandlesZipCodesFrom = zipcodesFrom;
            HandlesZipCodesUpTo = zipCodesUpTo;
        }

        public void CreateLetter()
        {
            Address senderAddress = GetAddress(AddressType.Sender); // Flyttat inmatningen av data till en hjälpklass
            Address recipientAddress = GetAddress(AddressType.Recipient);
            double parcelWeight = GetDouble("Brevets vikt:");
            OutgoingParcels.Add(new Letter(senderAddress, recipientAddress, parcelWeight));
        }

        public void CreateTraceableLetter()
        {
            Random random = new Random();
            Address senderAddress = GetAddress(AddressType.Sender); // Flyttat inmatningen av data till en hjälpklass
            Address recipientAddress = GetAddress(AddressType.Recipient);
            double parcelWeight = GetDouble("Brevets vikt:");
            int trackingNumber = random.Next(1000, 10000);
            // 'this' hänvisar till objektet vi använder för att kalla på metoden CreateTraceableLetter,
            // dvs kontoret vi har valt att jobba med i menyn
            OutgoingParcels.Add(new TraceableLetter(senderAddress, recipientAddress, parcelWeight, this, 1234));
        }

        public void CreatePackage()
        {
            Address senderAddress = GetAddress(AddressType.Sender); // Flyttat inmatningen av data till en hjälpklass
            Address recipientAddress = GetAddress(AddressType.Recipient);
            double parcelWeight = GetDouble("Paketets vikt:");
            double parcelSize = GetDouble("Paketets storlek:");

            OutgoingParcels.Add(new Package(senderAddress, recipientAddress, parcelWeight, parcelSize));
        }
    }
}

/*
 * Lagerhållning / Antal paket / Sortering
 * Skickat / inte skickat
 * Kolli-ID
 * Namn / Plats
 *
 *
 */