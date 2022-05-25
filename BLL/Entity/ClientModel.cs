using System;
using System.Linq;
using System.Collections.Generic;

using BLL.Interface;

namespace BLL.Entity
{
    public class ClientModel : IIdable
    {
        public ClientModel() { }
        public ClientModel(string name, string surname)
        {
            Name = name;
            Surname = surname;
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


        public ICollection<int> Orders { get; private set; }
    }
}
