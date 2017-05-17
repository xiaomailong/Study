﻿using System.Windows.Controls;
using MMI.Facility.WPFInfrastructure.Behaviors;
using Subway.ShiJiaZhuangLine1.Interface.Attibutes;
using Subway.ShiJiaZhuangLine1.Subsystem.Constant;

namespace Subway.ShiJiaZhuangLine1.Subsystem.View.Contents
{
    /// <summary>
    /// MaintenanceView.xaml 的交互逻辑
    /// </summary>
    [ViewExport(RegionName = RegionNames.ShellContentRegion)]
    [TitleName("维护")]
    public partial class MaintenanceView : UserControl
    {
        public MaintenanceView()
        {
            InitializeComponent();
        }
    }
}