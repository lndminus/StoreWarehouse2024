using BusinessLogic.BuisinessModels;
using BusinessLogic.DTO;
using DataAccess.Entities;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class AuthorizationService
    {
        public IUnitOfWork DataBase { get; set; }

        private Authorization Authorization { get; set; }

        public AuthorizationService()
        {
            this.DataBase = new EFUnitOfWork();
            this.Authorization = new Authorization();
        }
        public bool RegisterAdmin(AdminDTO admin)
        {
            if (this.Authorization.CanRegisterAdmin(DataBase.Admins.GetAll(), DataBase.Users.GetAll(), admin))
            {
                this.DataBase.Admins.Create(new Admin{ Name = admin.Name, LastName = admin.LastName, Login = admin.Login, Password = admin.Password });
                this.DataBase.Save();
                return true;
            }
            return false;
        }
        public bool RegisterUser(UserDTO user, AdminDTO admin)
        {
            if (this.Authorization.CanRegisterUser(DataBase.Admins.GetAll(), DataBase.Users.GetAll(), user))
                {
                this.DataBase.Users.Create(new User {Name = user.Name, LastName = user.LastName, Login = user.Login, Password = user.Password, AdminId = admin.Id });
                this.DataBase.Save();
                return true;
        }
            return false;
        }
        public bool LogInAsAdmin(AdminDTO admin)
        {
            foreach (Admin a in DataBase.Admins.GetAll())
            {
                if (a.Login == admin.Login && a.Password == admin.Password)
                {
                    return true;
                }
            }
            return false;
        }

        public AdminDTO GetAuthorizedAdmin(AdminDTO admin)
        {
            foreach (Admin a in this.DataBase.Admins.GetAll())
            {
                if (admin.Login == a.Login && admin.Password == a.Password)
                {
                    return new AdminDTO()
                    {
                        Id = a.Id,
                        Name = a.Name,
                        LastName = a.LastName,
                        Login = a.Login,
                        Password = a.Password
                    };
                }
            }
            return null;
        }
        public bool LogInAsUser(UserDTO user)
        {

            return this.Authorization.LogInAsUser(DataBase.Users.GetAll(), user);
        }

        public UserDTO GetUserByLogin(UserDTO user)
        {
            foreach (User u in this.DataBase.Users.GetAll())
            {
                if (user.Login == u.Login && user.Password == u.Password)
                {
                    return new UserDTO()
                    {
                        Id = u.Id,
                        Name = u.Name,
                        LastName = u.LastName,
                        Login = u.Login,
                        Password = u.Password
                    };
                }
            }
            return null;
        }
        public void Dispose()
        {
            DataBase.Dispose();
        }
    }
}
