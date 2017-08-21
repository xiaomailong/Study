﻿using System.ComponentModel.Composition;
using Motor.HMI.CRH380D.Resources.Keys;
using Motor.HMI.CRH380D.ViewModel;

namespace Motor.HMI.CRH380D.Controller.BtnActionResponser.HighVoltageView
{
    [Export]
    public class CutInOrCutOff : BtnActionResponserBase
    {
        public override void ResponseClick()
        {
            ViewModel.Value.Model.HighVoltyageModel.HighVoltyageController.CutInAndCutOffSendData();
        }
    }

    [Export]
    public class GFXCut : BtnActionResponserBase
    {
        public override void ResponseClick()
        {
            ViewModel.Value.Model.HighVoltyageModel.HighVoltyageController.GFXCutOffSendData();
        }
    }

    [Export]
    public class SystemMenuResponser : BtnActionResponserBase
    {
        public override void ResponseClick()
        {
            NavigateTo(StateKeys.Root_系统概况界面按键);
            DomainViewModel.Instacnce.Model.HighVoltyageModel.HighVoltyageController.ClearState();
        }
    }

    [Export]
    public class MainMenuResponser : BtnActionResponserBase
    {
        public override void ResponseClick()
        {
            NavigateTo(StateKeys.Root_主菜单界面按键);
            DomainViewModel.Instacnce.Model.HighVoltyageModel.HighVoltyageController.ClearState();
        }
    }

    [Export]
    public class RunAndStationResponser : BtnActionResponserBase
    {
        public override void ResponseClick()
        {
            NavigateTo(StateKeys.Root_运行车站界面按键);
            DomainViewModel.Instacnce.Model.DoorModel.DoorController.SetButtonEnable();
            DomainViewModel.Instacnce.Model.HighVoltyageModel.HighVoltyageController.ClearState();
        }
    }
}
