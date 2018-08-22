using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

// при тестах допускается что значения day, month, year у объекта Calendar имеют тип Integer (т.е. там может быть только целое число, и значение не может быть null). 

namespace CalendarLib
{
    public class CalendarTest
    {
        private readonly CalendarService _calendarService;

        private readonly int[] _31DayMonths = new int[] { 1, 3, 5, 7, 8, 10, 12 };
        private readonly int[] _30DayMonths = new int[] { 4, 6, 9, 11};

        public CalendarTest()
        {
            _calendarService = new CalendarService();
        }
        
        [Fact]
        public void CalendarTestCase()
        {
            var result = _calendarService.GetRandomCalendar();            
            IsValidCalendarDate(result);
        }

        [Theory]        
        [InlineData(4, 6, 1954)]
        [InlineData(1, 1, 1582)]
        [InlineData(31, 1, 2015)]
        [InlineData(31, 12, 1999)]
        [InlineData(30, 4, 2013)]
        [InlineData(29, 2, 2000)]
        [InlineData(29, 2, 1600)]                
        [InlineData(28, 2, 1800)]
        [InlineData(28, 2, 1900)]
        //tests below will fail
        [InlineData(29, 2, 1700)]
        [InlineData(14, 4, 1452)]
        [InlineData(31, 4, 2540)]
        [InlineData(14, -1, 4321)]
        public void CalendarDataDrivenTestCase(int day, int month, int year)
        {
            var result = new Calendar(day, month, year);
            IsValidCalendarDate(result);
        }

        private void IsValidCalendarDate(Object result)
        {
            Assert.IsType<Calendar>(result);            

            var year = ((Calendar)result).get_year();
            var month = ((Calendar)result).get_month();
            var day = ((Calendar)result).get_day();

            Assert.IsType<int>(year);
            Assert.IsType<int>(month);
            Assert.IsType<int>(day);

            Assert.True(year >= 1582, $"{year} year less then gregorian calendar start date");
            Assert.True(month > 0 && month <= 12, $"month should be between 1 and 12, actual value -> {month}");

            if (_31DayMonths.Contains(month))
            {
                Assert.True(day > 0 && day <= 31, $"day of {month} month should be between 1 and 31, actual value -> {day}");
            }
            else if (_30DayMonths.Contains(month))
            {
                Assert.True(day > 0 && day <= 30, $"day of {month} month should be between 1 and 30, actual value -> {day}");
            }
            else if (month.Equals(2))
            {
                if (IsLeapYear(year))
                {
                    Assert.True(day > 0 && day <= 29, $"day in february of {year} leap year should be between 1 and 29, actual value -> {day}");
                }
                else
                {
                    Assert.True(day > 0 && day <= 28, $"{day} day in february of {year} year should be between 1 and 28, actual value -> {day}");
                }
            }
          
        }

        private bool IsLeapYear(int year)
        {
            if (year % 400 == 0)
            {
                return true;
            }
            else if (year % 100 == 0)
            {
                return false;
            }
            else if (year % 4 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
            
    }
}
