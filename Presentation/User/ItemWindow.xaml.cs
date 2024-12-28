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
    /// <summary>
    /// Interaction logic for ItemWindow.xaml
    /// </summary>
    public partial class ItemWindow : Window
    {
        public WarehouseItemDTO Item { get; set; }

        public int UserId { get; set; }
        public ItemWindow(WarehouseItemDTO selectedItem, int userId)
        {
            InitializeComponent();
            this.Item = selectedItem;
            this.UserId = userId;
            DataContext = this.Item;
        }

        private void ReleaseItems_Click(object sender, RoutedEventArgs e)
        {
            ItemService serv = new ItemService();
            if (serv.ReduceItemQuantity(double.Parse(ReleaseQuantity.Text), this.Item, new UserDTO { Id = this.UserId }))
            {
                MessageBox.Show("Видача пройшла успішно");
            }
            else
            {
                MessageBox.Show("Недостатня кількість товару");
            }
            this.Close();
        }

        private void AcceptItems_Click(object sender, RoutedEventArgs e)
        {
            if (AcceptQuantity.Text != null)
            {
                ItemService serv = new ItemService();
                if (serv.IncreaseItemQuantity(double.Parse(AcceptQuantity.Text), this.Item, new UserDTO { Id = this.UserId }))
                {
                    MessageBox.Show("Прийом товару пройшов успішно");
                }
                else
                {
                    MessageBox.Show("Помилка прийому товару");
                }
            }
            else
            {
                MessageBox.Show("Помилка прийому товару");
            }
            this.Close();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
            }
        }
    }
}
