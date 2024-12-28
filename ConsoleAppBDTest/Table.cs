using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppBDTest
{
    public class Table
    {
        public string Name { get; set; }

        public List<TableColumn> Columns {get; set;}

        public Table(string name) 
        {
            this.Name = name;
            this.Columns = new List<TableColumn>();
        }

    }
}
