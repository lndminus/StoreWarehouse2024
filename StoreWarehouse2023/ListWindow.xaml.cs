using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
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
using System.Xml.Linq;

namespace StoreWarehouse2023
{
    /// <summary>
    /// Interaction logic for ListWindow.xaml
    /// </summary>
    public partial class ListWindow : Window
    {
        public ObservableCollection<ListItem> ListItems { get; set; }
        public ListWindow()

        {

            InitializeComponent();




            ListItems = new ObservableCollection<ListItem>
            {
                new ListItem
                {
                    Title = "Заголовок 1",
                    Items = new List<string> { "Элемент 1", "Элемент 2", "Элемент 3" }
                },
                new ListItem
                {
                    Title = "Заголовок 2",
                    Items = new List<string> { "Элемент 4", "Элемент 5", "Элемент 6" }
                },
                new ListItem
                {
                    Title = "Заголовок 3",
                    Items = new List<string> { "Элемент 7", "Элемент 8", "Элемент 9" }
                }
            };

            DataContext = this;

        }









        public class ListItem
        {
            public string Title { get; set; }
            public List<string> Items { get; set; }
        }
    }
}
