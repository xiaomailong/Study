﻿using System.ComponentModel.Composition;
using System.Linq;
using System.Windows;
using Engine._6A.Constance;
using Engine._6A.Interface;
using Engine._6A.Interface.ViewModel;
using Engine._6A.Interface.ViewModel.DataMonitor;
using Engine._6A.Interface.ViewModel.SystemSeting;
using Engine._6A.ViewModel.Common;

namespace Engine._6A.ViewModel.Axle6
{
    [Export(ContractName.Axle6, typeof(IEngine6AViewModel))]
    public class Axle6ViewModel : ViewModelBase, IEngine6AViewModel
    {
        private Visibility m_MMIBlack;

        public Visibility MMIBlack
        {
            get { return m_MMIBlack; }
            set
            {
                if (value == m_MMIBlack)
                {
                    return;
                }
                m_MMIBlack = value;
                RaisePropertyChanged(() => MMIBlack);
            }
        }

        public override void Clear()
        {
            base.Clear();
            var type = typeof(Axle6ViewModel);
            foreach (var tmp in type.GetProperties().Select(info => info.GetValue(this, null)).OfType<IClearData>())
            {
                tmp.Clear();
            }
        }

        [Import]
        public IMainViewModel MainView { get; private set; }
        [Import]
        public IDialViewModel Dial { get; private set; }
        [Import]
        public IStartingViewModel Starting { get; private set; }
        [Import]
        public ITitleViewModel Title { get; private set; }
        [Import(ContractName.Axle6)]
        public IDataMonitorViewModel DataMonitor { get; private set; }
        [Import]
        public IVideoViewModel Video { get; private set; }
        [Import]
        public IFaultViewModel Fault { get; private set; }
        [Import]
        public ISystemSettingViewModel SystemSetting { get; private set; }
        [Import(ContractName.Axle6)]
        public IButtonViewModel Button { get; private set; }
    }
}