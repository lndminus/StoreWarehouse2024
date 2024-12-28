using BusinessLogic.DTO;
using BusinessLogic.Services;
using Presentation.Authorization;
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
    public partial class UserReportsWindow : Window
    {
        public UserDTO ActualUser { get; set; }

        public List<ReportDTO> Reports { get; set; }

        public ReportService ReportService { get; set; }

        public string UserName { get; set; }

        //public List<string> Hints { get; set; }

        public UserReportsWindow(UserDTO user)
        {
            InitializeComponent();
            this.ActualUser = user;
            this.UserName = ActualUser.Name;
            this.ReportService = new ReportService();
            this.Reports = this.ReportService.GetAllReports();

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

        private void ShowReportsWindow_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new UserReportsWindow(this.ActualUser);

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
            if (sender is DataGrid dataGrid && dataGrid.SelectedItem is ReportDTO selectedReport)
            {
                ItemService servise = new ItemService();
                selectedReport.User = ActualUser;
                selectedReport.WarehouseItem = servise.GetItem(selectedReport.WarehouseItemId);
                ReportWindow reportWindow = new ReportWindow(selectedReport);
                reportWindow.ShowDialog();
            }
        }
    }
}
