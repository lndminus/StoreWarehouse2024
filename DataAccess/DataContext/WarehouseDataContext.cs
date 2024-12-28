using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DataContext
{
    public class WarehouseDataContext : DbContext
    {
        public DbSet<WarehouseItem> WarehouseItems { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = $@"Server=localhost\SQLEXPRESS;Database=WarehouseDB;Trusted_Connection=True; TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);


        }
        //public WarehouseDataContext(DbContextOptions<WarehouseDataContext> options) : base(options)
        //{

        //}
        public WarehouseDataContext()
        {

        }
    }
}
