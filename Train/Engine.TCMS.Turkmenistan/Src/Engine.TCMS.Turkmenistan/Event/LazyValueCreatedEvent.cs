﻿using Microsoft.Practices.Prism.Events;

namespace Engine.TCMS.Turkmenistan.Event
{
    /// <summary>
    /// 模型被创建出来，用于更新 Lazy 类型的数据
    /// </summary>
    public class LazyValueCreatedEvent : CompositePresentationEvent<LazyValueCreatedEvent.Args>
    {
        public class Args
        {
            
        }
    }
}