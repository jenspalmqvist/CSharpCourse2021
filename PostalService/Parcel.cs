using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService
{
    abstract class Parcel
    {
        public Address SenderAddress { get; set; }
        public Address RecipientAddress { get; set; }
        public double Weight { get; set; }
        public double Size { get; set; }
        public int ShippingCost { get; set; }

        // Konstruktor för saker som kräver en storlek
        public Parcel(Address senderAddress, Address recipientAddress, double weight, double size)
        {
            SenderAddress = senderAddress;
            RecipientAddress = recipientAddress;
            Weight = weight;
            Size = size;
        }

        // Konstruktor för saker som inte behöver en storlek
        public Parcel(Address senderAddress, Address recipientAddress, double weight)
        {
            SenderAddress = senderAddress;
            RecipientAddress = recipientAddress;
            Weight = weight;
        }

        // Metod som måste implementeras av klasserna som ärver Parcel
        public abstract int CalculatePrice(double weight, double size);
    }
}