using BusinessLogic.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public partial class MSSQLSetDBWindow : Window
    {
        public MSSQLSetDBWindow()
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
                MSSQLReaderService serv = new MSSQLReaderService();
                if (serv.SetDataBase(DBName.Text))
                {
                    var newWindow = new MSSQLSetTableWindow(DBName.Text);

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
