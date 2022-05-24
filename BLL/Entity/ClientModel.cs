using System;
using System.Linq;
using System.Collections.Generic;

using BLL.Interface;

namespace BLL.Entity
{
    public class ClientModel : IClient
    {
        public ClientModel(string name, string surname)
        {
            Name = name;
            Surname = surname;

            Orders = new LinkedList<OrderModel>();
        }
        public ClientModel(string name, string surname, double amountOfMoney) : this(name, surname)
        {
            AmountOfMoney = amountOfMoney;
        }


        public int Id { get; private set; }

        public string Name { get; set; }
        public string Surname { get; set; }


        #region Account

        public double AmountOfMoney { get; private set; }
        public void PutMoney(double sum) { AmountOfMoney += sum; }
        public bool WithdrawMoney(double sum)
        {
            if (AmountOfMoney < sum) { return false; }
            else { AmountOfMoney -= sum; return true; }
        }

        #endregion


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


        public ICollection<OrderModel> Orders { get; private set; }
    }
}
