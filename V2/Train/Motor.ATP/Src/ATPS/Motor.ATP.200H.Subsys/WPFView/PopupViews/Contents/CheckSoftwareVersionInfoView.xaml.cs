﻿using System.ComponentModel.Composition;
using MMI.Facility.WPFInfrastructure.Behaviors;
using Motor.ATP._200H.Subsys.Constant;
using Motor.ATP._200H.Subsys.ViewModel.PopupViewModels;

namespace Motor.ATP._200H.Subsys.WPFView.PopupViews.Contents
{
    /// <summary>
    /// CheckSoftwareVersionInfoView.xaml 的交互逻辑
    /// </summary>
    [ViewExport(RegionName = RegionNames.RegionPopupViewContent)]
    public partial class CheckSoftwareVersionInfoView 
    {
        [ImportingConstructor]
        public CheckSoftwareVersionInfoView(CheckSoftwareInfoViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
