using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPVApp.Business
{
    public class CalculationLogic : ICalculationLogic
    {
        protected IDB DB;

        public CalculationLogic(IDB db)
        {
            DB = db;
        }

        public async Task<int> ManageNPVCalculation(CalculateNPVApiRequest request)
        {

            var calculateNPVRequest = new CalculateNPVRequest
            {
                InitialInvestment = request.InitialInvestment,
                LowerBoundDiscountRate = request.LowerBoundDiscountRate,
                UpperBoundDiscountRate = request.UpperBoundDiscountRate,
                DiscountRateIncrement = request.DiscountRateIncrement
            };
            var requestId = await DB.InsertAsync(calculateNPVRequest);


            var cashFlows = new List<CashFlow>();
            var cashFlowOrder = 1;
            foreach (var cashFlow in request.CashFlows)
            {
                cashFlows.Add(new CashFlow
                {
                    CashFlowValue = cashFlow,
                    CashFlowOrder = cashFlowOrder,
                    RequestId = requestId
                });
                cashFlowOrder = cashFlowOrder + 1;
            }
            await DB.InsertListAsync<CashFlow>(cashFlows);


            var currentDiscountRate = request.LowerBoundDiscountRate;
            while ((decimal)request.UpperBoundDiscountRate >= (decimal)currentDiscountRate)
            {
                var computedNPV = ComputeNPV(request.InitialInvestment, currentDiscountRate, cashFlows);
                var calculateNPVResult = new CalculateNPVResult
                {
                    RequestId = requestId,
                    DiscountRate = currentDiscountRate,
                    NetPresentValue = computedNPV
                };
                await DB.InsertAsync(calculateNPVResult);

                if ((decimal)request.UpperBoundDiscountRate == (decimal)currentDiscountRate)
                    break;

                currentDiscountRate = currentDiscountRate + request.DiscountRateIncrement;
            }

            return requestId;
        }

        private decimal ComputeNPV(decimal initialInvestment, double discountRate, List<CashFlow> cashFlows)
        {
            var npv = cashFlows.Select(x => x.CashFlowValue / Math.Pow((1 + discountRate), x.CashFlowOrder)).Sum();

            return (decimal)npv - initialInvestment;
        }

    }
}
