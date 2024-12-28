using BusinessLogic.DTO;
using BusinessLogic.Services;
using Presentation.Administrator.DBReaders;
using Presentation.Administrator.MSSQLConfig;
using Presentation.Administrator.SQLiteConfig;
using Presentation.Authorization;
using Presentation.User;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public partial class AdminWindow : Window
    {
        public AdminDTO ActualAdmin { get; set; }

        public string AdminName { get; set; }

        public List<WarehouseItemDTO> Items { get; set; }

        private ItemService ItemService { get; set; }

        public List<string> Hints { get; set; }

        public AdminWindow(AdminDTO admin)
        {
            InitializeComponent();
            this.ActualAdmin = admin;
            this.AdminName = admin.Name;
            this.ItemService = new ItemService();

            this.Items = this.ItemService.GetAllItems();
            this.Hints = new List<string>
            {
                "Слово1",
                "Слово2",
                "Слово3",
                "1лово1",
                "плово2",
                "рлово3",
            };

            DataContext = this;
        }
        private void ChangeWindow_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new AuthorizationWindow();

            newWindow.Left = this.Left;
            newWindow.Top = this.Top;

            newWindow.Show();
            this.Close();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new AdminWindow(this.ActualAdmin);

            newWindow.Left = this.Left;
            newWindow.Top = this.Top;
            newWindow.Show();
            this.Close();
        }
        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            AddItemWindow transWindow = new AddItemWindow();
            if (transWindow.ShowDialog() == true)
            {
                ItemService ser = new ItemService();
                ser.AddItem(transWindow.Item);
                //string name = transWindow.ThName;
                //string color = transWindow.Color;
                //string qw = transWindow.Quantityorweight;
                //int qwint = Int32.Parse(qw);
                //system.AddSomeThing(name, color, qwint, bulk);

                //if (true)
                //{
                    MessageBox.Show("Зарахування пройшло успішно");
                //}
                //else
                //{
                //    MessageBox.Show("Помилка зарахування");
                //}
            }
            else
            {
                MessageBox.Show("Помилка зарахування");
            }
        }


        //C:\SQLiteDb
        private void AddDB_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new MSSQLConfigWindow();

            newWindow.Left = this.Left;
            newWindow.Top = this.Top;
            //string s = "C:\\SQLiteDb\\TestSQLiteDB.db";
            newWindow.Show();
        }

        private void AddSQLiteDB_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new SQLiteSetDBWindow();

            newWindow.Left = this.Left;
            newWindow.Top = this.Top;
            //string s = "C:\\SQLiteDb\\TestSQLiteDB.db";
            newWindow.Show();
        }

        private void AddMSSQLDB_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new MSSQLSetDBWindow();

            newWindow.Left = this.Left;
            newWindow.Top = this.Top;

            newWindow.Show();
        }

        //C:\\ExcelDB\\ExcelDB.xlsx
        private void AddExcel_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new ExcelConfigWindow();

            newWindow.Left = this.Left;
            newWindow.Top = this.Top;

            newWindow.Show();
        }

        private void RegisterUser_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow adduserwindow = new AddUserWindow();
            if (adduserwindow.ShowDialog() == true)
            {
                AuthorizationService service = new AuthorizationService();
                service.RegisterUser(adduserwindow.User, new AdminDTO() { Id = 1});
                MessageBox.Show("Зарахування пройшло успішно");
                
            }
            else
            {
                MessageBox.Show("Помилка реєстрації");
            }
        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DataGrid dataGrid && dataGrid.SelectedItem is WarehouseItemDTO selectedItem)
            {
                // Создание нового окна с данными выбранного элемента
                AdminItemWindow itemWindow = new AdminItemWindow(selectedItem);
                if (itemWindow.ShowDialog() == true)
                {
                    ItemService service = new ItemService();
                    service.ChangeItem(selectedItem);
                    //service.RegisterUser(adduserwindow.User);
                    MessageBox.Show("Змінення збережені");

                }
                else
                {
                    MessageBox.Show("Помилка");
                }
            }
        }

        private void ComboBox_TextChanged(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string searchText = comboBox.Text;

            if (string.IsNullOrEmpty(searchText))
            {
                comboBox.ItemsSource = null;
                comboBox.IsDropDownOpen = false;
                return;
            }

            List<string> filteredList = Hints
                .Where(hint => hint.StartsWith(searchText, StringComparison.OrdinalIgnoreCase))
                .ToList();

            comboBox.ItemsSource = filteredList;
            comboBox.IsDropDownOpen = true;
        }

    }

























    //public class Item : INotifyPropertyChanged
    //{
    //    private string name;
    //    public string Name
    //    {
    //        get { return name; }
    //        set { name = value; NotifyPropertyChanged("Name"); }
    //    }

    //    private string characteristic1;
    //    public string Characteristic1
    //    {
    //        get { return characteristic1; }
    //        set { characteristic1 = value; NotifyPropertyChanged("Characteristic1"); }
    //    }

    //    private string characteristic2;
    //    public string Characteristic2
    //    {
    //        get { return characteristic2; }
    //        set { characteristic2 = value; NotifyPropertyChanged("Characteristic2"); }
    //    }

    //    public event PropertyChangedEventHandler PropertyChanged;
    //    private void NotifyPropertyChanged(string propertyName)
    //    {
    //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //    }
    //}
}
