﻿using System.ComponentModel.Composition;
using Engine.Angola.TCMS.Resource.Keys;

namespace Engine.Angola.TCMS.Controller.BtnActionResponser
{
    [Export]
    public class ChangeToF4Content2ActionResponser : BtnActionResponserBase
    {
        public override void ResponseClick()
        {
            NavigateTo(StateKeys.Root_F4Conten2);
        }
    }
}