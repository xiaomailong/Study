﻿using System.Diagnostics.CodeAnalysis;
using Excel.Interface;

namespace Motor.TCMS.CRH400BF.Config
{
   

    [ExcelLocation("Motor.TCMS.CRH400BF列车Car空压机状态配置.xls", "Sheet1")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    public class CarAirCompressorConfig : ISetValueProvider
    {
        [ExcelField("Car索引")]
        public int Index { get; private set; }

        [ExcelField("未知")]
        public string Unknow { get; private set; }

        [ExcelField("工作")]
        public string Run { get; private set; }

        [ExcelField("未工作")]
        public string NotRun { get; private set; }

        [ExcelField("故障")]
        public string Fault { get; private set; }

        [ExcelField("切除")]
        public string CutOff { get; private set; }


        /// <summary>
        /// </summary>
        /// <param name="propertyOrFieldName"></param>
        /// <param name="value"></param>
        public void SetValue(string propertyOrFieldName, string value)
        {
        }
    }
}
