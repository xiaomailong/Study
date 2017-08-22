﻿using System.Collections.Generic;
using System.Xml.Serialization;
using CommonUtil.Util;
using CRH2MMI.Common.Models;
using CRH2MMI.Common.View.Train;

namespace CRH2MMI.BrakeInfo
{
    [XmlRoot]
    public class BrakeInfoConfig
    {
        [XmlElement]
        public TrainViewLocation TrainViewLocation { set; get; }

        [XmlArray("PageConfigs")]
        [XmlArrayItem("Page")]
        public List<BrakePageConfig> BrakePageConfigs { set; get; }

        /// <summary>
        /// 修改 \r\n为换行
        /// </summary>
        public void Correction()
        {
            BrakePageConfigs.ForEach(e =>
            {
                e.Grid.Rows.ForEach(row => row.Name = row.Name.Replace(Line, "\r\n"));
                e.PageName = e.PageName.Replace(Line, "\r\n");
            });
        }

        private const string Line = "\\r\\n";
    }

    public class BrakePageConfig
    {
        [XmlAttribute]
        public string PageName { set; get; }

        public GridConfig Grid { set; get; }
    }

    class BrakeInfoConfigTest
    {
        public static void Test()
        {
            var data = new BrakeInfoConfig()
            {
                BrakePageConfigs = new List<BrakePageConfig>()
                {
                    new BrakePageConfig() {PageName = "制动", Grid = new GridConfig() {}}
                }
            };

            DataSerialization.SerializeToXmlFile(data, "D:\\a.xml");
        }
    }
}