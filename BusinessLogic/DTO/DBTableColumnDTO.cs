using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTO
{
    public class DBTableColumnDTO
    {
        public string Name { get; set; }


        public Type ColumnType { get; set; }


        public List<string> ColumnValues { get; set; }

        public DBTableColumnDTO(string name)
        {
            this.ColumnValues = new List<string>();
            this.Name = name;
        }
    }
}
