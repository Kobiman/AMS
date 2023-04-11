using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared
{
    public class DateRange
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public void GetDates(out DateTime startDate, out DateTime endDate)
        {
            if (StartDate == null || EndDate == null)
            {
                GetDates("Today", out DateTime sDate, out DateTime eDate);
                startDate = sDate;
                endDate = eDate;
            }
            else
            {
                startDate = StartDate.Value;
                endDate = EndDate.Value;
            }
        }
        public static void GetDates(string period, out DateTime startDate, out DateTime endDate)
        {
            DateTime date = DateTime.Now.Date;
            if (period == "Today")
            {
                startDate = date.Date;
                endDate = date.AddHours(24);
            }
            else if (period == "This Week")
            {
                startDate = date.AddDays(-(int)date.DayOfWeek + (int)DayOfWeek.Sunday);
                endDate = startDate.AddDays(7);
            }

            else if (period == "This Month")
            {
                startDate = new DateTime(date.Year, date.Month, 1);
                int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
                endDate = startDate.AddDays(daysInMonth);
            }
            else if (period == "This Year")
            {
                startDate = new DateTime(date.Year, 1, 1);
                endDate = new DateTime(date.Year, 12, 31).AddDays(1);
            }
            else
            {
                startDate = new DateTime(2020, 1, 1);
                endDate = date.AddDays(1);
            }
        }
    }
}
