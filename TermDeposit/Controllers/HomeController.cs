using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TermDepositsLibrary;

namespace TermDepositsLibraryTermDeposit.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var tdp = new TDPortfolio();
            return View(tdp);
        }
        
    }
}