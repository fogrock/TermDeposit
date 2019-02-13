using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TermDepositsLibrary
{
    public class TDPortfolio
    {
        const int mn = 1000000;
        private List<TermDeposit> _holdngsList = new List<TermDeposit>();

        public List<TermDeposit> holdngsList
        {
            get { return _holdngsList; }
            set { _holdngsList = ModifyHoldings(); }
        }

        public TDPortfolio()
        {
            _holdngsList = GetTDPortfolio();
        }

        public TDPortfolio(int numberHoldings = 50, int minInitMaturValueMn = 70, int maxInitMaturValueMn = 100, int minMaturValMn = 50, int maxMaturValMn = 120)
        {
            _holdngsList = GetTDPortfolio(numberHoldings, minInitMaturValueMn, maxInitMaturValueMn, minMaturValMn, maxMaturValMn);
        }

        public List<TermDeposit> GetTDPortfolio(int numberHoldings = 50, int minInitMaturValueMn = 70, int maxInitMaturValueMn = 100, int minMaturValMn = 50, int maxMaturValMn = 120)
        {
            List<TermDeposit> termDepositPortfolio = new List<TermDeposit>();

            double totalPortfolioValue = Utility.GetDoubleRandom(minInitMaturValueMn * mn, maxInitMaturValueMn * mn);
            double totalLargeDepositsValue = totalPortfolioValue - minMaturValMn * mn;

            double ldpv = 0;
            while (ldpv < totalLargeDepositsValue)
            {
                TermDeposit td = GetTermDeposit(3 * mn, 5 * mn);
                termDepositPortfolio.Add(td);
                ldpv += td.maturityAmount;
                Thread.Sleep(50);
            }

            double minRemaningDepositsValue = minInitMaturValueMn * mn - GetPortfolioMV(termDepositPortfolio);
            double maxRemaningDepositsValue = maxInitMaturValueMn * mn - GetPortfolioMV(termDepositPortfolio);
            int remainingNumberHoldings = numberHoldings - termDepositPortfolio.Count;

            double lowerBorderDeposit = minRemaningDepositsValue / remainingNumberHoldings;
            double higherBorderDeposit = maxRemaningDepositsValue / remainingNumberHoldings;

            for (int i = 0; i < remainingNumberHoldings; i++)
            {
                TermDeposit td = GetTermDeposit(lowerBorderDeposit, higherBorderDeposit, true);
                termDepositPortfolio.Add(td);
                ldpv += td.maturityAmount;
                Thread.Sleep(50);
            }
            return termDepositPortfolio;
        }

        public List<TermDeposit> ModifyHoldings(string action = "hold")
        {
            switch (action.ToLower())
            {
                case "buy":
                    TermDeposit td = GetTermDeposit(3 * mn, 5 * mn);
                    _holdngsList.Add(td);
                    break;
                case "sell":
                    TermDeposit item = holdngsList.FirstOrDefault(o => (o.principal >= 3 * mn && o.principal <= 5 * mn));
                    if (item != null)
                    {
                        _holdngsList.Remove(item);
                    }
                    break;
            }
            return holdngsList;
        }

        public void RemoveHolding(double number)
        {
            TermDeposit item = holdngsList.FirstOrDefault(o => (o.principal == number));
            if (item != null)
            {
                _holdngsList.Remove(item);
            }

        }

        public TermDeposit GetTermDeposit(double principalMin, double principalMax, bool useAsMV = false)
        {

            int tdTerm = Utility.GetIntRandom(1, 10);
            int year = DateTime.Now.Year - Utility.GetIntRandom(1, tdTerm - 1);
            string month = $"{Utility.GetIntRandom(1, 12):00}";
            string day = $"{Utility.GetIntRandom(1, 28):00}";
            string startDateStr = $"{year}-{month}-{day}";
            DateTime tdStartDate = DateTime.ParseExact(startDateStr, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            double tdInterestRate = Math.Round(Utility.GetDoubleRandom(0.0150, 0.0285, false), 4);
            double tdPrinciple = 0;
            if (useAsMV == true)
            {
                double mv = Utility.GetDoubleRandom(principalMin, principalMax);
                tdPrinciple = Math.Round((mv / Math.Pow((1 + tdInterestRate / 365), (365 * tdTerm))), 2);
            }
            else
            {
                tdPrinciple = Utility.GetDoubleRandom(principalMin, principalMax);
            }

            TermDeposit td = new TermDeposit(tdPrinciple, tdStartDate, tdInterestRate, tdTerm);
            return td;
        }

        public double GetPortfolioMV(List<TermDeposit> termDepositPortfolio)
        {
            double portfolioMaturTotal = termDepositPortfolio.Sum(item => item.maturityAmount);
            return portfolioMaturTotal;
        }

        public double GetPortfolioMV()
        {
            return holdngsList.Sum(item => item.maturityAmount);
        }
    }
}
