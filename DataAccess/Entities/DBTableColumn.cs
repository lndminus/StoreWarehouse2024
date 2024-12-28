using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class DBTableColumn
    {
        public string Name { get; set; }


        public Type ColumnType { get; set; }


        public List<string> ColumnValues = new List<string>();

        public DBTableColumn(string name)
        {
            this.Name = name;
        }
    }
}
