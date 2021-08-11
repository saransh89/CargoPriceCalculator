using CargoCalculator.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargoCalculator.Controllers
{
    public class ReportController : Controller
    {
        DataAccessMediator dataAccessMediator = new DataAccessMediator();
        // GET: Report
        public ActionResult Index()
        {
            var data = dataAccessMediator.GetReportResult();
            return View(data);
        }
    }
}