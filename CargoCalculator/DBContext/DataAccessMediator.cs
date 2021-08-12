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
                         new SqlParameter("@UserId", calculatorModel.UserId == null ? (object)DBNull.Value : calculatorModel.UserId)).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                calculationResult.FinalPrice = 0;
                calculationResult.Status = 0;
                calculationResult.Msg = "All fields are required with valid decimal value. Ex: 10.33";

            }
            return calculationResult;
        }

        public List<Report> GetReportResult(DateTime? fromDate = null, DateTime? toDate = null, string UserId = "")
        {
            List<Report> reportResult = new List<Report>();
            try
            {
                using (SMS_DotnetCoreEntities db = new SMS_DotnetCoreEntities())
                {
                    reportResult = db.Database.SqlQuery<Report>("SpGetCalculationReport @fromDate, @toDate, @UserId",
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