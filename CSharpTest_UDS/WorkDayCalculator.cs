using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            DateTime tempDate = startDate;
            short i = 0, days = 0;

            do
            {
                tempDate = startDate.AddDays(days);
                if (!WeekEnd.isDayInWeekend(tempDate, weekEnds)) i++;
                days++;
            } while (i < dayCount);

            return tempDate;

            throw new NotImplementedException();
        }
    }
}
