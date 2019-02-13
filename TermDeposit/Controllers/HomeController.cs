using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TermDepositsLibrary;
using TermDeposit.Utility;

namespace TermDepositsLibraryTermDeposit.Controllers
{

    public class HomeController : Controller
    {
        const int mn = 1000000;
        [HttpGet]
        public ActionResult Index()
        {
            if (SessionManager.TermDepositPortfolio == null)
            {
                SessionManager.TermDepositPortfolio = new TDPortfolio();
            }

            if (SessionManager.Action == "buy")
            {
                ViewBag.isBuy = "true";
            }

            if (SessionManager.Action == "sell")
            {
                ViewBag.isSell = "true";
            }

            return View(SessionManager.TermDepositPortfolio);
        }

        [HttpPost]
        public ActionResult Buy()
        {
            // check if buying is still required and add holding
            if (SessionManager.TermDepositPortfolio.GetPortfolioMV() < 120 * mn)
            {
                SessionManager.TermDepositPortfolio.ModifyHoldings("buy");

                // if after this addition, further addition of holding still required, set action flag to 'buy'
                if (SessionManager.TermDepositPortfolio.GetPortfolioMV() < 120 * mn)
                {
                    SessionManager.Action = "buy";
                }
                // if after this addition, further addition of holding is not required, set action flag to 'hold'
                else
                {
                    SessionManager.Action = "hold";
                }
            }
            else
            {
                SessionManager.Action = "hold";
            }

            return RedirectToAction("Index", "Home");
            //return View(tdp);RedirectToAction
        }

        [HttpPost]
        public ActionResult Sell()
        {
            // check if selling is still required and reduce holding
            if (SessionManager.TermDepositPortfolio.GetPortfolioMV() > 50 * mn)
            {
                SessionManager.TermDepositPortfolio.ModifyHoldings("sell");

                // if after this reduction, further reduction of holding still required, set action flag to 'sell'
                if (SessionManager.TermDepositPortfolio.GetPortfolioMV() > 50 * mn)
                {
                    SessionManager.Action = "sell";
                }
                // if after this reduction, further reduction of holding is not required, set action flag to 'hold'
                else
                {
                    SessionManager.Action = "hold";
                }
            }
            else
            {
                SessionManager.Action = "hold";
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
