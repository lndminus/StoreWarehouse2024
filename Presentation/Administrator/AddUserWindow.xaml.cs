using BusinessLogic.DTO;
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

namespace Presentation.Administrator
{
    /// <summary>
    /// Interaction logic for AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public UserDTO User { get; set; }
        public AddUserWindow()
        {
            InitializeComponent();
        }
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(UserName.Text) || string.IsNullOrEmpty(UserLastName.Text) || string.IsNullOrEmpty(UserLogin.Text) || string.IsNullOrEmpty(UserPassword.Text))
            {
                MessageBox.Show("Не усі поля заповнені");
            }
            else if (UserPassword.Text != UserRepidPassword.Text)
            {
                MessageBox.Show("Підтвердження паролю не пройдено");
            }
            else
            {
                this.User = new UserDTO();
                this.User.Name = UserName.Text;
                this.User.LastName = UserLastName.Text;
                this.User.Login = UserLogin.Text;
                this.User.Password = UserPassword.Text;
                this.DialogResult = true;
            }
        }
    }
}
