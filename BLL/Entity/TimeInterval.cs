using System;
using BLL.Interface;

namespace BLL.Entity
{
    public class TimeInterval : ITimeInterval
    {
        public TimeInterval(DateTime date, int sinceWhen, int toWhen)
        {
            SinceWhen = sinceWhen;
            ToWhen = toWhen;
            Date = date;
        }

        public int SinceWhen { get; private set; }
        public int ToWhen { get; private set; }
        public DateTime Date { get; private set; }
    }
}
