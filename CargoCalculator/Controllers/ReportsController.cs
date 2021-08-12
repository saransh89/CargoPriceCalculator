using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CargoCalculator.DBContext;

namespace CargoCalculator.Controllers
{
    [Authorize(Roles = "admin")]
    public class ReportsController : Controller
    {
        private SMS_DotnetCoreEntities db = new SMS_DotnetCoreEntities();

        // GET: Reports
        public ActionResult Index()
        {
            return View(db.Reports.OrderByDescending(a => a.id).ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
