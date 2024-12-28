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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StoreWarehouse2023.Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Item> Items { get; set; }

        public List<string> wordlist {  get; set; }

        public string Inputl { get; set; }

        public string Passw { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Inputl = "login";
            Items = new ObservableCollection<Item>();
            Items.Add(new Item { Name = "Элемент 1", Characteristic1 = "Значение 1", Characteristic2 = "Значение 2" });
            Items.Add(new Item { Name = "Элемент 2", Characteristic1 = "Значение 3", Characteristic2 = "Значение 4" });
            Items.Add(new Item { Name = "Элемент 3", Characteristic1 = "Значение 5", Characteristic2 = "Значение 6" });
            Items.Add(new Item { Name = "Элемент 1", Characteristic1 = "Значение 1", Characteristic2 = "Значение 2" });
            Items.Add(new Item { Name = "Элемент 2", Characteristic1 = "Значение 3", Characteristic2 = "Значение 4" });
            Items.Add(new Item { Name = "Элемент 3", Characteristic1 = "Значение 5", Characteristic2 = "Значение 6" });
            Items.Add(new Item { Name = "Элемент 1", Characteristic1 = "Значение 1", Characteristic2 = "Значение 2" });
            Items.Add(new Item { Name = "Элемент 2", Characteristic1 = "Значение 3", Characteristic2 = "Значение 4" });
            Items.Add(new Item { Name = "Элемент 3", Characteristic1 = "Значение 5", Characteristic2 = "Значение 6" });
            Items.Add(new Item { Name = "Элемент 1", Characteristic1 = "Значение 1", Characteristic2 = "Значение 2" });
            Items.Add(new Item { Name = "Элемент 2", Characteristic1 = "Значение 3", Characteristic2 = "Значение 4" });
            Items.Add(new Item { Name = "Элемент 3", Characteristic1 = "Значение 5", Characteristic2 = "Значение 6" });
            Items.Add(new Item { Name = "Элемент 1", Characteristic1 = "Значение 1", Characteristic2 = "Значение 2" });
            Items.Add(new Item { Name = "Элемент 2", Characteristic1 = "Значение 3", Characteristic2 = "Значение 4" });
            Items.Add(new Item { Name = "Элемент 3", Characteristic1 = "Значение 5", Characteristic2 = "Значение 6" });
            Items.Add(new Item { Name = "Элемент 1", Characteristic1 = "Значение 1", Characteristic2 = "Значение 2" });
            Items.Add(new Item { Name = "Элемент 2", Characteristic1 = "Значение 3", Characteristic2 = "Значение 4" });
            Items.Add(new Item { Name = "Элемент 3", Characteristic1 = "Значение 5", Characteristic2 = "Значение 6" });


            this.wordlist = new List<string>
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
        public MainWindow(string il, string pass)
        {
            InitializeComponent();
            Inputl = il;
            Passw = pass;
            Items = new ObservableCollection<Item>();
            Items.Add(new Item { Name = "Элемент 1", Characteristic1 = "Значение 1", Characteristic2 = "Значение 2" });
            Items.Add(new Item { Name = "Элемент 2", Characteristic1 = "Значение 3", Characteristic2 = "Значение 4" });
            Items.Add(new Item { Name = "Элемент 3", Characteristic1 = "Значение 5", Characteristic2 = "Значение 6" });
            Items.Add(new Item { Name = "Элемент 1", Characteristic1 = "Значение 1", Characteristic2 = "Значение 2" });
            Items.Add(new Item { Name = "Элемент 2", Characteristic1 = "Значение 3", Characteristic2 = "Значение 4" });
            Items.Add(new Item { Name = "Элемент 3", Characteristic1 = "Значение 5", Characteristic2 = "Значение 6" });
            Items.Add(new Item { Name = "Элемент 1", Characteristic1 = "Значение 1", Characteristic2 = "Значение 2" });
            Items.Add(new Item { Name = "Элемент 2", Characteristic1 = "Значение 3", Characteristic2 = "Значение 4" });
            Items.Add(new Item { Name = "Элемент 3", Characteristic1 = "Значение 5", Characteristic2 = "Значение 6" });
            Items.Add(new Item { Name = "Элемент 1", Characteristic1 = "Значение 1", Characteristic2 = "Значение 2" });
            Items.Add(new Item { Name = "Элемент 2", Characteristic1 = "Значение 3", Characteristic2 = "Значение 4" });
            Items.Add(new Item { Name = "Элемент 3", Characteristic1 = "Значение 5", Characteristic2 = "Значение 6" });
            Items.Add(new Item { Name = "Элемент 1", Characteristic1 = "Значение 1", Characteristic2 = "Значение 2" });
            Items.Add(new Item { Name = "Элемент 2", Characteristic1 = "Значение 3", Characteristic2 = "Значение 4" });
            Items.Add(new Item { Name = "Элемент 3", Characteristic1 = "Значение 5", Characteristic2 = "Значение 6" });
            Items.Add(new Item { Name = "Элемент 1", Characteristic1 = "Значение 1", Characteristic2 = "Значение 2" });
            Items.Add(new Item { Name = "Элемент 2", Characteristic1 = "Значение 3", Characteristic2 = "Значение 4" });
            Items.Add(new Item { Name = "Элемент 3", Characteristic1 = "Значение 5", Characteristic2 = "Значение 6" });

            this.wordlist = new List<string>
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

            List<string> filteredList = wordlist
                .Where(word => word.StartsWith(searchText, StringComparison.OrdinalIgnoreCase))
                .ToList();

            comboBox.ItemsSource = filteredList;
            comboBox.IsDropDownOpen = true;
        }

        private void ChangeWindow_Click(object sender, RoutedEventArgs e)
        {
            // Создание нового окна с надписью
            var newWindow = new SomeWindow();

            newWindow.Left = this.Left;
            newWindow.Top = this.Top;
            //newWindow.Width = 300;
            //newWindow.Height = 200;

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
        private void ChangeWindow_Click2(object sender, RoutedEventArgs e)
        {
            // Создание нового окна с надписью
            var newWindow = new ListWindow();

            newWindow.Left = this.Left;
            newWindow.Top = this.Top;
            //newWindow.Width = 300;
            //newWindow.Height = 200;

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

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DataGrid dataGrid && dataGrid.SelectedItem is Item selectedItem)
            {
                // Создание нового окна с данными выбранного элемента
                ItemDetailsWindow itemDetailsWindow = new ItemDetailsWindow(selectedItem);
                itemDetailsWindow.ShowDialog();
            }
        }


    }
    public class Item : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; NotifyPropertyChanged("Name"); }
        }

        private string characteristic1;
        public string Characteristic1
        {
            get { return characteristic1; }
            set { characteristic1 = value; NotifyPropertyChanged("Characteristic1"); }
        }

        private string characteristic2;
        public string Characteristic2
        {
            get { return characteristic2; }
            set { characteristic2 = value; NotifyPropertyChanged("Characteristic2"); }
        }

        public DateTime time { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public Item()
        {
            this.time = DateTime.Now;
        }
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
