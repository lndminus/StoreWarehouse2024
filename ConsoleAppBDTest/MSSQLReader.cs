
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SQLite;
//using Microsoft.Data.SqlClient;

namespace ConsoleAppBDTest
{
    public class MSSQLReader
    {
        //public string DBName { get; set; }
        //public string ConnectionStringFirstPart { get; set; }

        //public string ConnectionStringSecondPart { get; set; }

        //public string ConnectionString { get; set; }


        //public List<Table> Tables { get; set; }
        //public MSSQLReader(string dbname)
        //{
        //    this.DBName = dbname;
        //    this.Tables = new List<Table>();

        //    this.ConnectionString = $@"Data Source=.;Initial Catalog=" + dbname + ";Integrated Security=True; TrustServerCertificate=True";


        //}

        //public void AddTables()
        //{
        //    using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        //    {
        //        connection.Open();

        //        DataTable tablesSchema = connection.GetSchema("Tables");
        //        foreach (DataRow row in tablesSchema.Rows)
        //        {
        //            if (!this.CheckTable(this.Tables, (string)row["TABLE_NAME"]))
        //            {
        //                this.Tables.Add(new Table((string)row["TABLE_NAME"]));
        //            }
        //        }
        //    }
        //}
        //public bool AddRows(string tableName)
        //{
        //    if (this.CheckTable(this.Tables, tableName))
        //    {
        //        int tableIndex = 0;
        //        foreach (Table t in this.Tables)
        //        {
        //            if (t.Name == tableName)
        //            {
        //                tableIndex = this.Tables.IndexOf(t);
        //            }
        //        }

        //        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        //        {
        //            connection.Open();
        //            SqlCommand command = new SqlCommand($"SELECT TOP 0 * FROM {tableName}", connection);
        //            SqlDataReader reader = command.ExecuteReader();

        //            for (int i = 0; i < reader.FieldCount; i++)
        //            {
        //                if (!this.CheckTableColumn(this.Tables[tableIndex].Columns, reader.GetName(i)))
        //                {
        //                    this.Tables[tableIndex].Columns.Add(new TableColumn(reader.GetName(i)));
        //                }
        //            }

        //            reader.Close();
        //        }
        //        return true;
        //    }
        //    return false;
        //}
        //public bool AddValuesToTable(string tableName)
        //{
        //    if (this.CheckTable(this.Tables, tableName))
        //    {
        //        int tableIndex = 0;
        //        foreach (Table t in this.Tables)
        //        {
        //            if (t.Name == tableName)
        //            {
        //                tableIndex = this.Tables.IndexOf(t);
        //            }
        //        }

        //        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        //        {
        //            connection.Open();
        //            SqlCommand command = new SqlCommand($"SELECT * FROM {tableName}", connection);
        //            SqlDataReader reader = command.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                for (int i = 0; i < reader.FieldCount; i++)
        //                {
        //                    foreach (TableColumn c in this.Tables[tableIndex].Columns)
        //                    {
        //                        if (c.Name == reader.GetName(i))
        //                        {
        //                            this.Tables[tableIndex].Columns[this.Tables[tableIndex].Columns.IndexOf(c)].ColumnValues.Add(reader.GetValue(i).ToString());
        //                            this.Tables[tableIndex].Columns[this.Tables[tableIndex].Columns.IndexOf(c)].ColumnType = reader.GetValue(i).GetType();
        //                        }
        //                    }
        //                }
        //            }

        //            reader.Close();
        //        }
        //        return true;

        //    }
        //    return false;
        //}
        //private bool CheckTable(List<Table> tables, string tableName)
        //{
        //    foreach (Table t in tables)
        //    {
        //        if (t.Name == tableName)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        //private bool CheckTableColumn(List<TableColumn> columns, string columnName)
        //{
        //    foreach (TableColumn c in columns)
        //    {
        //        if (c.Name == columnName)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}


























































        //public string DBName { get; set; }
        //public string ConnectionStringFirstPart { get; set; }

        //public string ConnectionStringSecondPart { get; set; }



        //public List<Table> Tables = new List<Table>();
        //public MSSQLReader(string dbname) 
        //{
        //    this.DBName = dbname;
        //    this.ConnectionStringFirstPart = $@"Data Source=.;Initial Catalog=";
        //    this.ConnectionStringSecondPart = ";Integrated Security=True; TrustServerCertificate=True";
        //}

        //public void GetTables()
        //{
        //    string connectionString = this.ConnectionStringFirstPart + this.DBName + this.ConnectionStringSecondPart;
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        DataTable tablesSchema = connection.GetSchema("Tables");
        //        foreach (DataRow row in tablesSchema.Rows)
        //        {
        //            string tableName = (string)row["TABLE_NAME"];
        //            Console.WriteLine(tableName);
        //        }
        //    }
        //}
        //public void GetRows() 
        //{
        //    string connectionString = this.ConnectionStringFirstPart + this.DBName + this.ConnectionStringSecondPart;
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        string tableName = "SomeItems";
        //        SqlCommand command = new SqlCommand($"SELECT TOP 0 * FROM {tableName}", connection);
        //        SqlDataReader reader = command.ExecuteReader();

        //        for (int i = 0; i < reader.FieldCount; i++)
        //        {
        //            string columnName = reader.GetName(i);
        //            Console.WriteLine(columnName);
        //        }

        //        reader.Close();
        //    }
        //}
        //public void GetData()
        //{

        //    string connectionString = this.ConnectionStringFirstPart + this.DBName + this.ConnectionStringSecondPart;
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        string tableName = "SomeItems"; // Имя таблицы
        //        SqlCommand command = new SqlCommand($"SELECT * FROM {tableName}", connection);
        //        SqlDataReader reader = command.ExecuteReader();
        //        //this.Tables.Add(new Table(tableName));
        //        //object co = reader.GetValue(0);
        //        //this.Tables[0].Columns.Add(new TableColumn(reader.GetName(0), co.GetType()));
        //        while (reader.Read()) // Чтение всех строк
        //        {
        //            if (this.GetT(tableName) == -1)
        //            {
        //                this.Tables.Add(new Table(tableName));
        //            }

        //            //object co = reader.GetValue(0);
        //            //this.Tables[0].Columns.Add(new TableColumn(reader.GetName(0), co.GetType()));
        //            for (int i = 0; i < reader.FieldCount; i++) // Перебор столбцов
        //            {
        //                if (this.Tables[0].Columns.Count() == i)
        //                {
        //                    object cValue = reader.GetValue(i);
        //                    this.Tables[0].Columns.Add(new TableColumn(reader.GetName(i), cValue.GetType()));
        //                }
        //                this.Tables[0].Columns[i].ColumnValues.Add(reader.GetValue(i).ToString());
        //                //string columnName = reader.GetName(i);
        //                //object columnValue = reader.GetValue(i);
        //                //this.Tables[this.GetT(tableName)].Columns[0].ColumnValues.Add(columnValue.ToString());
        //                //this.gg.Add(columnValue.ToString());
        //                //Console.WriteLine($"{columnName}: {columnValue}");
        //            }
        //            //Console.WriteLine(); // Пустая строка между записями
        //        }

        //        reader.Close();
        //    }
        //}

        //public int GetT(string name)
        //{
        //    foreach (Table t in this.Tables)
        //    {
        //        if(t.Name == name)
        //        {
        //            return this.Tables.IndexOf(t);
        //        }
        //    }
        //    return -1;
        //}

    }
}
