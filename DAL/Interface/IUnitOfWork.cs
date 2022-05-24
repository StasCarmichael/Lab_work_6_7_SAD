using System;
using DAL.Entity;

namespace DAL.Interface
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
