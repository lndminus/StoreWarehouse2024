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
    public class UserRepositoryTests
    {
        private UserRepository userRepository;

        private WarehouseDataContext context;


        [OneTimeSetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<WarehouseDataContext>().UseInMemoryDatabase("DbContext").Options;
            context = new WarehouseDataContext(options);
            context.Database.EnsureCreated();

            userRepository = new UserRepository(context);
        }

        [Test]
        public void Get_WhenUserWithNameName1Added_ThenItReturns()
        {
            var user = new User { LastName = "Name1", Name = "Name1", Login = "Login1", Password = "Password1", AdminId = 1, Admin = new Admin { LastName = "AdminLastName1", Name = "AdminName1", Login = "Login1", Password = "Password1" } };
            this.context.Users.Add(user);
            this.context.SaveChanges();

            var actual = this.userRepository.Get(1);

            Assert.AreEqual(user.Name, actual.Name);
        }

        [Test]
        public void GetAll_WhenAdded2Users_ThenCountIs2()
        {
            var admin = new Admin { LastName = "AdminLastName1", Name = "AdminName1", Login = "Login1", Password = "Password1" };
            var user = new User { LastName = "Name1", Name = "Name1", Login = "Login1", Password = "Password1", AdminId = 1, Admin = admin };
            this.context.Users.Add(user);
            this.context.SaveChanges();

            var actual = this.userRepository.GetAll();


            Assert.AreEqual(this.context.Users.Count(), actual.Count());
        }

        [Test]
        public void Create_WhenUserWithNameName1Created_ThenItReturns()
        {
            var admin = new Admin { LastName = "AdminLastName1", Name = "AdminName1", Login = "Login1", Password = "Password1" };
            var user = new User { LastName = "Name1", Name = "Name1", Login = "Login1", Password = "Password1", AdminId = 1, Admin = admin };
            this.userRepository.Create(user);
            this.context.SaveChanges();

            var actual = this.context.Users.FirstOrDefault(x => x.Id == user.Id);


            Assert.AreEqual(user.Name, actual.Name);
        }


        [Test]
        public void Update_WhenUserWithNameName1ChangeToName2_ThenItReturnsWithNameName2()
        {
            var admin = new Admin { LastName = "AdminLastName1", Name = "AdminName1", Login = "Login1", Password = "Password1" };
            var user = new User { LastName = "Name1", Name = "Name1", Login = "Login1", Password = "Password1", AdminId = 1, Admin = admin };
            this.context.Users.Add(user);
            this.context.SaveChanges();

            var user2 = this.context.Users.FirstOrDefault(x => x.Id == user.Id);
            user2.Name = "Name2";
            this.userRepository.Update(user2);
            this.context.SaveChanges();


            var actual = this.context.Users.FirstOrDefault(x => x.Id == user.Id);


            Assert.AreEqual(user2.Name, actual.Name);
        }

        [Test]
        public void Delete_WhenUserWithId5Delete_ThenItReturnNull()
        {
            var user = new User { LastName = "AdminLastName1", Name = "AdminName1", Login = "Login1", Password = "Password1" };
            this.context.Users.Add(user);
            this.context.SaveChanges();

            this.userRepository.Delete(user.Id);
            this.context.SaveChanges();

            var actual = this.context.Users.FirstOrDefault(x => x.Id == user.Id);


            Assert.IsNull(actual);
        }


        [OneTimeTearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
        }
    }
}
