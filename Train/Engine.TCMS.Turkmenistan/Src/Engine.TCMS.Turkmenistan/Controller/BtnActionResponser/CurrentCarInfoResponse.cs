﻿using System.ComponentModel.Composition;
using Engine.TCMS.Turkmenistan.Constant;
using Engine.TCMS.Turkmenistan.Event;
using Engine.TCMS.Turkmenistan.Model;
using Engine.TCMS.Turkmenistan.Model.BtnStragy;
using Engine.TCMS.Turkmenistan.Resources.Keys;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;

namespace Engine.TCMS.Turkmenistan.Controller.BtnActionResponser
{
    [Export]
    public class CurrentCarInfoResponse : IBtnActionResponser
    {
        private readonly NavigatorToView _navigatorToView;

        public CurrentCarInfoResponse()
        {
            _navigatorToView =  ServiceLocator.Current.GetInstance<IEventAggregator>().GetEvent<NavigatorToView>();
        }

        public BtnItem Parent { get; set; }
        public void UpdateState()
        {

        }

        public void ResponseClick()
        {
            GlobalParam.Instance.IsReconnection = !GlobalParam.Instance.IsReconnection;
            if (GlobalParam.Instance.IsReconnection)
            {
                var @event = ServiceLocator.Current.GetInstance<IEventAggregator>().GetEvent<NavigatorToState>();
                @event.Publish(new NavigatorToState.Args(StateKeys.Root_重连信息));
                _navigatorToView.Publish(new NavigatorToView.Args(ViewNames.ReconnectionRunparamView));
                _navigatorToView.Publish(new NavigatorToView.Args(ViewNames.ReconnectionProgressBarView));
                _navigatorToView.Publish(new NavigatorToView.Args(ViewNames.CurrentAxleView));
            }
            else
            {
                var @event = ServiceLocator.Current.GetInstance<IEventAggregator>().GetEvent<NavigatorToState>();
                @event.Publish(new NavigatorToState.Args(StateKeys.Root_本车信息));
               _navigatorToView.Publish(new NavigatorToView.Args(ViewNames.CurrentAxleView));
               _navigatorToView.Publish(new NavigatorToView.Args(ViewNames.CurrentProgressbarView));
               _navigatorToView.Publish(new NavigatorToView.Args(ViewNames.CurrentRunparamView));
            }

        }
    }
}