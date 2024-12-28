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
    /// Interaction logic for AdminItemWindow.xaml
    /// </summary>
    public partial class AdminItemWindow : Window
    {
        public WarehouseItemDTO Item { get; set; }
        public AdminItemWindow(WarehouseItemDTO item)
        {
            InitializeComponent();
            DataContext = item;
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            this.Item = new WarehouseItemDTO();
            this.Item.Name = ItemName.Text;
            this.Item.Description = ItemDescription.Text;
            this.Item.Code = ItemCode.Text;
            this.Item.Price = double.Parse(ItemPrice.Text);
            this.Item.Unit = ItemUnit.Text;
            this.Item.Quantity = int.Parse(ItemQuantity.Text);
            this.DialogResult = true;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            // Проверка, является ли вводимый символ числом
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true; // Предотвращение ввода символа
            }
        }
    }
}
