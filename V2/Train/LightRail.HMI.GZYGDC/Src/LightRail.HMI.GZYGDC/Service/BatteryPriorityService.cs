﻿using System.Collections.Generic;
using LightRail.HMI.GZYGDC.Config;
using LightRail.HMI.GZYGDC.Model.Units;

namespace LightRail.HMI.GZYGDC.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class BatteryPriorityService : PriorityServiceBase<BatteryState>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        public BatteryPriorityService(IList<Priority<BatteryState, int>> list)
        {
            Priority = list;
        }
    }
}