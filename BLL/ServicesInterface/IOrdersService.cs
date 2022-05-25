using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Entity;

namespace BLL.ServicesInterface
{
    public interface IOrdersService
    {
        public OrderModel ReserveSpecialProgramRestroom(int restroomId, int clientId, string namePersonalProgram, DateTime dateTime);
        public OrderModel ReserveRestroom(int restroomId, int clientId, DateTime dateTime, int workOut, int workUp);
        public void UnreserveRestroom(int orderId);
        public OrderModel GetOrder(int orderId);
        public IEnumerable<OrderModel> GetOrder();
    }
}
