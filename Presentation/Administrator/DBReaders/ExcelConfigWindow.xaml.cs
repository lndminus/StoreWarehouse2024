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
using System.Xml.Linq;

namespace Presentation.Administrator.DBReaders
{
    /// <summary>
    /// Interaction logic for ExcelConfigWindow.xaml
    /// </summary>
    public partial class ExcelConfigWindow : Window
    {
        public ExcelConfigWindow()
        {
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(FilePath.Text))
            {
                MessageBox.Show("Шлях не вказано");
            }
            else
            {
                ExcelReaderService excelReaderService = new ExcelReaderService();
                if (excelReaderService.CheckConnection(FilePath.Text))
                {
                    ExcelConfigFinishWindow excelConfigFinishWindow = new ExcelConfigFinishWindow(FilePath.Text);

                    excelConfigFinishWindow.Left = this.Left;
                    excelConfigFinishWindow.Top = this.Top;

                    excelConfigFinishWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Шлях вказано неправильно");
                }
            }
        }
    }
}
