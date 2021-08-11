using CargoCalculator.DBContext;
using CargoCalculator.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static CargoCalculator.DBContext.DataAccessMediator;

namespace CargoCalculator.Controllers
{
    //[Authorize]
    public class CalculatorController : Controller
    {
        DataAccessMediator dataAccessMediator = new DataAccessMediator();
        // GET: Calculator
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCalculatedResult(CalculatorModel calculatorModel)
        {
            var userID = User.Identity.GetUserId();
            calculatorModel.UserId = userID;
            CalculationResult obj = dataAccessMediator.GetCalculationResult(calculatorModel);
            return Json(obj);
        }
    }
}