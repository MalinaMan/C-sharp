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
            bool success;

            do
            {
                tempDate = startDate.AddDays(days);
                success = true;
                foreach (WeekEnd day in weekEnds ?? Enumerable.Empty<WeekEnd>())
                {
                    if (tempDate >= day.StartDate && tempDate <= day.EndDate)
                    {
                        success = false;
                        break;
                    }
                }
                if (success) i++;
                days++;
            } while (i < dayCount);

            return tempDate;

            throw new NotImplementedException();
        }
    }
}
