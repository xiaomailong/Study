﻿using System;
using System.Drawing;

namespace CommonUtil.Util
{
    /// <summary>
    /// StringExtension
    /// </summary>
    public static class StringExtension
    {

        /// <summary>
        ///  == null || == Empty || == WhiteSpace
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            if (value == null)
            {
                return true;
            }
            return string.Empty == value.Trim();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static decimal AsDecimal(this string inputValue)
        {
            decimal result;
            if (!decimal.TryParse(inputValue, out result))
            {
                result = 0;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static DateTime AsDateTime(this string inputValue)
        {
            DateTime result;
            if (!DateTime.TryParse(inputValue, out result))
            {
                result = DateTime.MinValue;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static float AsFloat(this string inputValue)
        {
            float result;
            if (!float.TryParse(inputValue, out result))
            {
                result = 0;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static double AsDouble(this string inputValue)
        {
            double result;
            if (!double.TryParse(inputValue, out result))
            {
                result = 0;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static int AsInt(this string inputValue)
        {
            int result;
            if (!int.TryParse(inputValue, out result))
            {
                result = 0;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static byte AsByte(this string inputValue)
        {
            byte result;
            if (!byte.TryParse(inputValue, out result))
            {
                result = 0;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static sbyte AsSbyte(this string inputValue)
        {
            sbyte result;
            if (!sbyte.TryParse(inputValue, out result))
            {
                result = 0;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static short AsShort(this string inputValue)
        {
            short result;
            if (!short.TryParse(inputValue, out result))
            {
                result = 0;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static ushort AsUshort(this string inputValue)
        {
            ushort result;
            if (!ushort.TryParse(inputValue, out result))
            {
                result = 0;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static uint AsUint(this string inputValue)
        {
            uint result;
            if (!uint.TryParse(inputValue, out result))
            {
                result = 0;
            }
            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static long AsLong(this string inputValue)
        {
            long result;
            if (!long.TryParse(inputValue, out result))
            {
                result = 0;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static ulong AsUlong(this string inputValue)
        {
            ulong result;
            if (!ulong.TryParse(inputValue, out result))
            {
                result = 0;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static char AsChar(this string inputValue)
        {
            char result;
            if (!char.TryParse(inputValue, out result))
            {
                result = '\0';
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static bool AsBool(this string inputValue)
        {
            bool result;
            if (!bool.TryParse(inputValue, out result))
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static Color AsColor(this string inputValue)
        {
            try
            {
                var converter = new ColorConverter();
                var convertFromString = converter.ConvertFromString(inputValue);
                if (convertFromString != null)
                {
                    return (Color)convertFromString;
                }
                return new Color();
            }
            catch
            {
                return new Color();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static Point AsPoint(this string inputValue)
        {
            try
            {
                var data = inputValue.Split(new[] {','});
                return new Point(data[0].AsInt(), data[1].AsInt());
            }
            catch (Exception)
            {
                return new Point();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static PointF AsPointF(this string inputValue)
        {
            try
            {
                var data = inputValue.Split(new[] { ',' });
                return new PointF(data[0].AsFloat(), data[1].AsFloat());
            }
            catch (Exception)
            {
                return new PointF();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static Size AsSize(this string inputValue)
        {
            try
            {
                var data = inputValue.Split(new[] { ',' });
                return new Size(data[0].AsInt(), data[1].AsInt());
            }
            catch (Exception)
            {
                return new Size();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static SizeF AsSizeF(this string inputValue)
        {
            try
            {
                var data = inputValue.Split(new[] { ',' });
                return new SizeF(data[0].AsFloat(), data[1].AsFloat());
            }
            catch (Exception)
            {
                return new SizeF();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static Rectangle AsRectangle(this string inputValue)
        {
            try
            {
                var data = inputValue.Split(new[] { ',' });
                return new Rectangle(data[0].AsInt(), data[1].AsInt(),data[2].AsInt(), data[3].AsInt());
            }
            catch (Exception)
            {
                return new Rectangle();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static RectangleF AsRectangleF(this string inputValue)
        {
            try
            {
                var data = inputValue.Split(new[] { ',' });
                return new RectangleF(data[0].AsFloat(), data[1].AsFloat(), data[2].AsFloat(), data[3].AsFloat());
            }
            catch (Exception)
            {
                return new RectangleF();
            }
        }
    }
}
