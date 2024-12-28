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
using Presentation.User;
using Presentation.Administrator;
using BusinessLogic.DTO;
using BusinessLogic.Services;

namespace Presentation.Authorization
{
    /// <summary>
    /// Interaction logic for AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        private AuthorizationService authservice { get; set; }
        public AuthorizationWindow()
        {
            InitializeComponent();
            this.authservice = new AuthorizationService();
        }

        private void Signin_Click(object sender, RoutedEventArgs e)
        {
            if (this.authservice.LogInAsUser(new UserDTO { Login = UsernameTextBox.Text, Password = PasswordBox.Password }))
            {
                var Window = new UserWindow(this.authservice.GetUserByLogin(new UserDTO { Login = UsernameTextBox.Text, Password = PasswordBox.Password }));

                Window.Left = this.Left;
                Window.Top = this.Top;

                Window.Show();
                this.Close();
            }
            else if (this.authservice.LogInAsAdmin(new AdminDTO { Login = UsernameTextBox.Text, Password = PasswordBox.Password }))
            {
                var Window = new AdminWindow(this.authservice.GetAuthorizedAdmin(new AdminDTO { Login = UsernameTextBox.Text, Password = PasswordBox.Password }));

                Window.Left = this.Left;
                Window.Top = this.Top;

                Window.Show();
                this.Close();
            }
            




            //AuthM am = new AuthM();
            //foreach (AdminDTO a in am.GetAdmins())
            //{
            //    if(a.Login == UsernameTextBox.Text)
            //    {
            //        var Window = new UserWindow(a.Name, a.LastName);

            //        Window.Left = this.Left;
            //        Window.Top = this.Top;

            //        Window.Show();
            //        this.Close();
            //    }
            //}

            //var newWindow = new UserWindow(UsernameTextBox.Text, PasswordBox.Password);

            //newWindow.Left = this.Left;
            //newWindow.Top = this.Top;

            //newWindow.Show();
            //this.Close();
        }
    }
}
