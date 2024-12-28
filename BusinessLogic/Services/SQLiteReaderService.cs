using BusinessLogic.DTO;
using BusinessLogic.Infrastructure;
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
    public class SQLiteReaderService
    {
        public IDBReader SQLiteDataBase { get; set; }

        public SQLiteReaderService()
        {

        }

        public bool SetDataBase(string DBName)
        {
            this.SQLiteDataBase = new SQLiteReader(DBName);
            if (!this.SQLiteDataBase.CheckConnection())
            {
                return false;
            }
            if (this.SQLiteDataBase.ReadAllData())
            {
                return true;
            }
            return false;
        }

        public List<DBTableDTO> GetTables()
        {
            List<DBTableDTO> tables = new List<DBTableDTO>();
            foreach (DBTable table in this.SQLiteDataBase.GetAllTables())
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

        public DBTableDTO GetTableByName(string name)
        {
            foreach (DBTable t in this.SQLiteDataBase.GetAllTables())
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
            foreach (DBTable t in this.SQLiteDataBase.GetAllTables())
            {
                names.Add(t.Name);
            }
            return names;
        }
    }
}
