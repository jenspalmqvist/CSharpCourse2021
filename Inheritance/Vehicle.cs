using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public abstract class Vehicle
    {
        private static string _brand;

        public string Brand
        {
            get
            {
                return _brand;
            }
            set
            {
                _brand = value;
            }
        }

        public virtual void Honk()
        {
            Console.WriteLine("Honky!");
        }

        public Vehicle(string brand)
        {
            Brand = brand;
        }

        public string GetVehicleInfo()
        {
            return $"Brand: {Brand}";
        }
    }

    public abstract class Car : Vehicle
    {
        public string Model { get; set; }

        public Car(string model, string brand) : base(brand)
        {
            Model = model;
        }

        public override string ToString()
        {
            return base.GetVehicleInfo() + $"Model: {Model}";
        }
    }

    public class ElectricCar : Car
    {
        public override void Honk()
        {
            Console.WriteLine("Hunky!");
        }

        public ElectricCar(string model, string brand) : base(model, brand)
        {
        }
    }

    public class DieselCar : Car
    {
    }

    class Recipe
    {
        public string Name { get; }
        public int CookingTime { get; }
        public List<string> Ingredients { get; }

        public Recipe(string name, int time, List<string> ingredients)
        {
            Name = name;
            CookingTime = time;
            Ingredients = ingredients;
        }
    }

    class Cake : Recipe
    {
        public int NumberOfEggs { get; set; }

        public Cake(string name, int time, List<string> ingredients, int eggs) : base(name, time, ingredients)
        {
            NumberOfEggs = eggs;
        }
    }

    public abstract class Shape
    {
        public int Area { get; set; }
        public int Circumference { get; set; }
    }

    class Rectangle : Shape
    {
    }
}