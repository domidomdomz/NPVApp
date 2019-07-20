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
        public decimal? InitialInvestment { get; set; }

        [Required(ErrorMessage = Util.FieldRequired)]
        public double? LowerBoundDiscountRate { get; set; }

        [Required(ErrorMessage = Util.FieldRequired)]
        public double? UpperBoundDiscountRate { get; set; }

        [Required(ErrorMessage = Util.FieldRequired)]
        public double? DiscountRateIncrement { get; set; }

        public IList<double> CashFlows { get; set; }
    }
}
