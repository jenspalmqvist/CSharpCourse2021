using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService
{
    class Letter : Parcel
    {
        public Letter(Address senderAddress, Address recipientAddress, double weight)
            : base(senderAddress, recipientAddress, weight)
        {
            ShippingCost = CalculatePrice(weight);
        }

        public override int CalculatePrice(double weight, double size = 0)
        {
            return 50;
        }


    }
}