using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalEntityFramework
{
    internal static class InputHelper
    {
        public static int GetInt()
        {
            bool validInput = false;
            int result = 0;
            while (!validInput)
            {
                validInput = int.TryParse(Console.ReadLine(), out result);
            }
            return result;
        }
    }
}
