using DataAccess.DataContext;
using DataAccess.Entities;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace StoreWarehouse2023.Test.DataAccess.Test
{
    public class ReportRepositoryTests
    {

        private ReportRepository reportRepository;

        private WarehouseDataContext context;


        [OneTimeSetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<WarehouseDataContext>().UseInMemoryDatabase("DbContext").Options;
            context = new WarehouseDataContext(options);
            context.Database.EnsureCreated();

            reportRepository = new ReportRepository(context);
        }

        [Test]
        public void Get_WhenReportWithIsDeliverytrueAdded_ThenItReturns()
        {
            var user = new User { LastName = "AdminLastName1", Name = "AdminName1", Login = "Login1", Password = "Password1" };
            var report = new Report { IsDelivery = true, UserId = 1, User = user };
            this.context.Reports.Add(report);
            this.context.SaveChanges();

            var actual = this.reportRepository.Get(1);

            Assert.AreEqual(report.IsDelivery, actual.IsDelivery);
        }

        [Test]
        public void GetAll_WhenAdded2Reports_ThenCountIs2()
        {
            var user = new User { LastName = "AdminLastName1", Name = "AdminName1", Login = "Login1", Password = "Password1"};
            var report = new Report { IsDelivery = true, UserId = 1, User = user };
            this.context.Reports.Add(report);
            this.context.SaveChanges();

            var actual = this.reportRepository.GetAll();

            Assert.AreEqual(this.context.Reports.Count(), actual.Count());
        }


        [Test]
        public void Create_WhenReportWithIsDeliverytrueCreated_ThenItReturns()
        {
            var report = new Report { IsDelivery = true };
            this.reportRepository.Create(report);
            this.context.SaveChanges();

            var actual = this.context.Reports.FirstOrDefault(x => x.Id == report.Id);


            Assert.AreEqual(report.Id, report.Id);
        }

        [Test]
        public void Update_WhenReportWithIsDeliveryfalseChangeTotrue_ThenItReturnsWithIsDeliverytrue()
        {
            var report = new Report { IsDelivery = false };
            this.context.Reports.Add(report);
            this.context.SaveChanges();

            var report2 = this.context.Reports.FirstOrDefault(x => x.Id == report.Id);
            report2.IsDelivery = true;
            this.reportRepository.Update(report2);
            this.context.SaveChanges();


            var actual = this.context.Reports.FirstOrDefault(x => x.Id == report.Id);


            Assert.AreEqual(report2.IsDelivery, actual.IsDelivery);
        }

        [Test]
        public void Delete_WhenReportWithId5Delete_ThenItReturnNull()
        {
            var user = new User { LastName = "AdminLastName1", Name = "AdminName1", Login = "Login1", Password = "Password1", AdminId = 1, Admin = new Admin { LastName = "AdminLastName1", Name = "AdminName1", Login = "Login1", Password = "Password1" } };
            var report = new Report { IsDelivery = false , UserId = 1, User = user};
            this.context.Reports.Add(report);
            this.context.SaveChanges();

            this.reportRepository.Delete(report.Id);
            this.context.SaveChanges();

            var actual = this.context.Reports.FirstOrDefault(x => x.Id == report.Id);


            Assert.IsNull(actual);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
        }
    }
}
