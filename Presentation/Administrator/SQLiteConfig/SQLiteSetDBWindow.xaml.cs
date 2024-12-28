using BusinessLogic.Services;
using Presentation.Administrator.MSSQLConfig;
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

namespace Presentation.Administrator.SQLiteConfig
{
    /// <summary>
    /// Interaction logic for SQLiteSetDBWindow.xaml
    /// </summary>
    public partial class SQLiteSetDBWindow : Window
    {
        public SQLiteSetDBWindow()
        {
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(DBName.Text))
            {
                MessageBox.Show("Поле не заповнене");
            }
            else
            {

                SQLiteReaderService serv = new SQLiteReaderService();
                if (serv.SetDataBase(DBName.Text))
                {
                    var newWindow = new SQLiteSetTableWindow(DBName.Text);

                    newWindow.Left = this.Left;
                    newWindow.Top = this.Top;

                    newWindow.Show();
                    this.Close();
            }
                else
            {
                MessageBox.Show("Не вдалося під'єднатися до БД");
            }
        }
        }
    }
}
