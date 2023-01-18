using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Windows_Forms__Last_
{
    class Deadline
    {
        private int _day;
        private int _month;
        private int _year;


        public Deadline(int day, int month, int year)
        {
            this._day = day;
            this._month = month;
            this._year = year;
        }

        

        public string PrtInLine()
        {
            string result = _day + "." + _month + "." + _year;
            return result;
        }

        public int Month
        {
            get { return _month; }
            set { _month = value; }

        }

        public int Day
        {
            get { return _day; }
            set { _day = value; }

        }

        public int Year
        {
            get { return _year; }
            set { _year = value; }

        }
    }
}
