using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System;
using System.IO;
using System.Data.Common;

namespace ConsoleDBTest
{
    public class ExcelReader
    {
        public List<DBTable> Tables { get; set; }

        public ExcelReader()
        {
            this.Tables = new List<DBTable>();
        }

        public bool CheckDB(string excelFilePath)
        {
            if (File.Exists(excelFilePath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddValuesToTable(int rowCount, int colCount, int rowStart, int colStart)
        {
            string excelFilePath = "C:\\ExcelDB\\ExcelDB.xlsx";
            int Worksheet = 0;

            using (var package = new ExcelPackage(new FileInfo(excelFilePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[Worksheet];
                //int rowCount = rowc;
                //int colCount = colc;
                this.Tables.Add(new DBTable(excelFilePath));

                for (int col = colStart; col < colCount + colStart; col++)
                {
                    object cellValue = worksheet.Cells[rowStart, col].Value;
                    if (cellValue != null)
                    {
                        this.Tables[this.Tables.Count() - 1].Columns.Add(new DBTableColumn(cellValue.ToString()));
                    }
                    else
                    {
                        this.Tables[this.Tables.Count() - 1].Columns.Add(new DBTableColumn("0"));
                    }
                }

                foreach (DBTableColumn column in this.Tables[0].Columns)
                {
                    for (int row = rowStart + 1; row < rowCount + rowStart; row++)
                    {
                        object cellValue = worksheet.Cells[row, this.Tables[0].Columns.IndexOf(column) + colStart].Value;
                        if (column.ColumnValues.Count() <= 0)
                        {
                            if (cellValue != null)
                            {
                                column.ColumnType = worksheet.Cells[row, this.Tables[0].Columns.IndexOf(column) + colStart].Value.GetType();
                            }
                            else
                            {
                                column.ColumnType = typeof(string);
                            }
                        }
                        if (cellValue != null)
                        {
                            column.ColumnValues.Add(cellValue.ToString());
                        }
                        else
                        {
                            column.ColumnValues.Add("0");
                        }
                    }
                }
            }
            return true;
        }
    }
}
