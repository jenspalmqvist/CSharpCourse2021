using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental
{
    public class Car
    {
        public string Brand { get; set; }
        public int DailyPrice { get; set; }
        public int Mileage { get; set; }
        public int Revenue { get; set; }

        public Car(string brand, int dailyPrice, int mileage)
        {
            Brand = brand;
            DailyPrice = dailyPrice;
            Mileage = mileage;
        }

        public void Rent(int days, int dailyAverageMileage)
        {
            Revenue += days * DailyPrice;
            Mileage += days * dailyAverageMileage;
        }

        public override string ToString()
        {
            return $"This {Brand} has run {Mileage} kilometers and generated {Revenue} kr.";
        }
    }
}