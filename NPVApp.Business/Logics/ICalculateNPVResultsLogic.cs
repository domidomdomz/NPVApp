﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPVApp.Business
{
    public interface ICalculateNPVResultsLogic : ILogic<CalculateNPVResult>
    {
        Task<IList<CalculateNPVResult>> GetByRequestId(int requestId);
    }
}
