﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
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

namespace Engine.LCDM.HDX2.Entity.View
{
    /// <summary>
    /// LCDMRootWithButtonView.xaml 的交互逻辑
    /// </summary>
    [Export]
    public partial class LCDMShellWithButtonView : UserControl
    {
        public LCDMShellWithButtonView()
        {
            InitializeComponent();
        }
    }
}
