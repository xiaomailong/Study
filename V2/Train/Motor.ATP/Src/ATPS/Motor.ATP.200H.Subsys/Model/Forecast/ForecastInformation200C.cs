﻿using System.Collections.Generic;
using System.Linq;
using Motor.ATP.Infrasturcture.Interface;
using Motor.ATP.Infrasturcture.Model;

namespace Motor.ATP._200H.Subsys.Model.Forecast
{
    public class ForecastInformation200H : ForecastInformation
    {
        public ForecastInformation200H(ATPDomain parent) : base(parent)
        {
        }

        /// <summary>
        /// 命令区的
        /// </summary>
        public override IEnumerable<IForecastInformationItem> CmdForecastInformationItems
        {
            get
            {
                return
                    ForecastInformationItems.Skip(MaxRefreshDelayCount)
                        .Where(w => w.Type != ForecastInformationType.Isolated)
                        .Take(MaxCmdItemCount);
            }
        }
    }
}