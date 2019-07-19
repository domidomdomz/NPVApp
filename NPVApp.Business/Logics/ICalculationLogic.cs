using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPVApp.Business
{
    public interface ICalculationLogic
    {
        Task<int> ManageNPVCalculation(CalculateNPVApiRequest request);
    }
}
