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


        public string TypeRecreation { get; set; }
        public double OrderAmount { get; set; }


        public DateTime Date { get; set; }

        public int SinceWhen { get; set; }
        public int ToWhen { get; set; }


        public ITimeInterval GetTimeInterval() { return new TimeInterval(Date, SinceWhen, ToWhen); }


        public int ClientId { get; set; }

        public int RestroomId { get; set; }
    }
}
