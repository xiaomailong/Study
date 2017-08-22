﻿using System.Drawing;
using MMI.Facility.Interface;
using MMI.Facility.Interface.Attribute;

namespace Subway.ATC.THALES.VOBC
{
    [GksDataType(DataType.isMMIObjectClass)]
    public class V1_C5_Position_EB_Indicator : baseClass
    {
        public override string GetInfo()
        {
            return "位置与EB指示";
        }

        public override bool init(ref int nErrorObjectIndex)
        {

            return true;
        }

        public override void paint(Graphics dcGs)
        {
            Font f = new Font("Arial", 13, FontStyle.Bold);
            for (int i = 0; i < 2; i++)
            {
                if (BoolList[UIObj.InBoolList[0] + i])
                {
                    Brush b = new SolidBrush(Color.FromArgb(0, 255, 0));
                    if (i == 1)
                    {
                        b = new SolidBrush(Color.Red);
                    }
                    dcGs.DrawString(
                        "位置", 
                        f, 
                        b, 
                        new RectangleF(504, 115,141,45),
                        new StringFormat() {  Alignment= StringAlignment.Center, LineAlignment= StringAlignment.Center}
                        );
                    break;
                }
            }

                if (BoolList[UIObj.InBoolList[1] + 1])
                {
                    dcGs.DrawString(
                        "紧急制动", 
                        f, 
                        new SolidBrush(Color.Red),
                        new RectangleF(650, 115,141,45),
                        new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center }
                        );
                }

            
        }
    }
}