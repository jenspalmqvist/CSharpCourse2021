using System;

namespace RollSpelGrupp6
{
    internal class Generator
    {
        public static Random Rnd { get; set; }

        public Generator()
        {
            Rnd = new Random();
        }

        public static int RandomNumber(int lowNum, int highNum)
        {
            return Rnd.Next(lowNum, highNum + 1);
        }

        public static int OneToHundred()
        {
            return Rnd.Next(1, 101);
        }

        public static int[] RandomNumberList(int[] randomNumberList, int lowNumber, int highNumber)
        {
            for (int i = 0; i < randomNumberList.Length; i++)
            {
                randomNumberList[i] = Generator.RandomNumber(lowNumber, highNumber);
            }
            return randomNumberList;
        }
    }
}