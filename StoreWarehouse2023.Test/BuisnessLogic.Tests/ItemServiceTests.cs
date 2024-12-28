using BusinessLogic.DTO;
using BusinessLogic.Services;
using DataAccess.DataContext;
using DataAccess.Entities;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace StoreWarehouse2023.Test.BuisnessLogic.Tests
{
    public class ItemServiceTests
    {
        private Mock<IUnitOfWork> mockedUnitOfWork;
        private ItemService service;
        private Mock<IRepository<WarehouseItem>> mockedWarehouseItemRepository;
        private Mock<IRepository<Report>> mockedReportRepository;
        private WarehouseItem itemS;
        [OneTimeSetUp]
        public void Setup()
        {
            //var context = new Mock<WarehouseDataContext>();

            this.mockedUnitOfWork = new Mock<IUnitOfWork>();

            this.mockedWarehouseItemRepository = new Mock<IRepository<WarehouseItem>>();
            //this.mockedWarehouseItemRepository.Setup(x => x.db).Returns(context.Object);

            this.mockedReportRepository = new Mock<IRepository<Report>>();
            //this.mockedReportRepository.Setup(x => x.db).Returns(context.Object);


            this.mockedUnitOfWork.Setup(x => x.WarehouseItems).Returns(mockedWarehouseItemRepository.Object);
            //List<WarehouseItem> warehouseItems = new List<WarehouseItem>();
            //warehouseItems.Add(new WarehouseItem { Id = 1, Name = "Item1" , Quantity = 10, Price = 100});
            int s = 1;
            this.itemS = new WarehouseItem { Id = 1, Name = "Item1", Quantity = 10, Price = 100 };

            this.mockedUnitOfWork.Setup(x => x.WarehouseItems.Get(s)).Returns(this.itemS);
            //this.mockedUnitOfWork.Setup(x => x.WarehouseItems.GetAll()).Returns(warehouseItems);
            this.mockedUnitOfWork.Setup(x => x.Reports).Returns(mockedReportRepository.Object);

            this.service = new ItemService(mockedUnitOfWork.Object);
            //this.service.Database = mockedUnitOfWork.Object;


        }

        [Test]
        public void IncreaseItemQuantity_WhenQuantityIsGreaterThanItemQuantity_RetunsFalse()
        {
            var WarehouseDTO = new WarehouseItemDTO() { Id = 1, Name = "Item1"};
            var UserDTO = new UserDTO() { Id = 1, Name = "UserName" };
            var Quantity = 5;
            this.service.IncreaseItemQuantity(Quantity, WarehouseDTO, UserDTO);
            this.mockedUnitOfWork.Verify(x => x.WarehouseItems.Update(this.itemS), Times.Once);
            this.mockedUnitOfWork.Verify(x => x.Reports.Create(It.IsAny<Report>()), Times.Once);
        }

        [Test]
        public void GetAll_WhenAccountNumberIsOne_ReturnsTotalSumOfPersonalAccounts()
        {
            //double expectedSum = 686;

            //this.mockedUnitOfWork.Setup(x => x.PersonalAccountRepository.GetAll()).ReturnsAsync(666.0);

            //var actual = await this.accountService.GetAll(1);

            //Assert.AreEqual(expectedSum, actual);
        }
    }
}
