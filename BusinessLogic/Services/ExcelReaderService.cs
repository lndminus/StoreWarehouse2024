using BusinessLogic.DTO;
using DataAccess.DBReaders;
using DataAccess.Entities;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ExcelReaderService
    {
        public IDBReader ExcelDataBase { get; set; }

        public ExcelReaderService()
        {

        }

        public bool CheckConnection(string filePath)
        {
            this.ExcelDataBase = new ExcelReader(filePath);
            if (this.ExcelDataBase.CheckConnection())
            {
                return true;
            }
            return false;
        }

        public bool SetDataBase(string filePath, int rowCount, int colCount, int rowStart, int colStart)
        {
            this.ExcelDataBase = new ExcelReader(filePath, rowCount, colCount, rowStart, colStart);
            if (!this.ExcelDataBase.CheckConnection())
            {
                return false;
            }
            if (this.ExcelDataBase.ReadAllData())
            {
                return true;
            }
            return false;
        }

        public List<DBTableDTO> GetTables()
        {
            List<DBTableDTO> tables = new List<DBTableDTO>();
            foreach (DBTable table in this.ExcelDataBase.GetAllTables())
            {
                DBTableDTO tDTO = new DBTableDTO(table.Name);
                tables.Add(tDTO);
                foreach (DBTableColumn column in table.Columns)
                {
                    tables[tables.IndexOf(tDTO)].Columns.Add(new DBTableColumnDTO(column.Name) { ColumnType = column.ColumnType, ColumnValues = column.ColumnValues });
                }
            }
            return tables;
        }
    }
}
