using System;
using BLL.Interface;

namespace BLL.Entity
{
    public class OrderModel : IIdable
    {
        private OrderModel() { }
        internal OrderModel(double orderAmount, string typeRecreation, DateTime date, int sinceWhen, int toWhen)
        {
            Date = date;
            SinceWhen = sinceWhen;
            ToWhen = toWhen;

            OrderAmount = orderAmount;
            TypeRecreation = typeRecreation;
        }


        public int Id { get; private set; }


        public string TypeRecreation { get; private set; }
        public double OrderAmount { get; private set; }


        public DateTime Date { get; private set; }

        public int SinceWhen { get; private set; }
        public int ToWhen { get; private set; }


        public ITimeInterval GetTimeInterval() { return new TimeInterval(Date, SinceWhen, ToWhen); }


        public int ClientId { get; private set; }

        public int RestroomId { get; private set; }
    }
}
