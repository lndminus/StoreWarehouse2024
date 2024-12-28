using DataAccess.Entities;
using DataAccess.Interfaces;
using OfficeOpenXml;

namespace DataAccess.DBReaders
{
    public class ExcelReader : IDBReader
    {
        public string ConnectionString { get; }

        private int RowCount { get; set; }

        private int ColumnCount { get; set; }

        private int StartRow { get; set; }

        private int StartColumn { get; set; }


        private List<DBTable> Tables { get; set; }

        public ExcelReader(string FilePath, int rowCount, int colCount, int rowStart, int colStart)
        {
            this.RowCount = rowCount;
            this.ColumnCount = colCount;
            this.StartRow = rowStart;
            this.StartColumn = colStart;
            this.ConnectionString = FilePath;
            this.Tables = new List<DBTable>();
        }

        public ExcelReader(string FilePath)
        {
            this.ConnectionString = FilePath;
        }

        public bool CheckConnection()
        {
            if (File.Exists(this.ConnectionString))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ReadAllData()
        {
            return this.AddValuesToTable(this.RowCount, this.ColumnCount, this.StartRow, this.StartColumn);
        }

        public List<DBTable> GetAllTables()
        {
            return this.Tables;
        }


        private bool AddValuesToTable(int rowCount, int colCount, int rowStart, int colStart)
        {
            //string ConnectionString = "C:\\ExcelDB\\ExcelDB.xlsx";

            int Worksheet = 0;

            using (var package = new ExcelPackage(new FileInfo(this.ConnectionString)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[Worksheet];

                this.Tables.Add(new DBTable(this.ConnectionString));

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
