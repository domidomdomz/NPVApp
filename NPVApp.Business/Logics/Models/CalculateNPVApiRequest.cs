using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NPVApp.Business
{
    public class CalculateNPVApiRequest
    {
        [Required(ErrorMessage = Util.FieldRequired)]
        [Range(0.01, long.MaxValue, ErrorMessage = Util.AtLeast001)]
        [Display(Name = "Initial Investment")]
        public decimal? InitialInvestment { get; set; }

        [Required(ErrorMessage = Util.FieldRequired)]
        [Range(0.01, long.MaxValue, ErrorMessage = Util.AtLeast001)]
        [Display(Name = "Lower Bound Discount Rate")]
        public double? LowerBoundDiscountRate { get; set; }

        [GreaterThan("LowerBoundDiscountRate")]
        [Range(0.01, long.MaxValue, ErrorMessage = Util.AtLeast001)]
        [Required(ErrorMessage = Util.FieldRequired)]
        [Display(Name = "Upper Bound Discount Rate")]
        public double? UpperBoundDiscountRate { get; set; }

        [Range(0.01, long.MaxValue, ErrorMessage = Util.AtLeast001)]
        [Required(ErrorMessage = Util.FieldRequired)]
        [Display(Name = "Discount Rate Increment")]
        public double? DiscountRateIncrement { get; set; }

        public IList<double> CashFlows { get; set; }
    }
}
