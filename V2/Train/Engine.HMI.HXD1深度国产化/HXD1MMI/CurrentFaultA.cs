﻿using System.Collections.Generic;
using System.Drawing;
using CommonUtil.Controls;
using MMI.Facility.Interface;
using MMI.Facility.Interface.Attribute;
using MMI.Facility.Interface.Data;

namespace HXD1.DeepDomestic
{
    /// <summary>
    /// 当前故障A
    /// </summary>
    [GksDataType(DataType.isMMIObjectClass)]
    internal class CurrentFaultA : baseClass
    {
        public static List<Fault> SortedFaultList = new List<Fault>();
        private List<CurrentFaultRect> _currentRectList = new List<CurrentFaultRect>();

        private int selectFaultIndex = 0;

        private int _currentPage = 0;

        private CurrentBackGround _backGround = new CurrentBackGround(
            new Rectangle(10, 70, 50, 460),
            new Rectangle(60, 70, 50, 460),
            new Rectangle(110, 70, 70, 460),
            new Rectangle(180, 70, 420, 460),
            new Rectangle(600, 70, 170, 460)
            );

        private CurrentFaultTitleRect _currentFaultTitleRect = new CurrentFaultTitleRect(
            new Rectangle(10, 40, 760, 30), "类别", "车号", "代码", "故障内容", "故障发生时间");

        public override string GetInfo()
        {
            return "当前故障";
        }

        public override bool init(ref int nErrorObjectIndex)
        {
            for (int i = 0; i < 15; i++)
            {
                _currentRectList.Add(new CurrentFaultRect(new Rectangle(10, 70 + 30 * i, 760, 30), "", "", "", "", "", 0));

            }
            return true;
        }

        public void GetCurrentFault()
        {

        }

        private void DrawSelectRect()
        {
            if (SortedFaultList.Count > 0)
            {
                _currentRectList[selectFaultIndex]._type.BackgroundColor = Color.DarkBlue;
                _currentRectList[selectFaultIndex]._type.TextColor = Color.White;

                _currentRectList[selectFaultIndex]._code.BackgroundColor = Color.DarkBlue;
                _currentRectList[selectFaultIndex]._code.TextColor = Color.White;

                _currentRectList[selectFaultIndex]._number.BackgroundColor = Color.DarkBlue;
                _currentRectList[selectFaultIndex]._number.TextColor = Color.White;

                _currentRectList[selectFaultIndex]._startTime.BackgroundColor = Color.DarkBlue;
                _currentRectList[selectFaultIndex]._startTime.TextColor = Color.White;

                _currentRectList[selectFaultIndex]._describe.BackgroundColor = Color.DarkBlue;
                _currentRectList[selectFaultIndex]._describe.TextColor = Color.White;
            }
        }

        private void SetPage()
        {
            if (BoolList[ReceiveRequest.ButtonInfoDictionary[ButtonType.Information].LogicIndex] ||ReceiveRequest.ButtonInfoDictionary[ButtonType.Information].State == MouseState.MouseDown)
            {
                if (SortedFaultList.Count > 0)
                {
                    FaultAssistInfo.CurrentFault = SortedFaultList[_currentPage * 15 + selectFaultIndex];

                    append_postCmd(CmdType.ChangePage, 25, 0, 0);
                }
            }

            if (BoolList[ReceiveRequest.ButtonInfoDictionary[ButtonType.Up].LogicIndex] ||ReceiveRequest.ButtonInfoDictionary[ButtonType.Up].State == MouseState.MouseDown) //下一页
            {
                int nowValue = selectFaultIndex + 1;

                int limit = SortedFaultList.Count - _currentPage * 15;

                limit = limit >= 15 ? 15 : limit;

                selectFaultIndex = nowValue >= limit ? selectFaultIndex : nowValue;
            }

            if (BoolList[ReceiveRequest.ButtonInfoDictionary[ButtonType.Down].LogicIndex] ||ReceiveRequest.ButtonInfoDictionary[ButtonType.Down].State == MouseState.MouseDown) //上一页
            {
                int nowValue = selectFaultIndex - 1;
                selectFaultIndex = nowValue < 0 ? 0 : nowValue;

            }

            if (BoolList[ReceiveRequest.ButtonInfoDictionary[ButtonType.Left].LogicIndex] ||ReceiveRequest.ButtonInfoDictionary[ButtonType.Left].State == MouseState.MouseDown) //下一页
            {
                int nowValue = _currentPage + 1;
                _currentPage = nowValue > SortedFaultList.Count / 15 ? _currentPage : nowValue;
                selectFaultIndex = 0;
            }

            if (BoolList[ReceiveRequest.ButtonInfoDictionary[ButtonType.Right].LogicIndex] ||ReceiveRequest.ButtonInfoDictionary[ButtonType.Right].State == MouseState.MouseDown) //上一页
            {
                int nowValue = _currentPage - 1;
                _currentPage = nowValue < 0 ? 0 : nowValue;
                selectFaultIndex = 0;
            }
        }

        public void Clear()
        {
            for (int i = 0; i < _currentRectList.Count; i++)
            {
                _currentRectList[i].Clear();
            }
        }

        public override void paint(Graphics dcGs)
        {
            Clear();
            SetPage(); //新增

            GetCurrentFault();



            _backGround.OnDraw(dcGs);
            _currentFaultTitleRect.OnDraw(dcGs);

            DrawSelectRect(); //新增

            for (int i = _currentPage * 15; i < SortedFaultList.Count && i - _currentPage * 15 < 15; i++)
            {
                _currentRectList[i - _currentPage * 15]._number.Text = SortedFaultList[i].TrainNum.ToString();
                _currentRectList[i - _currentPage * 15]._type.Text = SortedFaultList[i].Level.ToString();
                _currentRectList[i - _currentPage * 15]._code.Text = SortedFaultList[i].FaultID.ToString();
                _currentRectList[i - _currentPage * 15]._describe.Text = SortedFaultList[i].FaultText.ToString();
                _currentRectList[i - _currentPage * 15]._startTime.Text = SortedFaultList[i].HappenedTime.ToString();

            }

            foreach (var v in _currentRectList)
            {
                v.OnDraw(dcGs);
            }
        }
    }
}
