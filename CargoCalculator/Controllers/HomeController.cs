using CargoCalculator.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargoCalculator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult GetCalculation(CalculatorModel calculatorModel)
        {
            string userId = User.Identity.GetUserId();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == userId);
                //if (studentob.StudentID == 0)
                //{
                //    db.Students.Add(studentob);
                //    db.SaveChanges();
                //    return Json(new { success = true, message = "Saved Successfully", JsonRequestBehavior.AllowGet });
                //}
                //else
                //{
                //    db.Entry(studentob).State = EntityState.Modified;
                //    db.SaveChanges();
                //    return Json(new { success = true, message = "Updated Successfully", JsonRequestBehavior.AllowGet });
                //}
            }
            return Json(new { success = true, message = "Updated Successfully", JsonRequestBehavior.AllowGet });
        }
    }
}