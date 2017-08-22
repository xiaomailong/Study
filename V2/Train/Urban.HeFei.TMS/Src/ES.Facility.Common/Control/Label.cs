﻿using System;
using System.Drawing;
using ES.Facility.Common.Control.Common;

namespace ES.Facility.Common.Control
{
    public class LabelStyle:IStyle
    {
        /// <summary>
        /// 读取或设置控件背景图片属性
        /// </summary>
        public Image Background { get; set; }

        /// <summary>
        /// 读取或设置字体样式属性
        /// </summary>
        public FontStyleEs FontStyle { get; set; }

        /// <summary>
        /// 读取或设置背景画刷属性（当不使用图片作为背景时，使用画刷对背景进行绘制）
        /// </summary>
        public Brush BackgroundBrush { get; set; }
        /// <summary>
        /// 读取或设置边框画笔属性（不设置该属性，控件将没有边框）
        /// </summary>
        public Pen BorderPen { get; set; }
    }

    /// <summary>
    /// 功能描述：文本显示框
    /// 创建人：lih
    /// 创建时间：2014-07-16
    /// </summary>
    public class Label : IControl
    {
        #region 属性/变量
        /// <summary>
        /// 读取或设置按钮文本属性
        /// </summary>
        public string Text
        {
            get { return m_Text; }
            set { m_Text = value; }
        }
        private string m_Text = string.Empty;

        /// <summary>
        /// 读取按钮标识ID属性
        /// </summary>
        public int ID
        {
            get { return m_ID; }
        }
        private int m_ID = -1;

        /// <summary>
        /// 读取按钮Style属性（使用时需转换为ButtonStyle）
        /// </summary>
        public IStyle Style
        {
            get { return m_Style; }
        }
        private IStyle m_Style;

        /// <summary>
        /// 读取或设置按钮所在矩形区域属性
        /// </summary>
        public RectangleF Rect
        {
            get { return m_Rect; }
            set
            {
                if (m_Rect == value)
                    return;

                m_Rect = value;
            }
        }
        private RectangleF m_Rect;

        /// <summary>
        /// 读取或设置是否获得焦点属性（功能后续添加）
        /// </summary>
        public bool IsFocus
        {
            get { return m_IsFocus; }
            set
            {
                if (m_IsFocus == value)
                    return;

                m_IsFocus = value;
            }
        }
        private bool m_IsFocus = false;
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="rect">所在矩形区域</param>
        /// <param name="style">样式</param>
        /// <param name="id">id</param>
        public Label(string text,RectangleF rect,LabelStyle style,int id)
        {
            m_Text = text;
            m_Rect = rect;
            m_Style = style;
            m_ID = id;
        }

        /// <summary>
        /// Label绘制（需在界面Paint函数中调用）
        /// </summary>
        /// <param name="dcGs"></param>
        public void Paint(Graphics dcGs)
        {
            //if (((LabelStyle)this._style).Background != null)
            //{
            //    dcGs.DrawImage(((LabelStyle)this._style).Background, this._rect);
            //}
            //else if (((LabelStyle)this._style).BackgroundBrush != null)
            //{
            //    dcGs.DrawRectangle(new Pen(new SolidBrush(Color.Black)), _rect.X, _rect.Y, _rect.Width, _rect.Height);
            //    dcGs.FillRectangle(((LabelStyle)this._style).BackgroundBrush, new RectangleF(_rect.X + 1, _rect.Y + 1, _rect.Width - 2, _rect.Height - 2));
            //}
            //else
            //{
            //    dcGs.DrawRectangle(new Pen(new SolidBrush(Color.Black)), _rect.X, _rect.Y, _rect.Width, _rect.Height);
            //}

            if (((LabelStyle)m_Style).BorderPen != null)
            {
                dcGs.DrawRectangle(((LabelStyle)m_Style).BorderPen, m_Rect.X, m_Rect.Y, m_Rect.Width, m_Rect.Height);
                if (((LabelStyle)m_Style).Background != null)
                {
                    dcGs.DrawImage(((LabelStyle)m_Style).Background, new RectangleF(m_Rect.X + 1, m_Rect.Y + 1, m_Rect.Width - 1, m_Rect.Height - 1));
                }
                else if (((LabelStyle)m_Style).BackgroundBrush != null)
                {
                    dcGs.FillRectangle(((LabelStyle)m_Style).BackgroundBrush, new RectangleF(m_Rect.X + 1, m_Rect.Y + 1, m_Rect.Width - 1, m_Rect.Height - 1));
                }
            }
            else
            {
                if (((LabelStyle)m_Style).Background != null)
                {
                    dcGs.DrawImage(((LabelStyle)m_Style).Background, m_Rect);
                }
                else if (((LabelStyle)m_Style).BackgroundBrush != null)
                {
                    dcGs.FillRectangle(((LabelStyle)m_Style).BackgroundBrush, m_Rect);
                }
            }

            dcGs.DrawString(
                m_Text, 
                ((LabelStyle)m_Style).FontStyle.Font, 
                ((LabelStyle)m_Style).FontStyle.TextBrush, 
                new RectangleF(m_Rect.X-2, m_Rect.Y + 2, m_Rect.Width+4, m_Rect.Height), 
                ((LabelStyle)m_Style).FontStyle.StringFormat
                );
        }
    }
}