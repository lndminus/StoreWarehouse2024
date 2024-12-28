using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //IRepository<SingleItem> SingleItems { get; }
        //IRepository<PackageItem> PackageItems { get; }

        //IRepository<VesselItem> VesselItems { get; }

        IRepository<WarehouseItem> WarehouseItems { get; }
        IRepository<Admin> Admins { get; }

        IRepository<User> Users { get; }

        IRepository<Report> Reports { get; }
        void Save();
    }
}
