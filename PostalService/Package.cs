using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService
{
    class Package : Parcel
    {
        public Package(Address senderAddress, Address recipientAddress, double weight, double size)
            : base(senderAddress, recipientAddress, weight, size)
        {
            ShippingCost = CalculatePrice(weight, size);
        }

        public override int CalculatePrice(double weight, double size)
        {
            if (size > 15)
            {
                return 100;
            }
            else
                return 50;
        }

        public static Package CreatePackage()
        {
            Address senderAddress = InputHelper.GetAddress(isSender: true); // Flyttat inmatningen av data till en hjälpklass
            Address recipientAddress = InputHelper.GetAddress(isSender: false);
            double parcelWeight = InputHelper.GetDouble("Paketets vikt:");
            double parcelSize = InputHelper.GetDouble("Paketets storlek:");

            return new Package(recipientAddress, senderAddress, parcelWeight, parcelSize);
        }
    }
}