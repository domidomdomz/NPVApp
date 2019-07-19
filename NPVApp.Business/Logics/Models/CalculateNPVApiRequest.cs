using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPVApp.Business
{
    public class CalculateNPVApiRequest
    {
        public decimal InitialInvestment { get; set; }

        public double LowerBoundDiscountRate { get; set; }

        public double UpperBoundDiscountRate { get; set; }

        public double DiscountRateIncrement { get; set; }

        public IList<double> CashFlows { get; set; }
    }
}
