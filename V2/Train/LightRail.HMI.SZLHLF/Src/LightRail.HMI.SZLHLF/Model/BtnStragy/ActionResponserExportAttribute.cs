﻿using System;
using System.ComponentModel.Composition;

namespace LightRail.HMI.SZLHLF.Model.BtnStragy
{
    public class ActionResponserExportAttribute : ExportAttribute
    {
        public ActionResponserExportAttribute(Type name)
            : base(name.FullName, typeof(IBtnActionResponser))
        {
        }
    }
}