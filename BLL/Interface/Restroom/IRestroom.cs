using System;
using System.Collections.Generic;


namespace BLL.Interface
{
    public interface IRestroom : IIdable, IReservable
    {
        string TypeRecreation { get; }

        int WorkOut { get; }
        int WorkUp { get; }


        double PricePerHour { get; }
        bool IsReserve(DateTime date);


        ICollection<ITimeInterval> GetSchedule();
        ICollection<ITimeInterval> GetSchedule(DateTime date);
    }
}
