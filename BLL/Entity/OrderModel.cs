using System;
using System.ComponentModel.DataAnnotations;

using BLL.Interface;

namespace BLL.Entity
{
    public class OrderModel : IOrder
    {

        private OrderModel() { }
        internal OrderModel(double orderAmount, string typeRecreation,  DateTime date, int sinceWhen, int toWhen)
        {
            Year = date.Year;
            Month = date.Month;
            Day = date.Day;

            SinceWhen = sinceWhen;
            ToWhen = toWhen;

            OrderAmount = orderAmount;
            TypeRecreation = typeRecreation;
        }


        public int Id { get; private set; }


        public string TypeRecreation { get; private set; }
        public double OrderAmount { get; private set; }


        public int Year { get; private set; }
        public int Month { get; private set; }
        public int Day { get; private set; }

        public int SinceWhen { get; private set; }
        public int ToWhen { get; private set; }


        public ITimeInterval GetTimeInterval()
        {
            return new TimeInterval(Year, Month, Day, SinceWhen, ToWhen);
        }


        public int ClientId { get; private set; }
        public ClientModel Client { get; private set; }


        public int RestroomId { get; private set; }
        public RestroomModel Restroom { get; private set; }
    }
}
