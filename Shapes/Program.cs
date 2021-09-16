using System;
using System.Collections.Generic;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            var cc = new ConsoleCompanion();
            Triangle triangle = new Triangle();
            triangle.Width = 5;
            triangle.Height = 4;
            triangle.GetCircumference();
            triangle.GetArea();

            Rectangle rectangle = new Rectangle();
            rectangle.Width = 5;
            rectangle.Height = 4;

            rectangle.GetCircumference();
            rectangle.GetArea();

            Circle circle = new Circle();
            circle.Radius = 5;

            circle.GetArea();
            circle.GetCircumference();

            List<int>
        }
    }

    public abstract class Shape
    {
        public abstract void GetArea();

        public abstract void GetCircumference();
    }

    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override void GetArea()
        {
            //Width * Height;
        }

        public override void GetCircumference()
        {
            //(Width * 2) + (Height * 2);
        }
    }

    public class Triangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override void GetArea()
        {
            Console.WriteLine((Width * Height) / 2);
        }

        public override void GetCircumference()
        {
            Console.WriteLine(((Width * Width) + (Height * Height) / 2) + Width + Height);
        }
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }

        public override void GetArea()
        {
            Console.WriteLine((Radius * Radius) * Math.PI);
        }

        public override void GetCircumference()
        {
            Console.WriteLine((Radius * 2) * Math.PI);
        }
    }
}