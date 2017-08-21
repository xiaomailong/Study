﻿using System.Diagnostics;
using Microsoft.Practices.Prism.Events;
using MMI.Facility.Interface.Data;

namespace LightRail.HMI.GZYGDC.Event
{
    public class DataServiceDataChangedEvent : CompositePresentationEvent<DataServiceDataChangedEvent.Args>
    {
        public class Args
        {
            [DebuggerStepThrough]
            public Args(object sender, CommunicationDataChangedArgs dataChangedArgs)
            {
                Sender = sender;
                DataChangedArgs = dataChangedArgs;
            }

            public object Sender { private set; get; }

            public CommunicationDataChangedArgs DataChangedArgs { private set; get; }
        }
    }
}