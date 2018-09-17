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
            short i = 2;
            bool success;

            while (i <= dayCount)
            {
                tempDate = tempDate.AddDays(1);
                success = true;
                foreach (WeekEnd day in weekEnds ?? Enumerable.Empty<WeekEnd>())
                {
                    if (tempDate >= day.StartDate && tempDate <= day.EndDate)
                    {
                        success = false;
                        break;
                    }
                }
                if (success)
                    i++;
            }

            return tempDate;

            throw new NotImplementedException();
        }
    }
}
