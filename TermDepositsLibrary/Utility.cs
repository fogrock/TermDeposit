using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermDepositsLibrary
{
    public static class Utility
    {
        public static double GetDoubleRandom(double minimum, double maximum, bool round=true)
        {
            Random random = new Random();
            double result = (round == true) ? Math.Round(random.NextDouble() * (maximum - minimum) + minimum, 2) : (random.NextDouble() * (maximum - minimum) + minimum);
            return result;
        }

        public static int GetIntRandom(int minimum, int maximum)
        {
            Random random = new Random();
            // +1 to include max in the random result
            return random.Next(minimum, maximum + 1);
        }
    }
}
