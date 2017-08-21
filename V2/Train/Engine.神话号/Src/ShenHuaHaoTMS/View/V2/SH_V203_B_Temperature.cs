﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonControls;
using MMI.Facility.Interface.Data;
using MMI.Facility.Interface.Extension;
using MMI.Facility.Interface.Project;
using MMI.Facility.Interface.Service;
using ShenHuaHaoTMS.Common;
using YunDa.JC.MMI.Common;
using ShenHuaHaoTMS.DefControls;
using YunDa.JC.MMI.Common.Extensions;

namespace ShenHuaHaoTMS.View
{
    public partial class SH_V203_B_Temperature : UserControl, IView,IDisposable, IDataListener
    {
        public int ID { get; set; }


        private readonly ListenViewChangedBridge m_ListenViewChanged = new ListenViewChangedBridge();public bool IsShow
        {
            get { return _isShow; }
            set
            {
                if (_isShow == value)
                {
                    return;
                }

                _isShow = value;

                if (_isShow) //显示
                {
                    if (!ViewManger.Contains(this))
                    {
                        _btn_1.DefText = "机车_" + _bv.LocalTrainInfo.RealTrainID + "A";
                        _btn_Null_2.DefText = "机车_" + _bv.LocalTrainInfo.RealTrainID + "B";
                        ViewManger.Add(this);
                        this.InvokeShow();;
                        GlobalParam.Instance.InitParam.RegistDataListener(m_ListenViewChanged);
                    }
                }
                else//隐藏
                {
                    if (ViewManger.Contains(this))
                    {
                        ViewManger.Remove(this);
                        this.InvokeHide();;
                        _viewBtns.ForEach(a => a.IsDown = false);
                        GlobalParam.Instance.InitParam.UnregistDataListener(m_ListenViewChanged);
                    }
                }
            }
        }
        private bool _isShow = false;

        public ViewManager ViewManger { get; set; }
        private ICommunicationDataService _dataService;

        private List<DefButton> _viewBtns = new List<DefButton>();
        private List<ILogic> _statesControls = new List<ILogic>();
        private BlackView _bv = null;

        public SH_V203_B_Temperature()
        {
            InitializeComponent();
        }

        public SH_V203_B_Temperature(Int32 id, ViewManager viewManager, ICommunicationDataService dataService, BlackView bv, SubsystemInitParam initParam)
        {
            InitializeComponent();
            _dataService = dataService;

            Dock = DockStyle.Fill;
            Margin = new Padding(0);

            ID = id;
            ViewManger = viewManager;
            ViewManger.Register(this);
            m_ListenViewChanged = new ListenViewChangedBridge();
            m_ListenViewChanged.BoolChanged += onViewChanged;
            GlobalParam.Instance.InitParam.RegistDataListener(this);

            _viewBtns = new List<DefButton>()
            {
                _btn_1,
                _btn_10
            };

            _statesControls = new List<ILogic>()
            {
                _defState_1,
                _defState_2,
                _defState_3,
                _defState_4,
                _defState_5,
                _defState_6,
                _defState_7,
                _defState_8,
                _defState_9,
                _defState_10,
                _defState_11,
                _defState_12,
                defState1
            };

            _bv = bv;

            _title_TrainName.DefText = "神华号 " + bv.LocalTrainInfo.RealTrainID + "B";

            initParam.DataPackage.ServiceManager.GetService<IDisposeService>().RegistDisposableObject(this);
        }
        void onViewChanged(object sender, CommunicationDataChangedArgs<bool> e)
        {
            foreach (var cmd in e.NewValue)
            {
                if (cmd.Key >= 800 && cmd.Key < 825)//按钮命令
                {
                    if (cmd.Value && _isShow)
                    {
                        DefButton btn = _viewBtns.Find(a => a.ID == cmd.Key);
                        if (btn != null)
                        {
                            btn.IsDown = true;
                            ViewManger.CurrentViewID = btn.ViewID;
                        }
                    }
                }
            }
        }

        private void DefButtonClick(object sender, ButtonClickArgs e)
        {
            ViewManger.CurrentViewID = e.ViewID;
        }

        public void InvalidateNew()
        {
        }
        public void Dispose()
        {
            _statesControls.ForEach(a => ((DefState)a).Dispose());
        }

        /// <summary>bool 值变化</summary>
        /// <param name="sender"></param>
        /// <param name="dataChangedArgs"></param>
        public void OnBoolChanged(object sender, CommunicationDataChangedArgs<bool> dataChangedArgs)
        {
            foreach (var cmd in dataChangedArgs.NewValue)
            {
                foreach (var item in _statesControls)
                {
                    ILogic logic = null;
                    foreach (var item1 in item.DataConfigInfoCollection)
                    {
                        if (item1.BoolLogic == cmd.Key)
                        {
                            logic = item;
                            logic.CurrentDataConfigInfo = item1;
                            break;
                        }
                    }
                    if (logic != null)
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>float值变化</summary>
        /// <param name="sender"></param>
        /// <param name="dataChangedArgs"></param>
        public void OnFloatChanged(object sender, CommunicationDataChangedArgs<float> dataChangedArgs)
        {
            foreach (var cmd in dataChangedArgs.NewValue)
            {
                foreach (var item in _statesControls)
                {
                    ILogic logic = null;
                    foreach (var item1 in item.DataConfigInfoCollection)
                    {
                        if (item1.FloatLogic == cmd.Key)
                        {
                            logic = item;
                            DataConfigInfo dci = new DataConfigInfo();
                            dci.DefText = cmd.Value.ToString();
                            if (item1.DefText != null && item1.DefText != "")
                            {
                                if (item1.DefText.Contains("{") && item1.DefText.Contains("}"))
                                {
                                    int indexStart = item1.DefText.IndexOf('{');
                                    int indexEnd = item1.DefText.IndexOf('}');
                                    String str1 = item1.DefText.Substring(0, indexStart);
                                    String str2 = item1.DefText.Substring(indexStart + 1, indexEnd - indexStart - 1);
                                    String str3 = item1.DefText.Substring(indexEnd + 1);
                                    dci.DefText = str1 + cmd.Value.ToString(str2) + str3;
                                }
                            }
                            logic.CurrentDataConfigInfo = dci;
                            break;
                        }
                    }
                    if (logic != null)
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>data值变化</summary>
        /// <param name="sender"></param>
        /// <param name="dataChangedArgs"></param>
        public void OnDataChanged(object sender, CommunicationDataChangedArgs dataChangedArgs)
        {
        }
    }
}
