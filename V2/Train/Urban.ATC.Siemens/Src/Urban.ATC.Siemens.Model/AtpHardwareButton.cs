﻿using System.Collections.ObjectModel;
using System.Linq;
using Motor.ATP.Domain.Interface;
using Motor.ATP.Domain.Interface.UserAction;

namespace Motor.ATP.Domain.Model
{
    public class ATPHardwareButton : ATPPartialBase, IATPHardwareButton
    {

        private ReadOnlyCollection<IHardwareButton> m_HardwareButtons;
        private ReadOnlyCollection<HardwareButton> m_HardwareButtonCollection;
        private IHardwareButtonViewModel m_HardwareButtonViewModel;

        public ATPHardwareButton(ATPDomain parent)
            : base(parent)
        {
            HardwareButtonCollection =
                typeof (UserActionType).GetEnumValues()
                    .Cast<UserActionType>()
                    .Select(s => new HardwareButton(s))
                    .ToList()
                    .AsReadOnly();
        }

        public HardwareButton FindHardwareButton(UserActionType userActionType)
        {
            return HardwareButtonCollection.First(f => f.Type == userActionType);
        }

        public ReadOnlyCollection<HardwareButton> HardwareButtonCollection
        {
            get { return m_HardwareButtonCollection; }
            private set
            {
                m_HardwareButtonCollection = value;
                m_HardwareButtons = HardwareButtonCollection.Cast<IHardwareButton>().ToList().AsReadOnly();
            }
        }

        public IHardwareButtonViewModel HardwareButtonViewModel
        {
            set
            {
                if (Equals(value, m_HardwareButtonViewModel))
                {
                    return;
                }
                m_HardwareButtonViewModel = value;
                RaisePropertyChanged(() => HardwareButtonViewModel);
            }
            get { return m_HardwareButtonViewModel; }
        }

        ReadOnlyCollection<IHardwareButton> IATPHardwareButton.HardwareButtonCollection
        {
            get { return m_HardwareButtons; }
        }
    }
}