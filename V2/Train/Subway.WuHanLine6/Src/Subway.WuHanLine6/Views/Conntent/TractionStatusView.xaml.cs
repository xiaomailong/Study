﻿using System.Windows.Controls;
using MMI.Facility.WPFInfrastructure.Behaviors;
using Subway.WuHanLine6.Attributes;
using Subway.WuHanLine6.Constance;
using Subway.WuHanLine6.Views.MainContent;

namespace Subway.WuHanLine6.Views.Conntent
{
    /// <summary>
    /// TractionStatusView.xaml 的交互逻辑
    /// </summary>
    [ViewExport(RegionName = RegionNames.ContentRegion)]
    [ParentView(typeof(MainContentShell))]
    public partial class TractionStatusView : UserControl
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public TractionStatusView()
        {
            InitializeComponent();
        }
    }
}