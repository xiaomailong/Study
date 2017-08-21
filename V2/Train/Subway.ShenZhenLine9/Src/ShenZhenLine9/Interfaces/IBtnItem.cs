﻿using System.Windows.Input;

namespace Subway.ShenZhenLine9.Interfaces
{
    /// <summary>
    /// 按钮
    /// </summary>
    public interface IBtnItem
    {
        /// <summary>
        /// 按钮文字
        /// </summary>
        string Text { get; set; }
        /// <summary>
        /// 响应类
        /// </summary>
        IBtnResponse Response { get; }
        /// <summary>
        /// 命令
        /// </summary>
        ICommand Command { get; }
        /// <summary>
        /// 故障
        /// </summary>
        bool IsFault { get; set; }
    }
}