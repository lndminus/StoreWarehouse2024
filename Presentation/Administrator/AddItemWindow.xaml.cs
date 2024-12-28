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
    /// Interaction logic for AddItemWindow.xaml
    /// </summary>
    public partial class AddItemWindow : Window
    {
        public WarehouseItemDTO Item{ get; set; }

        public AddItemWindow()
        {
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.Item = new WarehouseItemDTO();
            this.Item.Name = ItemName.Text;
            this.Item.Category = ItemCategory.Text;
            this.Item.Description = ItemDescription.Text;
            this.Item.Code = ItemCode.Text;
            this.Item.Price = double.Parse(ItemPrice.Text);
            this.Item.Unit = ItemUnit.Text;
            this.Item.Quantity = double.Parse(ItemQuantity.Text);
            this.DialogResult = true;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1) && !(e.Text =="."))
            {
                e.Handled = true;
            }
        }
    }
}
