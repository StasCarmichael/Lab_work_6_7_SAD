using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.Entity;

namespace BLL.Services
{
    public class ClientService
    {
        public void AddOrder(OrderModel order) { Orders.Add(order); }
        public bool RemoveOrder(OrderModel order) { return Orders.Remove(order); }
        public bool RemoveOrder(int orderId)
        {
            var res = Orders.Where(val => val.Id == orderId).FirstOrDefault();
            if (res != null)
                return Orders.Remove(res);
            else
                return false;
        }
    }
}
