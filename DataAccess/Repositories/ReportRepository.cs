using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.Entities;
using DataAccess.DataContext;

namespace DataAccess.Repositories

{
    public class ReportRepository : IRepository<Report>
    {
        private WarehouseDataContext db;

        public ReportRepository(WarehouseDataContext context)
        {
            this.db = context;
        }
        public ReportRepository()
        {

        }
        public IEnumerable<Report> GetAll()
        {
            return db.Reports.Include(o => o.User);
        }
        public Report Get(int id)
        {
            return db.Reports.Find(id);
        }

        public void Create(Report report)
        {
            db.Reports.Add(report);
        }

        public void Update(Report report)
        {
            db.Entry(report).State = EntityState.Modified;
        }
        public IEnumerable<Report> Find(Func<Report, Boolean> predicate)
        {
            return db.Reports.Include(o => o.User).Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Report report = db.Reports.Find(id);
            if (report != null)
                db.Reports.Remove(report);
        }
    }
}
