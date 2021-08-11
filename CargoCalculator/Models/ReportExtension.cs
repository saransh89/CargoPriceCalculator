using CargoCalculator.DBContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CargoCalculator.Models
{
    public class ReportExtension: Report
    {
        [DisplayName("Volume Price Partner")]
        public string PartnerNameForAreaPrice { get; set; }

        [DisplayName("Weight Price Partner")]
        public string PartnerNameForWeightPrice { get; set; }
    }
}