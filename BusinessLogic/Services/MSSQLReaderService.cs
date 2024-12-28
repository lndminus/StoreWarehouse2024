using BusinessLogic.DTO;
using BusinessLogic.Infrastructure;
using DataAccess.DBReaders;
using DataAccess.Entities;
using DataAccess.Interfaces;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class MSSQLReaderService
    {
        public IDBReader MSSQLDataBase {get; set;}

        public MSSQLReaderService()
        {

        }

        public bool SetDataBase(string DBName)
        {
            this.MSSQLDataBase = new MSSQLReader(DBName);
            if (!this.MSSQLDataBase.CheckConnection())
            {
                return false;
            }
            if (this.MSSQLDataBase.ReadAllData())
            {
                return true;
            }
            return false;
        }

        public List<DBTableDTO> GetTables()
        {
            List<DBTableDTO> tables = new List<DBTableDTO>();
            foreach (DBTable table in this.MSSQLDataBase.GetAllTables())
            {
                DBTableDTO tDTO = new DBTableDTO(table.Name);
                foreach (DBTableColumn column in table.Columns)
                {
                    tDTO.Columns.Add(new DBTableColumnDTO(column.Name) { ColumnType = column.ColumnType, ColumnValues = column.ColumnValues });
                }
                tables.Add(tDTO);
            }
            return tables;
        }

        public DBTableDTO GetTableByName(string name)
        {
            foreach (DBTable t in this.MSSQLDataBase.GetAllTables())
            {
                if (t.Name == name)
                {
                    DBTableDTO tDTO = new DBTableDTO(t.Name);
                    foreach (DBTableColumn column in t.Columns)
                    {
                        tDTO.Columns.Add(new DBTableColumnDTO(column.Name) { ColumnType = column.ColumnType, ColumnValues = column.ColumnValues });
                    }
                    return tDTO;
                }
            }
            throw new BLException("Помилка пошуку таблиці", "");
        }

        public List<string> GetTablesNames()
        {
            List<string> names = new List<string>();
            foreach (DBTable t in this.MSSQLDataBase.GetAllTables())
            {
                names.Add(t.Name);
            }
            return names;
        }
    }
}
