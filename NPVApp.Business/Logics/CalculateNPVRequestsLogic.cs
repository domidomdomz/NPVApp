﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPVApp.Business
{
    public class CalculateNPVRequestsLogic : LogicBase<CalculateNPVRequest>, ICalculateNPVRequestsLogic
    {
        public CalculateNPVRequestsLogic(IDB db) : base(db) { }
    }
}
