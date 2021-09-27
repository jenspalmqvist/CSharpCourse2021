using System;
using System.Collections.Generic;
using System.Text;

namespace PostalService
{
    public abstract class Parcel
    {
        public Address RecipientAddress { get; set; }
        public Address SenderAddress { get; set; }

        public double Weight { get; set; }
        public double Size { get; set; }
        public int ShippingCost { get; set; }

        public Parcel(Address recipientAddress, Address senderAddress, double weight, double size)
        {
            RecipientAddress = recipientAddress;
            SenderAddress = senderAddress;
            Weight = weight;
            Size = size;
        }

        public abstract int CalculatePrice(double weight, double size);
    }
}

/*
 *
 * Parcel -> Package && Letter
 * Parcel -> TraceableParcel -> TraceablePackage && TraceableLetter
 * Parcel -> InsuredParcel -> InsuredPackage osv.
 * Parcel -> TraceableInsuredParcel -> TraceableInsuredPackage
 *
 * Parcel -> Package && Letter
 * TraceablePackage : Package, ITraceable
 * TraceableInsuredPackage : Package, ITraceable, IInsured
 *
 *
 *
 *
 *
 */