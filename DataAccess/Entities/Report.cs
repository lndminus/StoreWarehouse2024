using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Report
    {
        public int Id { get; set; } 

        public double Price { get; set; }

        public bool IsDelivery { get; set; }

        public DateTime ReportTime { get; set; }

        public double Quantity { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }

        public WarehouseItem WarehouseItem { get; set; }

        public int WarehouseItemId { get; set; }

    }
}
