using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DataContext;
using DataAccess.Entities;
using DataAccess.Interfaces;

namespace DataAccess.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private WarehouseDataContext db;
        private WarehouseItemRepository warehouseItemRepository;

        private AdminRepository adminRepository;
        private UserRepository userRepository;
        private ReportRepository reportRepository;

        public EFUnitOfWork()
        {
            db = new WarehouseDataContext();
        }

        public IRepository<WarehouseItem> WarehouseItems
        {
            get
            {
                if (warehouseItemRepository == null)
                    warehouseItemRepository = new WarehouseItemRepository(db);
                return warehouseItemRepository;
            }
        }

        public IRepository<Admin> Admins
        {
            get
            {
                if (adminRepository == null)
                    adminRepository = new AdminRepository(db);
                return adminRepository;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public IRepository<Report> Reports
        {
            get
            {
                if (reportRepository == null)
                    reportRepository = new ReportRepository(db);
                return reportRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
