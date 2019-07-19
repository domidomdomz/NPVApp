using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPVApp.Business
{
    [Dapper.Table("CalculateNPVRequests")]
    public class CalculateNPVRequest : EntityBase
    {
        public decimal InitialInvestment { get; set; }

        public double LowerBoundDiscountRate { get; set; }

        public double UpperBoundDiscountRate { get; set; }

        public double DiscountRateIncrement { get; set; }

        #region ---- Result Column properties

        [JsonIgnore]
        [Dapper.NotMapped]
        public string CashFlowsJSON { get; set; }

        #endregion

        #region ---- View Model properties

        [Dapper.NotMapped]
        public IList<CashFlow> CashFlows =>
            string.IsNullOrEmpty(CashFlowsJSON) ? null :
            JsonConvert.DeserializeObject<List<CashFlow>>(CashFlowsJSON);

        [Dapper.NotMapped]
        public string CashFlowValues =>
            string.Join(", ", CashFlows.DefaultIfEmpty().Select(m => m.CashFlowValue.ToString("N2")).ToArray());

        #endregion

        #region ---- Default Query
        [JsonIgnore]
        [Dapper.NotMapped]
        public override string DefaultQuery
        {
            get
            {
                return @"
SELECT CalculateNPVRequests.*,
(SELECT DISTINCT CF.Id, CF.RequestId, CF.CashFlowValue, CF.CashFlowOrder
			FROM dbo.CashFlows CF
			INNER JOIN dbo.CalculateNPVRequests RQ ON RQ.Id = CF.RequestId
			WHERE RQ.Id=CalculateNPVRequests.Id
            ORDER BY CF.CashFlowOrder
			FOR JSON PATH
) AS CashFlowsJSON
FROM dbo.CalculateNPVRequests";
            }
        }
        #endregion
    }
}
