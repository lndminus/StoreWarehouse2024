using BusinessLogic.BuisinessModels;
using BusinessLogic.DTO;
using BusinessLogic.Services;
using DataAccess.Entities;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreWarehouse2023.Test.BuisnessLogic.Tests
{
    [TestFixture]
    public class AuthorizationServiceTests
    {
        private DBTableService service;

        [OneTimeSetUp]
        public void Setup()
        {
            this.service = new DBTableService();

        }

        [Test]
        public void GetColumnByName__RetunsColumnWithNameColumnName()
        {
            var columns = new List<DBTableColumnDTO>();
            var columnName = "ColumnName";
            var column = new DBTableColumnDTO(columnName);
            columns.Add(column);

            var actual = this.service.GetColumnByName(columns, columnName);

            Assert.AreEqual(column.Name, actual.Name);

        }

        [Test]
        public void CheckItemsCount_WhenAccountNumberIsOne_ReturnsTotalSumOfPersonalAccounts()
        {
            var ItemColumns = new ItemColumns();
            var columnName = "name";
            var nameColumn = new DBTableColumnDTO(columnName);
            var columnsValues = new List<string>();
            var value1 = "value1";
            var value2 = "value2";
            columnsValues.Add(value1);
            columnsValues.Add(value2);
            nameColumn.ColumnValues = columnsValues;
            ItemColumns.NameColumn = nameColumn;

            var actual = this.service.CheckItemsCount(ItemColumns);

            Assert.AreEqual(columnsValues.Count(), actual);
        }

        [Test]
        public void ConvertTableToItems_WhenAccountNumberIsOne_ReturnsTotalSumOfPersonalAccounts()
        {
            var ItemColumns = new ItemColumns();
            var columnName = "name";
            var nameColumn = new DBTableColumnDTO(columnName);
            var columnsValues = new List<string>();
            var value1 = "value1";
            var value2 = "value2";
            columnsValues.Add(value1);
            columnsValues.Add(value2);
            nameColumn.ColumnValues = columnsValues;
            ItemColumns.NameColumn = nameColumn;

            var actual = this.service.ConvertTableToItems(ItemColumns);

            Assert.AreEqual(columnsValues.Count(), actual.Count());
        }

        [Test]
        public void CheckTypes_WhenAccountNumberIsOne_ReturnsTotalSumOfPersonalAccounts()
        {
            var ItemColumns = new ItemColumns();
            var columnName = "name";
            var nameColumn = new DBTableColumnDTO(columnName);
            nameColumn.ColumnType = typeof(string);
            var columnsValues = new List<string>();
            var value1 = "value1";
            var value2 = "value2";
            columnsValues.Add(value1);
            columnsValues.Add(value2);
            nameColumn.ColumnValues = columnsValues;
            ItemColumns.NameColumn = nameColumn;

            var actual = this.service.CheckTypes(ItemColumns);

            Assert.IsTrue(actual);
        }

        [Test]
        public void f()
        {
            var ItemColumns = new ItemColumns();
            var columnName = "name";
            var nameColumn = new DBTableColumnDTO(columnName);
            var columnsValues = new List<string>();
            var value1 = "value1";
            var value2 = "value2";
            columnsValues.Add(value1);
            columnsValues.Add(value2);
            nameColumn.ColumnValues = columnsValues;
            ItemColumns.NameColumn = nameColumn;

            var actual = this.service.ConvertTableToItems(ItemColumns);

            Assert.AreEqual(columnsValues.Count(), actual.Count());
        }

        [Test]
        public void d()
        {
            var ItemColumns = new ItemColumns();
            var columnName = "name";
            var nameColumn = new DBTableColumnDTO(columnName);
            nameColumn.ColumnType = typeof(string);
            var columnsValues = new List<string>();
            var value1 = "value1";
            var value2 = "value2";
            columnsValues.Add(value1);
            columnsValues.Add(value2);
            nameColumn.ColumnValues = columnsValues;
            ItemColumns.NameColumn = nameColumn;

            var actual = this.service.CheckTypes(ItemColumns);

            Assert.IsTrue(actual);
        }
        //private Mock<IUnitOfWork> mockedUnitOfWork;
        //private AuthorizationService service;
        //private Mock<AdminRepository> mockedAdminRepository;
        //private Mock<UserRepository> mockedUserRepository;

        //[OneTimeSetUp]
        //public void Setup()
        //{
        //    this.mockedUnitOfWork = new Mock<IUnitOfWork>();

        //    this.mockedAdminRepository = new Mock<AdminRepository>();
        //    this.mockedUserRepository = new Mock<UserRepository>();


        //    this.mockedUnitOfWork.Setup(x => x.Admins).Returns(mockedAdminRepository.Object);
        //    List<Admin> users = new List<Admin>();
        //    users.Add(new Admin { Id = 1, Name = "gg" });
        //    this.mockedUnitOfWork.Setup(x => x.Admins.GetAll()).Returns(users);
        //    this.mockedUnitOfWork.Setup(x => x.Users).Returns(mockedUserRepository.Object);

        //    this.service = new AuthorizationService();
        //    this.service.DataBase = mockedUnitOfWork.Object;

        //}

        ////[Test]
        ////public void IncreaseItemQuantity_WhenQuantityIsGreaterThanItemQuantity_RetunsFalse()
        ////{

        ////    this.accountService.TransferFromPersonalToWorkAsync(10, "test");
        ////    this.mockedUnitOfWork.Verify(x => x.PersonalAccountRepository.AddAsync(-10, "test"), Times.Once);
        ////    this.mockedUnitOfWork.Verify(x => x.WorkAccountRepository.AddAsync(10, "test"), Times.Once);
        ////}

        //[Test]
        //public void GetAll_WhenAccountNumberIsOne_ReturnsTotalSumOfPersonalAccounts()
        //{
        //    //double expectedSum = 686;

        //    //this.mockedUnitOfWork.Setup(x => x.PersonalAccountRepository.GetAll()).ReturnsAsync(666.0);

        //    //var actual = await this.accountService.GetAll(1);

        //    //Assert.AreEqual(expectedSum, actual);
        //}


    }
}
