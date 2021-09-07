using System;
using System.Collections.Generic;
using System.Text;

namespace BicycleRenting
{
    enum BicycleType
    {
        Unicycle,
        Tandem,
        ElectricBike,
        MountainBike
    }

    enum Brand
    {
        Scott,
        Monark,
        Kronans,
        DBS,
        Crescent
    }

    class Bicycle
    {
        public BicycleType Type { get; set; }
        public Brand Brand { get; set; }
        public bool NeedsMaintenance { get; set; }
        public bool IsAvailable { get; set; }
        public int Price { get; set; }
        public BicycleRental CurrentRentalPlace { get; set; }
        //public int TireSize { get; set; }
        //public int NumberOfGears { get; set; }

        public Bicycle(BicycleType type, Brand brand, int price)
        {
            Type = type;
            Brand = brand;
            Price = price;
            NeedsMaintenance = false;
            IsAvailable = true;
        }

        public override string ToString()
        {
            return $"This is an {Type} from {Brand}, it costs {Price} kr to rent and is " +
                $"{(IsAvailable ? "available" : "not available")}. It is currently stationed at {CurrentRentalPlace.Name}.";
        }
    }
}