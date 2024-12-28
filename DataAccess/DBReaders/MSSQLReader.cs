using Microsoft.Data.SqlClient;
using System.Data;
using DataAccess.Entities;
using DataAccess.Interfaces;

namespace DataAccess.DBReaders
{
    public class MSSQLReader : IDBReader
    {
        public string DBName { get; set; }
        public string ConnectionStringFirstPart { get; set; }

        public string ConnectionStringSecondPart { get; set; }

        public string ConnectionString { get; set; }


        public List<DBTable> Tables {get; set; }
        public MSSQLReader(string dbname)
        {
            this.DBName = dbname;
            this.Tables = new List<DBTable>();
            this.ConnectionString = $@"Data Source=localhost\SQLEXPRESS;Initial Catalog=" + dbname + ";Integrated Security=True; TrustServerCertificate=True";
        }
        public bool CheckConnection()
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException)
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
                    this.AddRowsToTable(table.Name);
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

        public void AddTables()
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
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
        public bool AddRowsToTable(string tableName)
        {
            if (this.CheckTable(this.Tables, tableName)) 
            {
                int tableIndex = 0;
                foreach (DBTable t in this.Tables)
                {
                    if(t.Name == tableName)
                    {
                        tableIndex = this.Tables.IndexOf(t);
                    }
                }

                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand($"SELECT TOP 0 * FROM {tableName}", connection);
                    SqlDataReader reader = command.ExecuteReader();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if (!this.CheckTableColumn(this.Tables[tableIndex].Columns, reader.GetName(i)))
                        {
                            this.Tables[tableIndex].Columns.Add(new DBTableColumn(reader.GetName(i)));
                        }
                    }

                    reader.Close();
                }
                return true;
            }
            return false;
        }
        public bool AddValuesToTable(string tableName)
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

                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand($"SELECT * FROM {tableName}", connection);
                    SqlDataReader reader = command.ExecuteReader();

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
            foreach(DBTable t in tables)
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
