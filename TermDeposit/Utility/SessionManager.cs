using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TermDepositsLibrary;

namespace TermDeposit.Utility
{
    public class SessionManager
    {
        // create session variable to hold portfolio object
        public static TDPortfolio TermDepositPortfolio
        {
            get
            {
                TDPortfolio obj = (TDPortfolio)HttpContext.Current.Session["CurrentTermDepositPortfolio"];
                return obj;
            }
            set { HttpContext.Current.Session["CurrentTermDepositPortfolio"] = value; }
        }

        // create session variable to hold currecnt action i.e. "buy"/"sell"/"hold"
        public static string Action
        {
            get
            {
                return (string)HttpContext.Current.Session["CurrentAction"];
            }
            set { HttpContext.Current.Session["CurrentAction"] = value; }
        }
    }
}