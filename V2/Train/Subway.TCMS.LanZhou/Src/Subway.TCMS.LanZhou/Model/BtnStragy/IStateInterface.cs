﻿using System.ComponentModel;

namespace Subway.TCMS.LanZhou.Model.BtnStragy
{
    public interface IStateInterface : INotifyPropertyChanged, IRaiseResourceChangedProvider
    {
        string Title { get; }

        string ContentViewName { get; }

        StateInterfaceKey Id { get; }

        BtnType CurrentSelectedBtn { set; get; }

        BtnItem BtnB1 { get; }
        BtnItem BtnB2 { get; }
        BtnItem BtnB3 { get; }
        BtnItem BtnB4 { get; }
        BtnItem BtnB5 { get; }
        BtnItem BtnB6 { get; }
        BtnItem BtnB7 { get; }
        BtnItem BtnB8 { get; }

        void UpdateState();
    }
}