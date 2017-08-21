﻿using System.Drawing;

namespace HXD1.DeepDomestic
{
    public class CurrentFaultRect
    {
        private Rectangle _mainRect;

        public RectText _type;

        public RectText _number;

        public RectText _code;

        public RectText _describe;

        public RectText _startTime;

        // public RectText _endTime;
        public int LogicNumber;

        public CurrentFaultRect(Rectangle mainRect, string itstype, string number, string code, string describe,
            string startTime, int logicNumber)
        {
            _mainRect = mainRect;
            _type = new RectText(new Rectangle(_mainRect.X, _mainRect.Y, 50, _mainRect.Height), itstype, 12, 1,
                Color.Red, Color.Yellow, Color.Wheat, 1, false, null, true, true);
            _number = new RectText(new Rectangle(_mainRect.X + 50, _mainRect.Y, 50, _mainRect.Height), number, 12, 1,
                Color.Black, Color.Gray, Color.Wheat, 1, false, null, true, true);
            _code = new RectText(new Rectangle(_mainRect.X + 100, _mainRect.Y, 70, _mainRect.Height), code, 12, 1,
                Color.White, Color.Blue, Color.Wheat, 1, false, null, true, true);
            _describe = new RectText(new Rectangle(_mainRect.X + 170, _mainRect.Y, 420, _mainRect.Height), describe, 12,
                0, Color.Black, Color.Yellow, Color.Wheat, 1, false, null, true, true);
            _startTime = new RectText(new Rectangle(_mainRect.X + 590, _mainRect.Y, 170, _mainRect.Height), startTime,
                12, 1, Color.Black, Color.Yellow, Color.Wheat, 1, false, null, true, true);
            //  _endTime = new RectText(new Rectangle(_mainRect.X + 640, _mainRect.Y, 160, _mainRect.Height), endTime, 12, 1, Color.Black, Color.Yellow, Color.Wheat, 1, false, null, true);
            LogicNumber = logicNumber;
        }

        public void Clear()
        {
            _type.Text = "";
            _type.BackgroundColor = Color.Yellow;
            _type.TextColor = Color.Red;

            _number.Text = "";
            _number.BackgroundColor = Color.Gray;
            _number.TextColor = Color.Black;

            _code.Text = "";
            _code.BackgroundColor = Color.Blue;
            _code.TextColor = Color.White;

            _describe.Text = "";
            _describe.BackgroundColor = Color.Yellow;
            _describe.TextColor = Color.Black;

            _startTime.Text = "";
            _startTime.BackgroundColor = Color.Yellow;
            _startTime.TextColor = Color.Black;
        }


        public void OnDraw(Graphics g)
        {
            _type.OnDraw(g);
            _number.OnDraw(g);
            _code.OnDraw(g);
            _describe.OnDraw(g);
            _startTime.OnDraw(g);
            // _endTime.OnDraw(g);
        }
    }
}