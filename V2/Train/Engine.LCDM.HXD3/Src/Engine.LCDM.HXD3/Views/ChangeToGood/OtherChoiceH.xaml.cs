﻿using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Engine.LCDM.HXD3.Constance;
using Engine.LCDM.HXD3.Interfaces;
using MMI.Facility.WPFInfrastructure.Behaviors;
using Engine.LCDM.HXD3.LCMDAtt;

namespace Engine.LCDM.HXD3.Views.ChangeToGood
{
    /// <summary>
    /// OtherChoiceH.xaml 的交互逻辑
    /// </summary>
    [ViewExport(RegionName = RegionNames.BottomButton)]
    public partial class OtherChoiceH : IButtons
    {
        public OtherChoiceH()
        {
            InitializeComponent();
            F1 = ButtonF1;
            F2 = ButtonF2;
            F3 = ButtonF3;
            F4 = ButtonF4;
            F5 = ButtonF5;
            F7 = ButtonF7;
            F8 = ButtonF8;
        }
        public Button F1 { get; set; }
        public Button F2 { get; set; }
        public Button F3 { get; set; }
        public Button F4 { get; set; }
        public Button F5 { get; set; }
        public Button F6 { get; set; }
        public Button F7 { get; set; }
        public Button F8 { get; set; }
    }
}
