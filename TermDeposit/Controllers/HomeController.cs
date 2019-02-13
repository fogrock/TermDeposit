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
            if (SessionManager.TermDepositPortfolio.GetPortfolioMV() < 120 * mn)
            {
                SessionManager.TermDepositPortfolio.ModifyHoldings("buy");

                if (SessionManager.TermDepositPortfolio.GetPortfolioMV() < 120 * mn)
                {
                    SessionManager.Action = "buy";
                }
                else
                {
                    SessionManager.Action = "hold";
                }
            }

            return RedirectToAction("Index", "Home");
            //return View(tdp);RedirectToAction
        }

        [HttpPost]
        public ActionResult Sell()
        {
            if (SessionManager.TermDepositPortfolio.GetPortfolioMV() > 50 * mn)
            {
                SessionManager.TermDepositPortfolio.ModifyHoldings("sell");

                if (SessionManager.TermDepositPortfolio.GetPortfolioMV() > 50 * mn)
                {
                    SessionManager.Action = "sell";
                }
                else
                {
                    SessionManager.Action = "hold";
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
