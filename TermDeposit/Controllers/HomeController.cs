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
        [HttpGet]
        public ActionResult Index()
        {
            if (SessionManager.TermDepositPortfolio == null)
            {
                SessionManager.TermDepositPortfolio = new TDPortfolio();
            }
            return View(SessionManager.TermDepositPortfolio);
        }

        [HttpPost]
        public ActionResult Buy()
        {
            SessionManager.TermDepositPortfolio.ModifyHoldings("buy");
            ViewBag.isBuy = "true";
            return RedirectToAction("Index", "Home");
            //return View(tdp);RedirectToAction
        }

        [HttpPost]
        public ActionResult Sell()
        {
            SessionManager.TermDepositPortfolio.ModifyHoldings("sell");
            ViewBag.isSell = "true";
            return RedirectToAction("Index", "Home");
        }
    }
}
