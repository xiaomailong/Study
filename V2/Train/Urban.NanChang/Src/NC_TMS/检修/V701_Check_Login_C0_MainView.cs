﻿#region 文件说明
/*--------------------------------------------------------------------------------------------------
 * 
 * Copyright(C) 成都运达科技股份有限公司
 * 创建人：唐林
 * 创建时间：2014-7-10
 * 
 * -------------------------------------------------------------------------------------------------
 * 
 * 功能描述：视图701-检修-登陆-No.0-主界面
 * 
 *-------------------------------------------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using MMI.Facility.Interface;
using MMI.Facility.Interface.Attribute;
using NC_TMS.Common;
using ES.Facility.Common.Control;
using ES.Facility.Common.Control.Common;
using ES.Facility.Common;

namespace NC_TMS
{
    /// <summary>
    /// 功能描述：视图701-检修-登陆-No.0-主界面
    /// 创建人：唐林
    /// 创建时间：2014-7-10
    /// </summary>
    [GksDataType(MMI.Facility.Interface.Attribute.DataType.isMMIObjectClass)]
    public class V701_Check_Login_C0_MainView : baseClass
    {
        #region 私有变量
        private List<Image> _resource_Image = new List<Image>();//图片资源
        private List<Button> _btns = new List<Button>();//按钮列表
        private String _password = String.Empty;//密码
        #endregion

        #region 框架初始化函数
        /// <summary>
        /// 获取组件描述信息
        /// </summary>
        /// <returns>组件描述信息</returns>
        public override string GetInfo()
        {
            return "检修试图-登陆页面-主界面";
        }

        /// <summary>
        /// 初始化函数：导入图片资源与创建自定义控件
        /// </summary>
        /// <param name="nErrorObjectIndex"></param>
        /// <returns></returns>
        public override bool init(ref int nErrorObjectIndex)
        {
            UIObj.ParaList.ForEach(a =>
            {
                using (FileStream fs = new FileStream(Path.Combine(RecPath , a), FileMode.Open))
                {
                    this._resource_Image.Add(Image.FromStream(fs));
                }
            });

            for (int i = 0; i < 10; i++)
            {
                Button btn = new Button(
                    ((i + 1) % 10).ToString(),
                    new RectangleF(375 + (i % 3 * 102), 169 + (i / 3 * 48), 100, 44),
                    i,
                    new ButtonStyle() { FontStyle = FontStyles.FS_Song_13_CC_B, Background = _resource_Image[0], DownImage = _resource_Image[1]}
                    );
                btn.ClickEvent += btn_ClickEvent;
                this._btns.Add(btn);
            }

            Button btn_DEL = new Button(
                "DEL",
                new RectangleF(375 + (10 % 3 * 102), 169 + (10 / 3 * 48), 202, 44),
                10,
                new ButtonStyle() { FontStyle = FontStyles.FS_Song_13_CC_B, Background = _resource_Image[0], DownImage = _resource_Image[1]}
                );
            btn_DEL.ClickEvent += btn_ClickEvent;
            this._btns.Add(btn_DEL);

            String[] str_ = new String[] { "确定", "取消" };
            for (int i = 0; i < 2; i++)
            {
                Button btn = new Button(
                    str_[i],
                    new RectangleF(375 + (i * 204), 378, 100, 44),
                    11 + i,
                    new ButtonStyle() { FontStyle = FontStyles.FS_Song_13_CC_B, Background = _resource_Image[0], DownImage = _resource_Image[1]}
                    );
                btn.ClickEvent += btn_ClickEvent;
                this._btns.Add(btn);
            }

            return true;
        }
        #endregion

        #region 鼠标事件
        public override bool mouseDown(Point nPoint)
        {
            this._btns.ForEach(a => a.MouseDown(nPoint));
            return base.mouseDown(nPoint);
        }

        public override bool mouseUp(Point nPoint)
        {
            this._btns.ForEach(a => a.MouseUp(nPoint));
            return base.mouseUp(nPoint);
        }

        /// <summary>
        /// 检修按钮弹起事件响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btn_ClickEvent(object sender, ClickEventArgs<int> e)
        {
            switch (e.Message)
            {
                case 10://DEL按钮
                    if (this._password.Length == 0)
                        break;
                    this._password = this._password.Substring(0, this._password.Length - 1);
                    break;
                case 11://确定按钮
                    //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>确定按钮直接进入检修主界面，后续添加验证功能<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    append_postCmd(MMI.Facility.Interface.Data.CmdType.ChangePage, (Int32)ViewState.检修, 0, 0);
                    //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<End>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    break;
                case 12://取消按钮
                    append_postCmd(MMI.Facility.Interface.Data.CmdType.ChangePage, (Int32)ViewState.运行, 0, 0);
                    break;
                default://0-9数字按钮
                    if (this._password.Length == 6)
                        break;
                    this._password += ((e.Message + 1) % 10).ToString();
                    break;
            }
        }
        #endregion

        #region 界面绘制
        public override void paint(Graphics dcGs)
        {
            this._btns.ForEach(a => a.Paint(dcGs));
            this.paint_Password(dcGs);

            base.paint(dcGs);
        }

        /// <summary>
        /// 绘制密码
        /// </summary>
        /// <param name="dcGs"></param>
        private void paint_Password(Graphics dcGs)
        {
            dcGs.DrawString("请输入密码：", new Font("宋体", 11), Brushs.WhiteBrush, new Point(122,250), FontInfo.SF_LC);
            dcGs.DrawImage(_resource_Image[2], new RectangleF(122,256,192,54));
            String password = String.Empty;
            for (int i = 0; i < this._password.Length; i++)
            {
                password += "*";
            }
            dcGs.DrawString(password, new Font("宋体", 11), Brushs.WhiteBrush, new RectangleF(122,256,192,54), FontInfo.SF_LC);
        }
        #endregion
    }
}
