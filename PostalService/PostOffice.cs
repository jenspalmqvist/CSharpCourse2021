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
            Address senderAddress = GetAddress(isSender: true); // Flyttat inmatningen av data till en hjälpklass
            Address recipientAddress = GetAddress(isSender: false);
            double parcelWeight = GetDouble("Brevets vikt:");
            OutgoingParcels.Add(new Letter(senderAddress, recipientAddress, parcelWeight));
        }

        public void CreatePackage()
        {
            Address senderAddress = GetAddress(isSender: true); // Flyttat inmatningen av data till en hjälpklass
            Address recipientAddress = GetAddress(isSender: false);
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