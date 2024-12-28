using BusinessLogic.Services;
using Presentation.Administrator.DBReaders;
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

namespace Presentation.Administrator.MSSQLConfig
{
    /// <summary>
    /// Interaction logic for MSSQLSetTableWindow.xaml
    /// </summary>
    public partial class MSSQLSetTableWindow : Window
    {
        public MSSQLReaderService Service;
        public MSSQLSetTableWindow(string DBName)
        {
            InitializeComponent();
            this.Service = new MSSQLReaderService();
            this.Service.SetDataBase(DBName);
            TableNames.ItemsSource = this.Service.GetTablesNames();

            DataContext = this;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TableNames.Text))
            {
                MessageBox.Show("Табличку не обрано");
            }
            else
            {
                var newWindow = new DBReaderWindow(this.Service.GetTableByName(TableNames.Text).Columns);

                newWindow.Left = this.Left;
                newWindow.Top = this.Top;

                newWindow.Show();
                this.Close();
            }
        }
    }
}
