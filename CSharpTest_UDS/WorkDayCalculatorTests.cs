using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    [TestFixture]
    public class WorkDayCalculatorTests
    {

        [Test]
        public void TestNoWeekEnd()
        {
            DateTime startDate = new DateTime(2014, 12, 1);
            int count = 10;

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, null);

            Assert.AreEqual(startDate.AddDays(count-1), result);
        }

        [Test]
        public void TestNormalPath()
        {
            DateTime startDate = new DateTime(2017, 4, 21);
            int count = 5;
            WeekEnd[] weekends = new WeekEnd[1]
            {
                new WeekEnd(new DateTime(2017, 4, 23), new DateTime(2017, 4, 25))
            }; 

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2017, 4, 28)));
        }

        [Test]
        public void TestWeekendAfterEnd()
        {
            DateTime startDate = new DateTime(2017, 4, 21);
            int count = 5;
            WeekEnd[] weekends = new WeekEnd[2]
            {
                new WeekEnd(new DateTime(2017, 4, 23), new DateTime(2017, 4, 25)),
                new WeekEnd(new DateTime(2017, 4, 29), new DateTime(2017, 4, 29))
            };
            
            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2017, 4, 28)));
        }

        [Test]
        public void TestWeekend4()
        {
            DateTime startDate = new DateTime(2017, 4, 24);
            int count = 7;
            WeekEnd[] weekends = new WeekEnd[3]
            {
                new WeekEnd(new DateTime(2017, 4, 23), new DateTime(2017, 4, 25)),
                new WeekEnd(new DateTime(2017, 4, 29), new DateTime(2017, 4, 29)),
                new WeekEnd(new DateTime(2017, 5, 1), new DateTime(2017, 5, 2))
            };

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2017, 5, 5)));
        }
    }
}
