﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CommonControls
{
    public delegate void DefButtonClick(object sender,ButtonClickArgs e);

    public partial class DefButton : PictureBox
    {
        [Description("按钮文本"), Category("自定义属性")]
        [Browsable(true)]
        public Int32 ID
        {
            set { _id = value; }
            get { return _id; }
        }
        private Int32 _id = 1;

        [Description("按钮边框"), Category("自定义属性")]
        [Browsable(true)]
        public bool DefButtonBorder
        {
            set { _defButtonBorder = value; }
            get { return _defButtonBorder; }
        }
        private bool _defButtonBorder=false;

        [Description("边框宽度"), Category("自定义属性")]
        [Browsable(true)]
        public int DefBorderWidth
        {
            set { _defborderWidth = value; }
            get { return _defborderWidth; }
        }
        private int _defborderWidth = 1;

        [Description("按钮文本"), Category("自定义属性")]
        [Browsable(true)]
        public Int32 ViewID
        {
            set { _viewID = value; }
            get { return _viewID; }
        }
        private Int32 _viewID = 1;

        [Description("按钮文本"), Category("自定义属性")]
        [Browsable(true)]
        public String DefText
        {
            set { _defText = value; }
            get { return _defText; }
        }
        private String _defText = "";

        [Description("文本颜色"), Category("自定义属性")]
        [Browsable(true)]
        public Color UpColor
        {
            set { _upColor = value; }
            get { return _upColor; }
        }
        private Color _upColor = Color.White;

        [Description("文本颜色"), Category("自定义属性")]
        [Browsable(true)]
        public Color DownColor
        {
            set { _downColor = value; }
            get { return _downColor; }
        }
        private Color _downColor = Color.White;

        [Description("字体"), Category("自定义属性")]
        [Browsable(true)]
        public Font TextFont
        {
            set
            {
                _font = value;
            }
            get { return _font; }
        }
        private Font _font = new Font("宋体", 13);

        [Description("文本垂直方向偏移"), Category("自定义属性")]
        [Browsable(true)]
        public float YOffset
        {
            set { _yOffset = value; }
            get { return _yOffset; }
        }
        private float _yOffset;

        [Description("按钮弹起图片"), Category("自定义属性")]
        [Browsable(true)]
        public Image UpImage
        {
            set { _upImage = value; }
            get { return _upImage; }
        }
        private Image _upImage = null;

        [Description("按钮按下图片"), Category("自定义属性")]
        [Browsable(true)]
        public Image DownImage
        {
            set { _downImage = value; }
            get { return _downImage; }
        }
        private Image _downImage = null;

        [Description("按钮获得焦点图片"), Category("自定义属性")]
        [Browsable(true)]
        public Image FocusImage
        {
            set { _focusImage = value; }
            get { return _focusImage; }
        }
        private Image _focusImage = null;

        [Description("按钮是否按下"), Category("自定义属性")]
        [Browsable(true)]
        public Boolean IsDown
        {
            set
            {
                if (_isDown == value) return;
                _isDown = value;
                Refresh();
            }
            get { return _isDown; }
        }
        private Boolean _isDown = false;

        [Description("按钮是否按下"), Category("自定义属性")]
        [Browsable(true)]
        public Boolean IsSelfResetBtn
        {
            set
            {
                if (_isSelfResetBtn == value) return;
                _isSelfResetBtn = value;
            }
            get { return _isSelfResetBtn; }
        }
        private Boolean _isSelfResetBtn = true;

        [Description("按钮是否获得焦点"), Category("自定义属性")]
        [Browsable(true)]
        public Boolean IsFocused
        {
            get { return _isFocused; }
            set
            {
                if (_isFocused == value) return;
                _isFocused = value;

                Invalidate();
            }
        }
        private Boolean _isFocused = false;

        [Description("按钮是否无效"), Category("自定义属性")]
        [Browsable(true)]
        public Boolean IsEnable
        {
            set
            {
                if (_isEnable == value) return;
                _isEnable = value;
                Refresh();
            }
            get { return _isEnable; }
        }
        private Boolean _isEnable = true;

        [Browsable(true)]
        public event DefButtonClick DefClick
        {
            add { _click += value; }
            remove { if(_click!=null) _click -= value; }
        }
        private DefButtonClick _click = null;

        public DefButton()
        {
            InitializeComponent();
        }

        public void DefOnMouseDown()
        {
            IsDown = true;
        }

        public void DefOnMouseUp()
        {
            if (_isSelfResetBtn) IsDown = false;
            else
            {
                _clickCount = (_clickCount + 1) % 2;
                if (_clickCount == 0) IsDown = false;
                else IsDown = true;
            }
        }

        public void DefClickEvent()
        {
            if (_isSelfResetBtn) IsDown = false;
            else
            {
                _clickCount = (_clickCount + 1) % 2;
                if (_clickCount == 0) IsDown = false;
                else IsDown = true;
            }
        }

        private int _clickCount = 0;
        protected override void OnMouseDown(MouseEventArgs e)
        {
           // MessageBox.Show(e.Location.ToString() + "  " + this.Location.ToString());
            IsFocused = true;
            IsDown = true;
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (_isSelfResetBtn) IsDown = false;
            else
            {
                _clickCount = (_clickCount + 1)%2;
                if (_clickCount == 0) IsDown = false;
                else IsDown = true;
            }

            if (_click != null) _click(this, new ButtonClickArgs(this.ViewID));
            base.OnMouseUp(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            whitePen.Width = DefBorderWidth;
            if (DefButtonBorder)
            {
                e.Graphics.DrawRectangle(whitePen, 0, 0, Size.Width, Size.Height);
            }

            if (_upImage != null && _downImage != null)
                //绘制按钮背景
                e.Graphics.DrawImage(
                    _isDown ? _downImage : _upImage,
                    new RectangleF(
                        0,
                        0,
                        Size.Width,
                        Size.Height)
                    );

            if (IsFocused && _focusImage != null)
                e.Graphics.DrawImage(
                    _focusImage,
                    new RectangleF(
                        0,
                        0,
                        Size.Width,
                        Size.Height)
                    );

            //文本
            string text = "";
            if (this._defText.Contains("_"))
            {
                string[] texts = this.DefText.Split(new char[] { '_' });
                for (int i = 0; i < texts.Length; i++)
                {
                    if (i > 0) text += "\n";
                    text += texts[i];
                }
            }
            else text = _defText;
            solidBrush.Color = !_isEnable ? Color.FromArgb(147, 147, 147) : (_isDown ? _downColor : _upColor);
            e.Graphics.DrawString(
                text,
                _font,
                solidBrush,
                new RectangleF(
                    0,
                    0 + YOffset,
                    Size.Width,
                    Size.Height),
                stringForm
                );
        }
        StringFormat stringForm = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
        private Pen whitePen=new Pen(Color.White);
        private SolidBrush solidBrush = new SolidBrush(Color.Black);
    }

    public class ButtonClickArgs : EventArgs
    {
        public Int32 ViewID { get; set; }

        public ButtonClickArgs(Int32 viewID)
        {
            this.ViewID = viewID;
        }
    }
}
