﻿using MMI.Facility.WPFInfrastructure.Behaviors;
using Subway.XiaMenLine1.Subsystem.Constant;
using Subway.XiaMenLine1.Subsystem.Interface;

namespace Subway.XiaMenLine1.Subsystem.View.Contents.HelpChildren
{
    /// <summary>
    /// HelpAirPressView.xaml 的交互逻辑
    /// </summary>
    [ViewExport(RegionName = RegionNames.HelpTableRegion, Priority = 7)]
    public partial class HelpAirPressView : ITabItemInfoProvider
    {
        public HelpAirPressView()
        {
            InitializeComponent();
        }
        public string HeadName { get { return "空压机";}} 
    }
}