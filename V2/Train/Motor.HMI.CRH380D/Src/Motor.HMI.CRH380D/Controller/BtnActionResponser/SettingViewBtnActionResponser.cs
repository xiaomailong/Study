﻿using System.ComponentModel.Composition;
using Motor.HMI.CRH380D.Resources.Keys;
using Motor.HMI.CRH380D.ViewModel;

namespace Motor.HMI.CRH380D.Controller.BtnActionResponser.SettingView
{
    [Export]
    public class MainMenuResponser : BtnActionResponserBase
    {
        public override void ResponseClick()
        {
            NavigateTo(StateKeys.Root_主菜单界面按键);
            DomainViewModel.Instacnce.Model.TractionModel.TractionController.ClearState();
        }
    }

    [Export]
    public class RunAndStationResponser : BtnActionResponserBase
    {
        public override void ResponseClick()
        {
            NavigateTo(StateKeys.Root_运行车站界面按键);
            DomainViewModel.Instacnce.Model.DoorModel.DoorController.SetButtonEnable();
            DomainViewModel.Instacnce.Model.TractionModel.TractionController.ClearState();
        }
    }
}
