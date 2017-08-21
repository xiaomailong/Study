﻿using System.Windows;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;
using Subway.WuHanLine6.GIS.Event;
using Subway.WuHanLine6.GIS.Interfaces;

namespace Subway.WuHanLine6.GIS.Views.Shells
{
    /// <summary>
    /// LeftShell.xaml 的交互逻辑
    /// </summary>
    public partial class LeftShell : IShell
    {
        public LeftShell()
        {
            InitializeComponent();
            Map = new LeftMapView();
            Station = new LeftStationView();
            ChangeToMap();
            ServiceLocator.Current.GetInstance<IEventAggregator>().GetEvent<ChangedViewEvents>().Subscribe((args =>
           {
               if (args.IsMap)
               {
                   ChangeToMap();
               }
               else
               {
                   ChangeToStaion();
               }
           }), ThreadOption.UIThread);
        }
        public UIElement Map { get; }
        public UIElement Station { get; }

        public void ChangeToMap()
        {
            Grid.Children.Clear();
            Grid.Children.Add(Map);
        }

        public void ChangeToStaion()
        {
            Grid.Children.Clear();
            Grid.Children.Add(Station);
        }
    }
}
