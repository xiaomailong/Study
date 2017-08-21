﻿using System;

namespace Engine.LCDM.HXD3.LCMDAtt
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DeactiveAttribute : Attribute
    {
        public DeactiveAttribute()
        {

        }
        public string RegionName { get; set; }
    }
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ActiveAttribute : Attribute
    {
        public ActiveAttribute()
        {

        }
        public string RegionName { get; set; }
        public Type ControlType { get; set; }
    }
}