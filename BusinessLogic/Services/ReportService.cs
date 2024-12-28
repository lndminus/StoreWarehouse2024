using BusinessLogic.DTO;
using DataAccess.Entities;
using DataAccess.Interfaces;
using DataAccess.ReportGenerator;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ReportService
    {
        public IUnitOfWork Database { get; set; }

        public ReportService()
        {
            this.Database = new EFUnitOfWork();
        }
        public bool AddReport(ReportDTO report)
        {
            this.Database.Reports.Create(new Report
            {
                ReportTime = report.ReportTime,
                Price = report.Price,
                Quantity = report.Quantity,
                IsDelivery = report.IsDelivery,
                UserId = report.UserId,
                WarehouseItemId = report.WarehouseItemId
            });
            this.Database.Save();
            return true;
        }

        public List<ReportDTO> GetAllReports()
        {
            List<ReportDTO> reports = new List<ReportDTO>();
            foreach (Report report in Database.Reports.GetAll())
            {
                reports.Add(new ReportDTO()
                {
                    Id = report.Id,
                    ReportTime = report.ReportTime,
                    Price = report.Price,
                    Quantity = report.Quantity,
                    IsDelivery = report.IsDelivery,
                    UserId = report.UserId,
                    WarehouseItemId = report.WarehouseItemId
                });
            }
            return reports;
        }

        public bool GenerateReport(ReportDTO report)
        {
            ReportGenerator generator = new ReportGenerator();
            return generator.GenerateReport(new Report
            {
                ReportTime = report.ReportTime,
                Price = report.Price,
                Quantity = report.Quantity,
                IsDelivery = report.IsDelivery,
                User = Database.Users.Get(report.UserId),
                WarehouseItem = Database.WarehouseItems.Get(report.WarehouseItemId)
            }, @"C:\WordReports\");

        }

        public bool DeleteReport(int id)
        {
            this.Database.Reports.Delete(id);
            this.Database.Save();
            return true;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
