using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Core.Classes
{
    public static class DateConvertor
    {
        public static string ToShamsi(this DateTime time)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(time).ToString("0000") + "/" + pc.GetMonth(time).ToString("00") + "/" +
                pc.GetDayOfMonth(time).ToString("00");
        }
    }
}
