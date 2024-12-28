using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTO
{
    public class ReportDTO
    {
        public int Id { get; set; }

        public double Price { get; set; }

        public bool IsDelivery { get; set; }

        public DateTime ReportTime { get; set; }

        public double Quantity { get; set; }

        public int UserId { get; set; }

        public UserDTO User { get; set; }

        public int WarehouseItemId { get; set; }

        public WarehouseItemDTO WarehouseItem { get; set; }
    }
}
