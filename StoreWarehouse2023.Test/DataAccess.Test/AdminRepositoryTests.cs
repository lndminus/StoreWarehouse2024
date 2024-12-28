using DataAccess.DataContext;
using DataAccess.Entities;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace StoreWarehouse2023.Test.DataAccess.Test
{
    [TestFixture]
    public class AdminRepositoryTests
    {
        private AdminRepository adminRepository;

        private WarehouseDataContext context;


        [OneTimeSetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<WarehouseDataContext>().UseInMemoryDatabase("DbContext").Options;
            context = new WarehouseDataContext(options);
            context.Database.EnsureCreated();

            adminRepository = new AdminRepository(context);
        }

        [Test]
        public void Get_WhenAdminWithNameAdminName1Added_ThenItReturns()
        {
            var admin = new Admin { LastName = "AdminLastName1", Name = "AdminName1", Login = "Login1", Password = "Password1" };
            this.context.Admins.Add(admin);
            this.context.SaveChanges();

            var actual = this.adminRepository.Get(1);

            Assert.AreEqual(admin.Name, actual.Name);
        }

        [Test]
        public void GetAll_WhenAdded2Admins_ThenCountIs2()
        {
            var admin = new Admin { LastName = "AdminLastName1", Name = "AdminName1", Login = "Login1", Password = "Password1" };
            this.context.Admins.Add(admin);
            this.context.SaveChanges();

            var actual = this.adminRepository.GetAll();


            Assert.AreEqual(this.context.Admins.Count(), actual.Count());
        }

        [Test]
        public void Create_WhenAdminWithNameAdminName1Created_ThenItReturns()
        {
            var admin = new Admin { LastName = "AdminLastName1", Name = "AdminName1", Login = "Login1", Password = "Password1" };
            this.adminRepository.Create(admin);
            this.context.SaveChanges();

            var actual = this.context.Admins.FirstOrDefault(x => x.Id == admin.Id);


            Assert.AreEqual(admin.Name, actual.Name);
        }

        [Test]
        public void Update_WhenAdminWithNameAdminName1ChangeToName2_ThenItReturnsWithNameName2()
        {
            var admin = new Admin { LastName = "AdminLastName1", Name = "AdminName1", Login = "Login1", Password = "Password1" };
            this.context.Admins.Add(admin);
            this.context.SaveChanges();

            var admin2 = this.context.Admins.FirstOrDefault(x => x.Id == admin.Id);
            admin2.Name = "Name2";
            this.adminRepository.Update(admin2);
            this.context.SaveChanges();


            var actual = this.context.Admins.FirstOrDefault(x => x.Id == admin.Id);


            Assert.AreEqual(admin2.Name, actual.Name);
        }

        [Test]
        public void Delete_WhenAdminWithId5Delete_ThenItReturnNull()
        {
            var admin = new Admin { LastName = "AdminLastName1", Name = "AdminName1", Login = "Login1", Password = "Password1" };
            this.context.Admins.Add(admin);
            this.context.SaveChanges();

            this.adminRepository.Delete(admin.Id);
            this.context.SaveChanges();

            var actual = this.context.Admins.FirstOrDefault(x => x.Id == admin.Id);


            Assert.IsNull(actual);
        }


        [OneTimeTearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
        }
    }
}
