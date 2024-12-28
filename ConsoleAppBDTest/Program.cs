
using ConsoleAppBDTest;
//using DataAccess.Interfaces;
//using DataAccess.Repositories;
//using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SQLite;

//IUnitOfWork Uw = new EFUnitOfWork();

//var m = Uw.Admins.Get(1);
//----------------------------------------
//var name = "TestDB";
//var connectionString = $@"Data Source=.;Initial Catalog={name};Integrated Security=True; TrustServerCertificate=True";
//--------------------------------------
//using (SqlConnection connection = new SqlConnection(connectionString))
//{
//    connection.Open();

//    // Создание команды для создания таблицы
//    string createTableQuery = "CREATE TABLE SomeItems (Id INT IDENTITY(1,1) PRIMARY KEY, Name NVARCHAR(50))";
//    using (SqlCommand command = new SqlCommand(createTableQuery, connection))
//    {
//        command.ExecuteNonQuery();
//        Console.WriteLine("Таблица 'Users' успешно создана.");
//    }
//}

//using (SqlConnection connection = new SqlConnection(connectionString))
//{
//    connection.Open();

//    DataTable tablesSchema = connection.GetSchema("Tables");
//    foreach (DataRow row in tablesSchema.Rows)
//    {
//        string tableName = (string)row["TABLE_NAME"];
//        Console.WriteLine(tableName);
//    }
//}

//--------------------
//using (SqlConnection connection = new SqlConnection(connectionString))
//{
//    connection.Open();

//    string tableName = "SomeItems"; // Имя таблицы
//    SqlCommand command = new SqlCommand($"SELECT TOP 0 * FROM {tableName}", connection);
//    SqlDataReader reader = command.ExecuteReader();

//    for (int i = 0; i < reader.FieldCount; i++)
//    {
//        string columnName = reader.GetName(i);
//        Console.WriteLine(columnName);
//    }

//    reader.Close();
//}
//----------------
//Console.WriteLine();

//string connectionString = "Data Source=mydb4.db;Version=3;";
//using (SQLiteConnection connection = new SQLiteConnection(connectionString))
//{
//    connection.Open();

//    // Создание таблицы SomeTestItems
//    string createTableQuery = @"CREATE TABLE IF NOT EXISTS SomeTestItems (
//                                        Id INTEGER PRIMARY KEY,
//                                        Name TEXT,
//                                        Quantity REAL
//                                      )";

//    using (SQLiteCommand createTableCommand = new SQLiteCommand(createTableQuery, connection))
//    {
//        createTableCommand.ExecuteNonQuery();
//    }

//    // Вставка данных в таблицу SomeTestItems
//    string insertDataQuery = @"INSERT INTO SomeTestItems (Id, Name, Quantity)
//                                      VALUES (@Id, @Name, @Quantity)";

//    using (SQLiteCommand insertDataCommand = new SQLiteCommand(insertDataQuery, connection))
//    {
//        insertDataCommand.Parameters.AddWithValue("@Id", 1);
//        insertDataCommand.Parameters.AddWithValue("@Name", "Item 1");
//        insertDataCommand.Parameters.AddWithValue("@Quantity", 2.5);

//        insertDataCommand.ExecuteNonQuery();
//    }
//}

//Console.WriteLine("Таблица SomeTestItems создана и заполнена данными.");
//var name = "TestDB";
//var name = "C:\\SQLiteDb\\TestSQLiteDB.db";
////MSSQLReader msreader = new MSSQLReader(name);
//SQLiteReader msreader = new SQLiteReader(name);
//msreader.AddTables();
//msreader.AddRows(msreader.Tables[0].Name);
//msreader.AddValuesToTable(msreader.Tables[0].Name);
//foreach (string s in msreader.Tables[0].Columns[1].ColumnValues)
//{
//    Console.WriteLine(s);
//}
//Console.WriteLine(msreader.Tables[0].Columns[2].ColumnType);
//Console.WriteLine(msreader.Tables[0].Columns.Count());
//Console.WriteLine(msreader.Tables[0].Columns[0].ColumnValues.Count());
//Console.WriteLine("kk");

////Console.OutputEncoding = System.Text.Encoding.UTF8;
//ExcelReader excelReader = new ExcelReader();
////excelReader.CheckDB("C:\\ExcelDB\\ExcelDB.xlsx");
//excelReader.AddValuesToTable(10, 6, 5, 2);
















//string databaseName = "mydatabase.db";

//// Создать подключение к базе данных
//using (SQLiteConnection connection = new SQLiteConnection($"Data Source={databaseName};Version=3;"))
//{
//    // Открыть подключение
//    connection.Open();

//    // Создать таблицу "User"
//    using (SQLiteCommand command = new SQLiteCommand("CREATE TABLE User (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Age INTEGER)", connection))
//    {
//        command.ExecuteNonQuery();
//        Console.WriteLine("Таблица 'User' создана.");
//    }

//    // Закрыть подключение
//    connection.Close();
//}

//Console.WriteLine("Нажмите любую клавишу для выхода.");
//Console.ReadKey();





























//double s = 3;
//int a = 10;
//double r = a / s;

//Console.WriteLine(r);


