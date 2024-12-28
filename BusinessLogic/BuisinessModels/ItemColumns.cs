using BusinessLogic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BuisinessModels
{
    public class ItemColumns
    {
        public DBTableColumnDTO NameColumn {  get; set; }

        public DBTableColumnDTO CodeColumn { get; set; }

        public DBTableColumnDTO UnitColumn { get; set; }

        public DBTableColumnDTO PriceColumn { get; set; }

        public DBTableColumnDTO CategoryColumn { get; set; }

        public DBTableColumnDTO DescriptionColumn { get; set; }

        public DBTableColumnDTO QuantityColumn { get; set; }
    }
}
