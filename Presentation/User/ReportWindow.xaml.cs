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
    public partial class ReportWindow : Window
    {
        public ReportDTO Report { get; set; }

        public string ReportType { get; set; }

        public string ItemName { get; set; }

        public double ReportQuantity { get; set; }

        public string ItemUnit { get; set; }

        public double TotalPrice { get; set; }

        public string UserName { get; set; }

        public ReportWindow(ReportDTO report)
        {
            InitializeComponent();
            this.Report = report;
            if (this.Report.IsDelivery)
            {
                this.ReportType = "Видача товару";
            }
            else
            {
                this.ReportType = "Прийом товару";
            }
            this.ItemName = this.Report.WarehouseItem.Name;
            this.ReportQuantity = this.Report.Quantity;
            this.ItemUnit = this.Report.WarehouseItem.Unit;
            this.TotalPrice = this.Report.Price;
            this.UserName = this.Report.User.Name;
            DataContext = this;


        }

        private void GenerateReport_Click(object sender, RoutedEventArgs e)
        {
            ReportService service = new ReportService();
            if (service.GenerateReport(Report))
            {
                MessageBox.Show("Звіт згенеровано");
                this.Close();
            }
            else
            {
                MessageBox.Show("Помилка");
            }
        }
    }
}
