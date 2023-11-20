using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballTeamRegistration
{
    public static class Utility
    {

        internal static FootballPosition SelectEnum(string label, int start, int end, int v, int p)
        {
               int outValue;

            do
            {
                Console.Write(label);
            }
            while(!(int.TryParse(Console.ReadLine(), out outValue) && IsRangeValid(outValue, start, end, v, p)));

            return (FootballPosition)outValue;
        }
        public static bool IsRangeValid(int value, int start , int v, int p, int end)
        {
            return value >= start && value <= end;
        }
    }
}