using BusinessLogic.DTO;
using BusinessLogic.Services;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace StoreWarehouse2023.Test.BuisnessLogic.Tests
{
    public class ReportServiceTests
    {
        private Mock<IUnitOfWork> mockedUnitOfWork;
        private ReportService service;
        private Mock<IRepository<Report>> mockedReportRepository;
        private WarehouseItem itemS;

        [OneTimeSetUp]
        public void Setup()
        {
            this.mockedUnitOfWork = new Mock<IUnitOfWork>();
            this.mockedReportRepository = new Mock<IRepository<Report>>();
            this.mockedUnitOfWork.Setup(x => x.Reports).Returns(mockedReportRepository.Object);

            this.service = new ReportService();
            this.service.Database = mockedUnitOfWork.Object;
        }

        [Test]
        public void GetAllReports_WhenQuantityIsGreaterThanItemQuantity_RetunsFalse()
        {
            this.service.GetAllReports();

            this.mockedUnitOfWork.Verify(x => x.Reports.GetAll(), Times.Once);
        }

        [Test]
        public void AddReport_WhenAccountNumberIsOne_ReturnsTotalSumOfPersonalAccounts()
        {
            var report = new ReportDTO 
            {
                ReportTime = DateTime.Now,
                Price = 10,
                Quantity = 10,
                IsDelivery = true,
                UserId = 1,
                WarehouseItemId = 1
            };

            this.service.AddReport(report);

            this.mockedUnitOfWork.Verify(x => x.Reports.Create(It.IsAny<Report>()), Times.Once);
        }

        [Test]
        public void DeleteReport_WhenAccountNumberIsOne_ReturnsTotalSumOfPersonalAccounts()
        {
            var reportId = 1;

            this.service.DeleteReport(reportId);

            this.mockedUnitOfWork.Verify(x => x.Reports.Delete(reportId), Times.Once);
        }
    }
}
