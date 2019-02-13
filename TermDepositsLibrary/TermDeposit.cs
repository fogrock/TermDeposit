﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermDepositsLibrary
{
    public class TermDeposit
    {
        private DateTime _endDate;
        public double _maturityAmount;        
        
        public double principal { get; set; }
        public DateTime startDate { get; set; }
        public double interestRate { get; set; }
        public int term { get; set; }
        public double maturityAmount { get { return _maturityAmount; } set { _maturityAmount = getMaturityAmount(principal, interestRate, term); } }
        public DateTime endDate { get { return _endDate; } set { _endDate = getEndDate(startDate, term); } }
        public string startDateString
        {
            get { return startDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture); }            
        }
        public string endDateString
        {
            get { return endDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture); ; }            
        }
        public string interestRateString
        {
            get { return (interestRate * 100).ToString() + '%'; }            
        }        

        public DateTime getEndDate(DateTime startDate, int term)
        {
            DateTime endDate = startDate.AddYears(term);
            return endDate;
        }
        public double getMaturityAmount(double principal, double interestRate, int term)
        {
            double maturityAmount = principal * Math.Pow((1 + interestRate / 365), (365 * term));
            return Math.Round(maturityAmount, 2);
        }

        public TermDeposit(double principal, DateTime startDate, double interestRate, int term)
        {
            this.principal = principal;
            this.startDate = startDate;
            this.interestRate = interestRate;
            this.term = term;
            _maturityAmount = getMaturityAmount(principal, interestRate, term);
            _endDate = getEndDate(startDate, term);
        }
    }
}
