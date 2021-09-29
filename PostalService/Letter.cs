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

        public static Letter CreateLetter()
        {
            Address senderAddress = InputHelper.GetAddress(isSender: true); // Flyttat inmatningen av data till en hjälpklass
            Address recipientAddress = InputHelper.GetAddress(isSender: false);
            double parcelWeight = InputHelper.GetDouble("Brevets vikt:");
            return new Letter(recipientAddress, senderAddress, parcelWeight);
        }
    }
}