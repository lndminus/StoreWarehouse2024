using StoreWarehouse2023.Presentation;
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

namespace StoreWarehouse2023
{
    /// <summary>
    /// Interaction logic for SomeWindow.xaml
    /// </summary>
    public partial class SomeWindow : Window
    {
        public string InputLogin { get; set; }
        public SomeWindow()
        {
            InitializeComponent();
            InputLogin = "lll";
        }

        private void ChangeWindow_Click(object sender, RoutedEventArgs e)
        {
            // Создание нового окна с надписью


            var newWindow = new MainWindow(UsernameTextBox.Text, PasswordBox.Password);

            newWindow.Left = this.Left;
            newWindow.Top = this.Top;


            // Создание текстового элемента управления
            //var textBlock = new TextBlock();
            //textBlock.Text = "Привет, мир!";
            //textBlock.HorizontalAlignment = HorizontalAlignment.Center;
            //textBlock.VerticalAlignment = VerticalAlignment.Center;

            // Добавление текстового элемента в окно
            //newWindow.Content = textBlock;

            // Отображение нового окна и закрытие текущего окна
            newWindow.Show();
            this.Close();
        }
    }
}
