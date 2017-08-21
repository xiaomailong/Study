﻿using System;

namespace ES.JCTMS.Common.Control.Common
{
    /// <summary>
    ///     控件点击事件代理
    /// </summary>
    /// <param name="sender">事件发生对象</param>
    /// <param name="e">传输参数</param>
    public delegate void EventHandle_ClickEvent(object sender, ClickEventArgs<int> e);

    /// <summary>
    ///     功能描述：控件点击事件传输的参数类
    ///     创建人：lih
    ///     创建时间：2014-07-14
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ClickEventArgs<T> : EventArgs
    {
        /// <summary>
        ///     读取事件数据
        /// </summary>
        public T Message { get; }

        /// <summary>
        ///     空构造函数
        /// </summary>
        public ClickEventArgs()
        {
            //
        }

        /// <summary>
        ///     构造函数：获得事件数据状态
        /// </summary>
        /// <param name="message">数据</param>
        public ClickEventArgs(T message)
        {
            Message = message;
        }
    }
}