﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTO
{
    public class SingleItemDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Unit { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }
    }
}
