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
        [Display(Name = "Width(cm)")]
        public string width { get; set; }
        [Display(Name = "Height(cm)")]
        public string height { get; set; }
        [Display(Name = "Depth(cm)")]
        public string depth { get; set; }
        [Display(Name = "Weight(Kg)")]
        public string weight { get; set; }
        [Display(Name = "UserId")]
        public string UserId { get; set; }

    }
}