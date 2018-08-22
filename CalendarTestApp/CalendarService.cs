using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarLib
{
    public class CalendarService
    {

        public Calendar GetRandomCalendar()
        {
            var rnd = new Random();
            return new Calendar(rnd.Next(0, 40), rnd.Next(0,20), rnd.Next(0, 9999));
        }

    }
}
