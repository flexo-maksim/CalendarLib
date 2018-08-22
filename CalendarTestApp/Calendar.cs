using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarLib
{
    public class Calendar
    {

        public Calendar(int day, int month, int year)
        {
            _day = day;
            _month = month;
            _year = year;
        }

        private int _day;

        private int _month;

        private int _year;

        public int get_day()
        {
            return _day;
        }

        public int get_month()
        {
            return _month;
        }

        public int get_year()
        {
            return _year;
        }
    }
}
