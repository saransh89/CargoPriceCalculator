using CargoCalculator.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CargoCalculator.DBContext
{
    /// <summary>
    /// 
    /// </summary>
    public class DataAccessMediator
    {
        public CalculationResult GetCalculationResult(CalculatorModel calculatorModel)
        {
            CalculationResult calculationResult = new CalculationResult();
            try
            {
               
                using (SMS_DotnetCoreEntities db = new SMS_DotnetCoreEntities())
                {
                    calculationResult = db.Database.SqlQuery<CalculationResult>("SpGetCalculationResult @width, @height, @depth, @weight, @UserId",
                         new SqlParameter("@width", calculatorModel.width),
                         new SqlParameter("@height", calculatorModel.height),
                         new SqlParameter("@depth", calculatorModel.depth),
                         new SqlParameter("@weight", calculatorModel.weight),
                         new SqlParameter("@UserId", calculatorModel.UserId)).FirstOrDefault();
                }
            }
            catch (Exception e)
            {

            }
            return calculationResult;
        }

        public List<ReportExtension> GetReportResult(DateTime? fromDate = null, DateTime? toDate = null, string UserId = "")
        {
            List<ReportExtension> reportResult = new List<ReportExtension>();
            try
            {
                using (SMS_DotnetCoreEntities db = new SMS_DotnetCoreEntities())
                {
                    reportResult = db.Database.SqlQuery<ReportExtension>("SpGetCalculationReport @fromDate, @toDate, @UserId",
                         new SqlParameter("@fromDate", Convert.ToString(fromDate)),
                         new SqlParameter("@toDate", Convert.ToString(toDate)),
                         new SqlParameter("@UserId", UserId)).ToList();
                }
            }
            catch (Exception e)
            {

            }
            return reportResult;
        }
    }

    public class CalculationResult
    {
        public Decimal FinalPrice { get; set; }
        public string Msg { get; set; }
        public int Status { get; set; }
    }
}