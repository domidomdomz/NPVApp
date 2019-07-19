using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPVApp.Business
{
    [Dapper.Table("CashFlows")]
    public class CashFlow : EntityBase
    {
        [JsonIgnore]
        public override int Id { get => base.Id; set => base.Id = value; }

        public int RequestId { get; set; }

        public double CashFlowValue { get; set; }

        public int CashFlowOrder { get; set; }

        [JsonIgnore]
        [Dapper.ReadOnly(true)]
        public override DateTime CreateDate { get => base.CreateDate; set => base.CreateDate = value; }
    }
}
