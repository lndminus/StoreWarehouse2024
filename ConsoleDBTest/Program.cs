// See https://aka.ms/new-console-template for more information


using ConsoleDBTest;
using System.Security.Cryptography;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using System.Data;
using System.Data.SQLite;
//using Document = DocumentFormat.OpenXml.Wordprocessing.Document;
//using Text = DocumentFormat.OpenXml.Wordprocessing.Text;
//using DocumentFormat.OpenXml.Spreadsheet;

Console.OutputEncoding = System.Text.Encoding.UTF8;

//ExcelReader r = new ExcelReader();
//r.AddValuesToTable(11, 6, 5, 2);
//int n = 3;
//Console.WriteLine(r.Tables[0].Columns[n].Name);
//foreach (string s in r.Tables[0].Columns[n].ColumnValues)
//{
//    Console.WriteLine(s);
//}
//Console.WriteLine(r.Tables[0].Columns[n].ColumnType);
//Console.WriteLine(r.Tables.Count);
//Console.WriteLine(r.Tables[0].Columns.Count);


//string password = "sKzvYk#1Pn33!YN";  // The password to encrypt the data with
//string plaintext = "Top secret data"; // The string to encrypt

//// Encrypt the string
//string ciphertext = Rijndael.Encrypt(plaintext, password, KeySize.Aes256);

//// Decrypt the string
//plaintext = Rijndael.Decrypt(ciphertext, password, KeySize.Aes256);

//PCoder coder = new PCoder();
//string m = "SmileAndBeHappy.";
//string enm = coder.EncryptByKey(m, "SmileAndBeHappy.");
//Console.WriteLine(enm);
//Console.WriteLine(coder.DecryptByKey(enm, "SmileAndBeHappy."));
//string path = @"C:\WordReports\";
//DateTime time = DateTime.Now;
//string formattedDateTime = string.Format("{0:dd.MM.yyyy}{0:-HH.mm.ss}", time);
//string resultPath = path + "Звіт" + formattedDateTime + ".docx";
//using (WordprocessingDocument document = WordprocessingDocument.Create(resultPath, WordprocessingDocumentType.Document))
//{
//    // Создание основного содержимого документа
//    MainDocumentPart mainPart = document.AddMainDocumentPart();
//    mainPart.Document = new Document();

//    // Создание абзаца и добавление текста
//    Paragraph paragraph = new Paragraph();
//    Run row1 = new Run(new Text("Первая строка"));
//    Run break1 = new Run(new Break());
//    Run row2 = new Run(new Text("Вторая строка"));
//    Run row3 = new Run(new Text("Вторая строка"));

//    paragraph.Append(row1, break1, row2, row3);

//    // Добавление абзаца в основное содержимое документа
//    Body body = mainPart.Document.AppendChild(new Body());
//    body.Append(paragraph);

//    // Сохранение документа
//    mainPart.Document.Save();
//}



//var name = "TestDB";
string name = "C:\\SQLiteDb\\TestSQLiteDB.db";
////MSSQLReader msreader = new MSSQLReader(name);
SQLiteReader msreader = new SQLiteReader(name);
msreader.AddTables();
msreader.AddRows(msreader.Tables[0].Name);
msreader.AddValuesToTable(msreader.Tables[0].Name);
foreach (string s in msreader.Tables[0].Columns[1].ColumnValues)
{
    Console.WriteLine(s);
}
Console.WriteLine(msreader.Tables[0].Columns[2].ColumnType);
Console.WriteLine(msreader.Tables[0].Columns.Count());
Console.WriteLine(msreader.Tables[0].Columns[0].ColumnValues.Count());
Console.WriteLine("kk");