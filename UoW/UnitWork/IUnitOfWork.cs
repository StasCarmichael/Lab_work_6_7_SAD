using System;
using BLL.Entity;
using UoW.Repository;

namespace UoW.UnitWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Anticafe> Anticafes { get; }
        IRepository<Restroom> Restrooms { get; }
        IRepository<Client> Clients { get; }
        IRepository<Order> Orders { get; }


        void Save();
    }
}
