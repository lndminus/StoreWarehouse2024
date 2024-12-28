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
    public class WarehouseItemRepository : IRepository<WarehouseItem>
    {
        public WarehouseDataContext db { get; set; }

        public WarehouseItemRepository(WarehouseDataContext context)
        {
            this.db = context;
        }

        public WarehouseItemRepository()
        {
        }

        public IEnumerable<WarehouseItem> GetAll()
        {
            return db.WarehouseItems;
        }

        public WarehouseItem Get(int id)
        {
            return db.WarehouseItems.Find(id);
        }

        public void Create(WarehouseItem item)
        {
            db.WarehouseItems.Add(item);
        }

        public void Update(WarehouseItem item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<WarehouseItem> Find(Func<WarehouseItem, Boolean> predicate)
        {
            return db.WarehouseItems.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            WarehouseItem item = db.WarehouseItems.Find(id);
            if (item != null)
                db.WarehouseItems.Remove(item);
        }
    }
}
