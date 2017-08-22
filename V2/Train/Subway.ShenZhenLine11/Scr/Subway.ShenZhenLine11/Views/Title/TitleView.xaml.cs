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

namespace Subway.ShenZhenLine11.Views.Title
{
    /// <summary>
    /// TitleView.xaml 的交互逻辑
    /// </summary>
    [ViewExport(RegionName = RegionNames.Title)]
    public partial class TitleView : UserControl
    {
        public TitleView()
        {
            InitializeComponent();
        }
    }
}