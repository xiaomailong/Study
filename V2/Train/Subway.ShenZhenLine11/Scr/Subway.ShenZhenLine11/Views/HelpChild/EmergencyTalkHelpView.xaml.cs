﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MMI.Facility.WPFInfrastructure.Behaviors;
using Subway.ShenZhenLine11.Constance;

namespace Subway.ShenZhenLine11.Views.HelpChild
{
    /// <summary>
    /// EmergencyTalkHelpView.xaml 的交互逻辑
    /// </summary>
    [ViewExport(RegionName = RegionNames.HelpRegion)]
    public partial class EmergencyTalkHelpView : UserControl
    {
        public EmergencyTalkHelpView()
        {
            InitializeComponent();
        }
    }
}
