using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePrinciples.SOLID.LiskovSubstitutionPrinciple
{
    class WithoutLSP
    {
        static void App()
        {
            AppleWithoutLSP apple = new OrangeWithoutLSP();
            Console.WriteLine(apple.GetColor());
        }
    }

    public class AppleWithoutLSP
    {
        public virtual string GetColor()
        {
            return "Red";
        }
    }

    public class OrangeWithoutLSP : AppleWithoutLSP
    {
        public override string GetColor()
        {
            return "Orange";
        }
    }
}