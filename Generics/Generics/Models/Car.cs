namespace Generics.Models
{
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return $"Car brand is {Brand}, the model is {Model} and from the year {Year}";
        }
    }
}
