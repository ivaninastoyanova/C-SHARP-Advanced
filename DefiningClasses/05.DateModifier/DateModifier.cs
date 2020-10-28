using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifier
{
    public class DateModifier
    {
        public int GetDaysDifference(string startDateAsString , string endDateAsString)
        {
            DateTime startDate = DateTime.Parse(startDateAsString);
            DateTime endDate = DateTime.Parse(endDateAsString);
            int daysDifference = (int)Math.Abs((startDate - endDate).TotalDays);
            return daysDifference;
        }
    }
}
