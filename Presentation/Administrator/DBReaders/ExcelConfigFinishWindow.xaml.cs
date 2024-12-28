using BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Presentation.Administrator.DBReaders
{
    /// <summary>
    /// Interaction logic for ExcelConfigFinishWindow.xaml
    /// </summary>
    public partial class ExcelConfigFinishWindow : Window
    {
        public string FilePath { get; set; }
        public ExcelConfigFinishWindow(string filePath)
        {
            InitializeComponent();
            this.FilePath = filePath;

        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (!(string.IsNullOrEmpty(StartRow.Text) || string.IsNullOrEmpty(StartColumn.Text) || string.IsNullOrEmpty(RowsCount.Text) || string.IsNullOrEmpty(ColumnsCount.Text)))
            {
                ExcelReaderService excelReaderService = new ExcelReaderService();
                excelReaderService.SetDataBase(this.FilePath, Int32.Parse(RowsCount.Text), Int32.Parse(ColumnsCount.Text), Int32.Parse(StartRow.Text), Int32.Parse(StartColumn.Text));
                DBReaderWindow newWindow = new DBReaderWindow(excelReaderService.GetTables()[0].Columns);
                newWindow.Left = this.Left;
                newWindow.Top = this.Top;

                newWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Не усі поля заповнені");
            }
        }
    }
}
