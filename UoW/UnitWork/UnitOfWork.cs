using System;
using BLL.Entity;
using UoW.Repository;
using Microsoft.EntityFrameworkCore;

namespace UoW.UnitWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext dbContext;

        private IRepository<Anticafe> anticafes = null;
        private IRepository<Restroom> restrooms = null;
        private IRepository<Client> clients = null;
        private IRepository<Order> orders = null;


        public UnitOfWork(DbContext dbContext) { this.dbContext = dbContext; }


        public IRepository<Anticafe> Anticafes
        {
            get
            {
                if (anticafes == null)
                    anticafes = new GenericRepository<Anticafe>(dbContext);
                return anticafes;
            }
        }
        public IRepository<Restroom> Restrooms
        {
            get
            {
                if (restrooms == null)
                    restrooms = new GenericRepository<Restroom>(dbContext);
                return restrooms;
            }
        }
        public IRepository<Client> Clients
        {
            get
            {
                if (clients == null)
                    clients = new GenericRepository<Client>(dbContext);
                return clients;
            }
        }
        public IRepository<Order> Orders
        {
            get
            {
                if (orders == null)
                    orders = new GenericRepository<Order>(dbContext);
                return orders;
            }
        }


        public void Save() { dbContext.SaveChanges(); }


        #region IDisposeble

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
                if (disposing)
                    dbContext.Dispose();

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
