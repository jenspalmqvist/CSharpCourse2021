using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRental
{
    public abstract class Vehicle
    {
        public int RentalCost { get; set; }
        public bool IsAvailable { get; set; }
    }
}