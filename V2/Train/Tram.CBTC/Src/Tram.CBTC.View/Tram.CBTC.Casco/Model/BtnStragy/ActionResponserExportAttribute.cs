﻿using System;
using System.ComponentModel.Composition;

namespace Tram.CBTC.Casco.Model.BtnStragy
{
    public class ActionResponserExportAttribute : ExportAttribute
    {
        public ActionResponserExportAttribute(Type name)
            : base(name.FullName, typeof(IBtnActionResponser))
        {
        }
    }
}