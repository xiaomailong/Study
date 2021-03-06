﻿using System.ComponentModel.Composition;
using System.Windows.Controls;
using Engine.HMI.SS3B.View.Constance;
using Engine.HMI.SS3B.View.ViewModel.KunMing;
using MMI.Facility.WPFInfrastructure.Behaviors;

namespace Engine.HMI.SS3B.View.View.KunMing
{
    /// <summary>
    /// AssistSysytemPage.xaml 的交互逻辑
    /// </summary>
    [ViewExport(RegionName = KunMingRegionNames.ViewContent)]
    public partial class AssistSysytemPage : UserControl
    {
        [ImportingConstructor]
        public AssistSysytemPage(SS3BViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
