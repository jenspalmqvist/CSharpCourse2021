using System;
using System.Collections.Generic;
using System.Text;

namespace CodePrinciples.SOLID.LiskovSubstitutionPrinciple
{
    class WithLSP
    {
        static void Main(string[] args)
        {
            Orange orange = new Orange();
            Console.WriteLine(orange.GetColor());
            Fruit apple = new Apple();
            Console.WriteLine(apple.GetColor());
            List<Fruit> fruits = new List<Fruit> { orange, apple };
        }
    }

    interface ITemp
    {
        string Tempgrej();
    }

    public abstract class Fruit
    {
        public abstract string GetColor();

        public virtual string GetColor2()
        {
            return "StandardColor";
        }
    }

    public class Apple : Fruit
    {
        public override string GetColor()
        {
            return "Red";
        }

        public override string GetColor2()
        {
            return "Red";
        }
    }

    public class Orange : Fruit
    {
        public override string GetColor()
        {
            return "Orange";
        }
    }
}