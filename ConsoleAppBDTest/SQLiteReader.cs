
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace ConsoleAppBDTest
{
    public class SQLiteReader
    {
        public string DBName { get; set; }
        public string ConnectionStringFirstPart { get; set; }

        public string ConnectionStringSecondPart { get; set; }

        public string ConnectionString { get; set; }


        public List<Table> Tables { get; set; }
        public SQLiteReader(string dbname)
        {
            this.DBName = dbname;
            this.Tables = new List<Table>();

            this.ConnectionString = $@"Data Source={dbname};Version=3;";


        }

        public void AddTables()
        {
            using (SQLiteConnection connection = new SQLiteConnection(this.ConnectionString))
            {
                connection.Open();

                DataTable tablesSchema = connection.GetSchema("Tables");
                foreach (DataRow row in tablesSchema.Rows)
                {
                    if (!this.CheckTable(this.Tables, (string)row["TABLE_NAME"]))
                    {
                        this.Tables.Add(new Table((string)row["TABLE_NAME"]));
                    }
                }
            }
        }
        public bool AddRows(string tableName)
        {
            if (this.CheckTable(this.Tables, tableName))
            {
                int tableIndex = 0;
                foreach (Table t in this.Tables)
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
                        //string columnName = reader["name"].ToString();
                        //columnNames.Add(columnName);

                        if (!this.CheckTableColumn(this.Tables[tableIndex].Columns, reader["name"].ToString()))
                        {
                            this.Tables[tableIndex].Columns.Add(new TableColumn(reader["name"].ToString()));
                        }
                    }
                    //for (int i = 0; i < reader.FieldCount; i++)
                    //{
                    //    if (!this.CheckTableColumn(this.Tables[tableIndex].Columns, reader.GetName(i)))
                    //    {
                    //        this.Tables[tableIndex].Columns.Add(new TableColumn(reader.GetName(i)));
                    //    }
                    //}

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
                foreach (Table t in this.Tables)
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
                            foreach (TableColumn c in this.Tables[tableIndex].Columns)
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
        private bool CheckTable(List<Table> tables, string tableName)
        {
            foreach (Table t in tables)
            {
                if (t.Name == tableName)
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckTableColumn(List<TableColumn> columns, string columnName)
        {
            foreach (TableColumn c in columns)
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
