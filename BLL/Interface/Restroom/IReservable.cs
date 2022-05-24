using System;
using BLL.Entity;

namespace BLL.Interface
{
    public interface IReservable
    {
        (bool result, OrderModel order) ReserveSpecialProgramRestroom(IClient client, string namePersonalProgram, DateTime dateTime);


        (bool result, OrderModel order) ReserveRestroom(IClient client, DateTime dateTime, int workOut, int workUp);
        bool UnreserveRestroom(int orderId);
    }
}
