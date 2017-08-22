﻿using System;
using System.IO;
using System.Text;

namespace MMITool.Platform.Resource.Images
{
    internal static class ImageResCreater
    {
        public static void Create()
        {
            var dir =
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\Src\MMI.Tools\Desktop\MMITool.Platform\Resource\Images\Detail"));

            var format = "<ImageSource x:Key=\"MMITool.Platform.Image.{0}\">Detail/{1}</ImageSource>\r\n";

            var imgs = Directory.GetFiles(dir, "*.png");

            var sb = new StringBuilder();

            sb.Append(
                "<ResourceDictionary xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\"><!--ReSharper disable InconsistentNaming--> ");

            foreach (var i in imgs)
            {
                sb.AppendFormat(format, Path.GetFileNameWithoutExtension(i), Path.GetFileName(i));
            }
            sb.Append("<!--  ReSharper restore InconsistentNaming  --></ResourceDictionary> ");
            // ReSharper disable once UnusedVariable
            var s = sb.ToString();

            var target = Path.Combine(dir, @"..\ImageResource.xaml");

            File.WriteAllText(target, s);
        }
    }
}