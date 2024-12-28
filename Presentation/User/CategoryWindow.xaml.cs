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

namespace Presentation.User
{

    public partial class CategoryWindow : Window
    {

        public UserDTO ActualUser { get; set; }
        public CategoryWindow(UserDTO user)
        {
            InitializeComponent();
            ItemService s = new ItemService();
            this.ActualUser = user;
            Categoryes.ItemsSource = s.GetItemsCategoryes();

            DataContext = this;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new UserWindow(this.ActualUser, Categoryes.Text);

            newWindow.Left = this.Left;
            newWindow.Top = this.Top;
            newWindow.Show();
            this.Close();
        }
    }
}
