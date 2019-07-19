using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPVApp.Business
{
    public class CalculateNPVResultsLogic : LogicBase<CalculateNPVResult>, ICalculateNPVResultsLogic
    {
        public CalculateNPVResultsLogic(IDB db) : base(db) { }

        public async Task<IList<CalculateNPVResult>> GetByRequestId(int requestId)
        {
            var where = @"CalculateNPVResults.RequestId=@RequestId";
            var sqlParams = new { requestId };
            var entities = await GetAllAsync(where, sqlParams);

            return entities.ToList();
        }
    }
}
