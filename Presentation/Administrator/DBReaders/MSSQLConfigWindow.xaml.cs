using BusinessLogic.DTO;
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
    /// Interaction logic for MSSQLConfigWindow.xaml
    /// </summary>
    public partial class MSSQLConfigWindow : Window
    {
        public MSSQLConfigWindow()
        {
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(DBName.Text) || string.IsNullOrEmpty(TableName.Text))
            {
                MessageBox.Show("Не усі поля заповнені");
            }
            else
            {
                MSSQLReaderService serv = new MSSQLReaderService();
                serv.SetDataBase(DBName.Text);


                var newWindow = new DBReaderWindow(serv.GetTables()[0].Columns);

                newWindow.Left = this.Left;
                newWindow.Top = this.Top;

                newWindow.Show();
                this.Close();
            }
        }
    }
}
