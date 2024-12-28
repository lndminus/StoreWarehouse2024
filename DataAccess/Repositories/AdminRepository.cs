using DataAccess.DataContext;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class AdminRepository : IRepository<Admin>
    {
        private WarehouseDataContext db;

        public AdminRepository(WarehouseDataContext context)
        {
            this.db = context;
        }

        public IEnumerable<Admin> GetAll()
        {
            return db.Admins;
        }

        public Admin Get(int id)
        {
            return db.Admins.Find(id);
        }

        public void Create(Admin admin)
        {
            db.Admins.Add(admin);
        }

        public void Update(Admin admin)
        {
            db.Entry(admin).State = EntityState.Modified;
        }

        public IEnumerable<Admin> Find(Func<Admin, Boolean> predicate)
        {
            return db.Admins.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Admin admin = db.Admins.Find(id);
            if (admin != null)
                db.Admins.Remove(admin);
        }
    }
}
