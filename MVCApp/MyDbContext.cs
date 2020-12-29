using MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCApp
{
    public class MyDbContext : DbContext
    {
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<GameModel> Games { get; set; }

        public MyDbContext()
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}