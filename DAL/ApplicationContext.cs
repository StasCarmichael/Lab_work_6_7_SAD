using System;
using System.Collections.Generic;
using BLL.Entity;

using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ApplicationContext : DbContext
    {
        private string connectionString;


        public DbSet<AnticafeModel> Anticafes { get; set; }
        public DbSet<RestroomModel> Restrooms { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<ClientModel> Clients { get; set; }


        public ApplicationContext()
        {
            connectionString = "Data Source=appDataBase.sqlite";

            Database.EnsureCreated();
        }
        public ApplicationContext(string connectionString)
        {
            this.connectionString = connectionString;

            Database.EnsureCreated();
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString);
        }
    }
}
