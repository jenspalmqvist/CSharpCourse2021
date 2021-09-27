using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePrinciples.DRY
{
    public class DoNotRepeatYourself
    {
        public void GetAllSums()
        {
            int num1 = 12;
            int num2 = 1;
            int num3 = 123;
            int num4 = 122;
            int num5 = 11112;
            int num6 = 12352;
            int num7 = 1522;
            int num8 = 124;

            int sum1 = num1 + num2;
            int sum2 = num3 + num4;
            int sum3 = num5 + num6;
            int sum4 = num7 + num8;
        }

        public int Sum(int num1, int num2)
        {
            return num1 + num2;
        }
    }
}