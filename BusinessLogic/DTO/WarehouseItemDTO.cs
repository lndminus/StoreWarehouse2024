﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTO
{
    public class WarehouseItemDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Unit { get; set; }

        public double Price { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public double Quantity { get; set; }
    }
}
