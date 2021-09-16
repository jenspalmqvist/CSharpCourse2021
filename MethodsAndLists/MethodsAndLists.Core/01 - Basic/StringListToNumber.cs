
using System;

namespace MethodsAndLists.Core
{
    public class StringListToNumber
    {
        public int ElevatorGoUpAndDown(string[] input)
        {
            int floor = 0;
            foreach (string word in input)
            {
                if(word == "UPP")
                {
                    floor++;
                }
                else
                {
                    floor--;
                }
            }
            return floor;
        }
    }
}
