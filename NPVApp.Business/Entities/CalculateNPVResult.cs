using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPVApp.Business
{
    [Dapper.Table("CalculateNPVResults")]
    public class CalculateNPVResult : EntityBase
    {
        public int RequestId { get; set; }

        public double DiscountRate { get; set; }

        public decimal NetPresentValue { get; set; }

        #region ---- Result Column properties

        [JsonIgnore]
        [Dapper.ReadOnly(true)]
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
SELECT CalculateNPVResults.*,
(SELECT DISTINCT CF.Id, CF.RequestId, CF.CashFlowValue, CF.CashFlowOrder
			FROM dbo.CashFlows CF
			INNER JOIN dbo.CalculateNPVRequests RQ ON RQ.Id = CF.RequestId
			WHERE RQ.Id=CalculateNPVResults.RequestId
            ORDER BY CF.CashFlowOrder
			FOR JSON PATH
) AS CashFlowsJSON
FROM dbo.CalculateNPVResults
INNER JOIN dbo.CalculateNPVRequests ON CalculateNPVRequests.Id = CalculateNPVResults.RequestId";
            }
        }
        #endregion
    }
}
