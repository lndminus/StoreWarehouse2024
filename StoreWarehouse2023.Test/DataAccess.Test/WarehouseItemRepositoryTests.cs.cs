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
    public class WarehouseItemRepositoryTests
    {
        private WarehouseItemRepository itemrepository;

        private WarehouseDataContext context;


        [OneTimeSetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<WarehouseDataContext>().UseInMemoryDatabase("DbContext").Options;
            context = new WarehouseDataContext(options);
            context.Database.EnsureCreated();

            itemrepository = new WarehouseItemRepository(context);
        }

        [Test]
        public void Get_WhenWarehouseItemWithNameItem1Added_ThenItReturns()
        {
            var item = new WarehouseItem { Name = "Item1", Category = "Category1",  Code ="Code1", Description = "Description1", Unit = "Unit1"};
            this.context.WarehouseItems.Add(item);
            this.context.SaveChanges();

            var actual = this.itemrepository.Get(1);

            Assert.AreEqual(actual.Name, item.Name);
        }


        [Test]
        public void GetAll_WhenAdded2WarehouseItems_ThenCountIs2()
        {
            var item = new WarehouseItem { Name = "Item1", Category = "Category1", Code = "Code1", Description = "Description1", Unit = "Unit1" };
            this.context.WarehouseItems.Add(item);
            this.context.SaveChanges();

            var actual = this.itemrepository.GetAll();


            Assert.AreEqual(this.context.WarehouseItems.Count(), actual.Count());
        }

        [Test]
        public void Create_WhenWarehouseItemWithNameItem1Created_ThenItReturns()
        {
            var item = new WarehouseItem { Name = "Item1", Category = "Category1", Code = "Code1", Description = "Description1", Unit = "Unit1" };
            this.itemrepository.Create(item);
            this.context.SaveChanges();

            var actual = this.context.WarehouseItems.FirstOrDefault(x => x.Id == item.Id);


            Assert.AreEqual(item.Name, actual.Name);
        }

        [Test]
        public void Update_WhenWarehouseItemWithNameItem1ChangeToName2_ThenItReturnsWithNameName2()
        {
            var item = new WarehouseItem { Name = "Item1", Category = "Category1", Code = "Code1", Description = "Description1", Unit = "Unit1" };
            this.context.WarehouseItems.Add(item);
            this.context.SaveChanges();

            var item2 = this.context.WarehouseItems.FirstOrDefault(x => x.Id == item.Id);
            item2.Name = "Name2";
            this.itemrepository.Update(item2);
            this.context.SaveChanges();


            var actual = this.context.WarehouseItems.FirstOrDefault(x => x.Id == item.Id);


            Assert.AreEqual(item2.Name, actual.Name);
        }

        [Test]
        public void Delete_WhenWarehouseItemWithId5Delete_ThenItReturnNull()
        {
            var item = new WarehouseItem { Name = "Item1", Category = "Category1", Code = "Code1", Description = "Description1", Unit = "Unit1" };
            this.context.WarehouseItems.Add(item);
            this.context.SaveChanges();

            this.itemrepository.Delete(item.Id);
            this.context.SaveChanges();

            var actual = this.context.WarehouseItems.FirstOrDefault(x => x.Id == item.Id);


            Assert.IsNull(actual);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
        }
    }
}
