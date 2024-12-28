using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDBTest
{
    public class DBTable
    {
        public string Name { get; set; }

        public List<DBTableColumn> Columns { get; set; }

        public DBTable(string name)
        {
            this.Name = name;
            this.Columns = new List<DBTableColumn>();
        }
    }
}
