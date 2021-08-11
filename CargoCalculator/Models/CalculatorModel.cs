using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CargoCalculator.Models
{
    public class CalculatorModel
    {
        [Key]
        public Int64 Id { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string depth { get; set; }
        public string weight { get; set; }
        public string UserId { get; set; }

    }
}