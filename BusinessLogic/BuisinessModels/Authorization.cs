using BusinessLogic.DTO;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BuisinessModels
{
    public class Authorization
    {
        public bool CanRegisterAdmin(IEnumerable<Admin> admins, IEnumerable<User> users, AdminDTO admin)
        {
            foreach (Admin a in admins)
            {
                if (a.Login == admin.Login && a.Password == admin.Password)
                {
                    return false;
                }
            }
            foreach (User u in users)
            {
                if (u.Login == admin.Login && u.Password == admin.Password)
                {
                    return false;
                }
            }
            return true;
        }
        public bool CanRegisterUser(IEnumerable<Admin> admins, IEnumerable<User> users, UserDTO user)
        {

            foreach (Admin a in admins)
            {
                if (a.Login == user.Login && a.Password == user.Password)
                {
                    return false;
                }
            }
            foreach (User u in users)
            {
                if (u.Login == user.Login && u.Password == user.Password)
                {
                    return false;
                }
            }
            return true;
        }
        public bool LogInAsAdmin(IEnumerable<Admin> admins, AdminDTO admin)
        {
            foreach (Admin a in admins)
            {
                if (a.Login == admin.Login && a.Password == admin.Password)
                {
                    return true;
                }
            }
            return false;
        }
        public bool LogInAsUser(IEnumerable<User> users, UserDTO user)
        {
            foreach (User u in users)
            {
                if (u.Login == user.Login && u.Password == user.Password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
