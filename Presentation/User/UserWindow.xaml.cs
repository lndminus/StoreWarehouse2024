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
using BusinessLogic.DTO;
using BusinessLogic.Services;
using Presentation.Administrator;
using Presentation.Authorization;

namespace Presentation.User
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserDTO ActualUser { get; set; }

        public ObservableCollection<WarehouseItemDTO> SingleItems { get; set; }

        public List<WarehouseItemDTO> SItems { get; set; }

        public ItemService ItemService { get; set; }

        public string Inputl { get; set; }

        public string Passw { get; set; }

        public List<string> Hints{ get; set; }


        public UserWindow(UserDTO user)
        {
            InitializeComponent();
            this.ActualUser = user;
            Inputl = user.Name;
            Passw = user.Password;
            this.ItemService = new ItemService();
            this.SingleItems = new ObservableCollection<WarehouseItemDTO>();
            this.SItems = this.ItemService.GetAllItems();
            this.Hints = ItemService.GetItemsNames();

            DataContext = this;

        }
        public UserWindow(UserDTO user, string name)
        {
            InitializeComponent();
            this.ActualUser = user;
            Inputl = user.Name;
            Passw = user.Password;
            this.ItemService = new ItemService();
            this.SingleItems = new ObservableCollection<WarehouseItemDTO>();
            this.SItems = this.ItemService.GetItemsByNameOrCategory(name);
            this.Hints = ItemService.GetItemsNames();

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

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new UserWindow(this.ActualUser, Search.Text);

            newWindow.Left = this.Left;
            newWindow.Top = this.Top;
            newWindow.Show();
            this.Close();
        }

        private void ShowReportsWindow_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new UserReportsWindow(this.ActualUser);

            newWindow.Left = this.Left;
            newWindow.Top = this.Top;

            newWindow.Show();
            this.Close();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new UserWindow(this.ActualUser);

            newWindow.Left = this.Left;
            newWindow.Top = this.Top;
            newWindow.Show();
            this.Close();
        }

        private void ShowItemWindow_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new UserWindow(this.ActualUser);

            newWindow.Left = this.Left;
            newWindow.Top = this.Top;

            newWindow.Show();
            this.Close();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DataGrid dataGrid && dataGrid.SelectedItem is WarehouseItemDTO selectedItem)
            {
                ItemWindow itemWindow = new ItemWindow(selectedItem, this.ActualUser.Id);
                itemWindow.ShowDialog();
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
}
