using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.IO;


namespace ConsoleAppBDTest
{
    public class ExcelReader
    {
        public List<Table> Tables { get; set; }

        public ExcelReader() 
        {
            this.Tables = new List<Table>();
        }


        public bool CheckDB(string excelFilePath)
        {
            //string excelFilePath = "путь_к_вашему_файлу.xlsx";

            if (File.Exists(excelFilePath))
            {
                using (var package = new ExcelPackage(new FileInfo(excelFilePath)))
                {
                    // Ваш код для обработки файла Excel
                }
                Console.WriteLine("Файл Excel найден.");
                return true;
            }
            else
            {
                // Обработка случая, когда файл не существует
                Console.WriteLine("Файл Excel не найден.");
                return false;
            }
        }

        public bool AddValuesToTable(int rowc, int colc, int rowo, int colo)
        {
            string excelFilePath = "C:\\ExcelDB\\ExcelDB.xlsx";

            // Открываем файл Excel
            //string excelFilePath = "путь_к_вашему_файлу.xlsx";

            using (var package = new ExcelPackage(new FileInfo(excelFilePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                int rowCount = rowc;
                int colCount = colc;

                for (int col = colo; col <= colCount + colo - 1; col++)
                {

                    for (int row = rowo; row <= rowCount + rowo; row++)
                    {

                        object cellValue = worksheet.Cells[row, col].Value;
                        Console.WriteLine(cellValue);
                        if (cellValue == null)
                        {
                            Console.WriteLine("");
                        }
                        if (cellValue != null)
                        {
                            Type cellType = cellValue.GetType();
                            Console.WriteLine(cellType);
                            // Делайте что-то с cellValue и cellType
                        }
                        // Делайте что-то с cellValue
                    }
                }
            }



            return true;
        }
    }
}
