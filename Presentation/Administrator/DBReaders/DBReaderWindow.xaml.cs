using BusinessLogic.BuisinessModels;
using BusinessLogic.DTO;
using BusinessLogic.Infrastructure;
using BusinessLogic.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
using System.Xml.Linq;

namespace Presentation.Administrator.DBReaders
{

    public partial class DBReaderWindow : Window
    {
        public List<DBTableColumnDTO> TableColumns { get; set; }
        public DBReaderWindow(List<DBTableColumnDTO> tableColumns)
        {
            InitializeComponent();
            this.TableColumns = tableColumns;
            List<string> ColumnNames = new List<string>();
            foreach (DBTableColumnDTO column in tableColumns)
            {
                ColumnNames.Add(column.Name);
            }
            ItemNameComboBox.ItemsSource = ColumnNames;
            ItemCategoryComboBox.ItemsSource = ColumnNames;
            ItemDescriptionComboBox.ItemsSource = ColumnNames;
            ItemPriceComboBox.ItemsSource = ColumnNames;
            ItemUnitComboBox.ItemsSource = ColumnNames;
            ItemCodeComboBox.ItemsSource = ColumnNames;
            ItemQuantityComboBox.ItemsSource = ColumnNames;

            DataContext = this;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DBTableService tableService = new DBTableService();
            ItemService itemService = new ItemService();
            try
            {
                ItemColumns Item = new ItemColumns()
                {
                    NameColumn = tableService.GetColumnByName(this.TableColumns, ItemNameComboBox.Text),
                    CategoryColumn = tableService.GetColumnByName(this.TableColumns, ItemCategoryComboBox.Text),
                    CodeColumn = tableService.GetColumnByName(this.TableColumns, ItemCodeComboBox.Text),
                    UnitColumn = tableService.GetColumnByName(this.TableColumns, ItemUnitComboBox.Text),
                    DescriptionColumn = tableService.GetColumnByName(this.TableColumns, ItemDescriptionComboBox.Text),
                    QuantityColumn = tableService.GetColumnByName(this.TableColumns, ItemQuantityComboBox.Text),
                    PriceColumn = tableService.GetColumnByName(this.TableColumns, ItemPriceComboBox.Text)
                };
                if (tableService.CheckTypes(Item))
                {
                    itemService.SaveItemsFromDB(tableService.ConvertTableToItems(Item));
                    MessageBox.Show("Дані успішно перенесені" + tableService.ConvertTableToItems(Item).Count);
                }
            }
            catch (BLException ex)
            {
                MessageBox.Show(ex.Message + ex.ExceptionProperty);
            }
        }
    }
}
