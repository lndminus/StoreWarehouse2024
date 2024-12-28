using System.Data;
using System.Data.SQLite;
using DataAccess.Entities;
using DataAccess.Interfaces;
using DocumentFormat.OpenXml.Wordprocessing;

namespace DataAccess.DBReaders
{
    public class SQLiteReader : IDBReader
    {
        public string DBName { get; set; }
        public string ConnectionStringFirstPart { get; set; }

        public string ConnectionStringSecondPart { get; set; }

        public string ConnectionString { get; set; }

        public List<DBTable> Tables { get; set; }
        public SQLiteReader(string dbname)
        {
            this.DBName = dbname;
            this.Tables = new List<DBTable>();
            this.ConnectionString = $@"Data Source={dbname};Version=3;";
            //this.ConnectionString = "C:\\SQLiteDb\\TestSQLiteDB.db";
        }

        public bool CheckConnection()
        {
            using (SQLiteConnection connection = new SQLiteConnection(this.ConnectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SQLiteException)
                {
                    return false;
                }
            }
        }

        public bool ReadAllData()
        {
            this.AddTables();
            if (this.Tables.Count > 0)
            {
                foreach (DBTable table in this.Tables)
            {
                this.AddRows(table.Name);
            }
            foreach (DBTable table in this.Tables)
            {
                this.AddValuesToTable(table.Name);
            }
            return true;

        }
            else
            {
                return false;
            }
        }

        public List<DBTable> GetAllTables()
        {
            return this.Tables;
        }

        private void AddTables()
        {
            using (SQLiteConnection connection = new SQLiteConnection(this.ConnectionString))
            {
                connection.Open();

                DataTable tablesSchema = connection.GetSchema("Tables");
                foreach (DataRow row in tablesSchema.Rows)
                {
                    if (!this.CheckTable(this.Tables, (string)row["TABLE_NAME"]))
                    {
                        this.Tables.Add(new DBTable((string)row["TABLE_NAME"]));
                    }
                }
            }
        }
        private bool AddRows(string tableName)
        {
            if (this.CheckTable(this.Tables, tableName))
            {
                int tableIndex = 0;
                foreach (DBTable t in this.Tables)
                {
                    if (t.Name == tableName)
                    {
                        tableIndex = this.Tables.IndexOf(t);
                    }
                }

                using (SQLiteConnection connection = new SQLiteConnection(this.ConnectionString))
                {
                    connection.Open();
                    SQLiteCommand command = new SQLiteCommand($"PRAGMA table_info({tableName})", connection);
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        if (!this.CheckTableColumn(this.Tables[tableIndex].Columns, reader["name"].ToString()))
                        {
                            this.Tables[tableIndex].Columns.Add(new DBTableColumn(reader["name"].ToString()));
                        }
                    }


                    reader.Close();
                }
                return true;
            }
            return false;
        }
        private bool AddValuesToTable(string tableName)
        {
            if (this.CheckTable(this.Tables, tableName))
            {
                int tableIndex = 0;
                foreach (DBTable t in this.Tables)
                {
                    if (t.Name == tableName)
                    {
                        tableIndex = this.Tables.IndexOf(t);
                    }
                }

                using (SQLiteConnection connection = new SQLiteConnection(this.ConnectionString))
                {
                    connection.Open();
                    SQLiteCommand command = new SQLiteCommand($"SELECT * FROM {tableName}", connection);
                    SQLiteDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            foreach (DBTableColumn c in this.Tables[tableIndex].Columns)
                            {
                                if (c.Name == reader.GetName(i))
                                {
                                    this.Tables[tableIndex].Columns[this.Tables[tableIndex].Columns.IndexOf(c)].ColumnValues.Add(reader.GetValue(i).ToString());
                                    this.Tables[tableIndex].Columns[this.Tables[tableIndex].Columns.IndexOf(c)].ColumnType = reader.GetValue(i).GetType();
                                }
                            }
                        }
                    }

                    reader.Close();
                }
                return true;

            }
            return false;
        }
        private bool CheckTable(List<DBTable> tables, string tableName)
        {
            foreach (DBTable t in tables)
            {
                if (t.Name == tableName)
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckTableColumn(List<DBTableColumn> columns, string columnName)
        {
            foreach (DBTableColumn c in columns)
            {
                if (c.Name == columnName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
