using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRental
{
    public class Car : Vehicle
    {
        public int Mileage { get; set; }

        public Car(int rentalCost, bool isAvailable, int mileage)
        {
            RentalCost = rentalCost;
            IsAvailable = isAvailable;
            Mileage = mileage;
        }
    }
}