﻿using Engine.Angola.TCMS.Model.BtnStragy;
using Engine.Angola.TCMS.ViewModel;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using System;
using System.ComponentModel.Composition;

namespace Engine.Angola.TCMS.Controller.BtnActionResponser
{
    public abstract class BtnActionResponserBase : IBtnActionResponser
    {
        [Import]
        protected IEventAggregator EventAggregator { private set; get; }

        [Import]
        protected Lazy<AngolaTCMSShellViewModel> ViewModel { private set; get; }

        [Import]
        protected IRegionManager RegionManager { private set; get; }

        public BtnItem Parent { get; set; }

        public virtual void UpdateState()
        {

        }

        /// <summary>
        /// 响应按键
        /// </summary>
        public abstract void ResponseClick();

        protected void NavigateTo(string stateKey)
        {
            ViewModel.Value.Controller.NavigateTo(stateKey);
        }

        protected void NavigateBack()
        {
            ViewModel.Value.Controller.NavigateBack();
        }

        protected void NavigateToRoot()
        {
            ViewModel.Value.Controller.NavigateToRoot();
        }
    }

}