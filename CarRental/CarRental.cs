using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental
{
    public class CarRental
    {
        public List<Car> AvailableCars { get; set; }
        public int TotalRevenue { get; set; }

        public CarRental()
        {
            AvailableCars = new List<Car>();
        }
    }
}