using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTO
{
    public class DBTableDTO
    {
        public string Name { get; set; }

        public List<DBTableColumnDTO> Columns { get; set; }

        public DBTableDTO(string name)
        {
            this.Name = name;
            this.Columns = new List<DBTableColumnDTO>();
        }
    }
}
