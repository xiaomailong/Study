﻿using System;
using System.IO;
using System.Xml.Serialization;

namespace Motor.HMI.CRH5A.Config.ConfigModel
{
    [XmlRoot]
    public class ProjectConfig : ICorrectable
    {
        public string DetailConfigFile { set; get; }

        public AccessControlConfig AccessControlConfig { set; get; }

        public CRH5AFileConfig CRH5AFileConfig { set; get; }

        [XmlIgnore]
        public static string File { get { return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config\\ProjectConfig.xml"); } }

        public void Correct(string dirctory)
        {
            DetailConfigFile = Path.Combine(dirctory, DetailConfigFile);
            CRH5AFileConfig.Correct(dirctory);
        }
    }

    public class AccessControlConfig
    {
        public bool CanSkipBeginViewByClickZeroButton { set; get; }
    }
}