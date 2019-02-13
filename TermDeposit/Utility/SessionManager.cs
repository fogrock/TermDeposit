using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TermDepositsLibrary;

namespace TermDeposit.Utility
{
    public class SessionManager
    {
        public static TDPortfolio TermDepositPortfolio
        {
            get
            {
                TDPortfolio obj = (TDPortfolio)HttpContext.Current.Session["CurrentTermDepositPortfolio"];
                return obj;
            }
            set { HttpContext.Current.Session["CurrentTermDepositPortfolio"] = value; }
        }
    }
}