using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PostalService
{
    public class Letter : Parcel
    {
        public Letter(Address recipientAddress, Address senderAddress, double weight, double size)
            : base(recipientAddress, senderAddress, weight, size)
        {
            ShippingCost = CalculatePrice(weight, size);
        }

        public override int CalculatePrice(double weight, double size)
        {
            return 50;
        }
    }
}