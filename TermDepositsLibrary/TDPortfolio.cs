using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermDepositsLibrary
{
    public static class TDPortfolio
    {
        const int mn = 1000000;
        public static List<TermDeposit> GetTDPortfolio(int numberHoldings = 50, int minInitMaturValueMn = 70, int maxInitMaturValueMn = 100, int minMaturValMn = 50, int maxMaturValMn = 120)
        {
            List<TermDeposit> termDepositPortfolio = new List<TermDeposit>();

            double totalPortfolioValue = Utility.GetDoubleRandom(minInitMaturValueMn * mn, maxInitMaturValueMn * mn);
            double totalLargeDepositsValue = totalPortfolioValue - minMaturValMn * mn;

            double ldpv = 0;
            while (ldpv < totalLargeDepositsValue)
            {
                TermDeposit td = GetTermDeposit(true);
                termDepositPortfolio.Add(td);
                ldpv += td.maturityAmount;
            }

            while (ldpv < totalPortfolioValue)
            {
                TermDeposit td = GetTermDeposit();
                termDepositPortfolio.Add(td);
                ldpv += td.maturityAmount;
            }

            return termDepositPortfolio;
        }

        public static TermDeposit GetTermDeposit(bool large = false)
        {
            double tdPrinciple = large == true ? Utility.GetDoubleRandom(3 * mn, 5 * mn) : Utility.GetDoubleRandom(1 * mn, 3 * mn);
            int tdTerm = Utility.GetIntRandom(1, 10);
            int year = DateTime.Now.Year - Utility.GetIntRandom(1, tdTerm - 1);
            string month = $"{Utility.GetIntRandom(1, 12):00}";
            string day = $"{Utility.GetIntRandom(1, 28):00}";
            string startDateStr = $"{year}-{month}-{day}";
            DateTime tdStartDate = DateTime.ParseExact(startDateStr, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            double tdInterestRate = Math.Round(Utility.GetDoubleRandom(0.0150, 0.0285, false), 4);            
            TermDeposit td = new TermDeposit(tdPrinciple, tdStartDate, tdInterestRate, tdTerm);
            return td;
        }
    }
}
