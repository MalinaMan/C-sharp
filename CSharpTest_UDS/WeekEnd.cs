using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class WeekEnd
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public WeekEnd(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        static public bool isDayInWeekend(DateTime tempDate, WeekEnd[] weekEnds)
        {
            bool included = false;
            foreach (WeekEnd day in weekEnds ?? Enumerable.Empty<WeekEnd>())
            {
                if (tempDate >= day.StartDate && tempDate <= day.EndDate)
                {
                    included = true;
                    break;
                }
            }
            return included;
        }
    }
}
