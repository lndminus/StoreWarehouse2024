using BusinessLogic.BuisinessModels;
using BusinessLogic.DTO;
using BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace StoreWarehouse2023.Test.BuisnessLogic.Tests
{
    public class SQLiteReaderServiceTests
    {
        private DBTableService service;

        [OneTimeSetUp]
        public void Setup()
        {
            this.service = new DBTableService();

        }

        [Test]
        public void GetColumnByName__RetunsColumnWithNameColumnName()
        {
            var columns = new List<DBTableColumnDTO>();
            var columnName = "ColumnName";
            var column = new DBTableColumnDTO(columnName);
            columns.Add(column);

            var actual = this.service.GetColumnByName(columns, columnName);

            Assert.AreEqual(column.Name, actual.Name);

        }

        [Test]
        public void CheckItemsCount_WhenAccountNumberIsOne_ReturnsTotalSumOfPersonalAccounts()
        {
            var ItemColumns = new ItemColumns();
            var columnName = "name";
            var nameColumn = new DBTableColumnDTO(columnName);
            var columnsValues = new List<string>();
            var value1 = "value1";
            var value2 = "value2";
            columnsValues.Add(value1);
            columnsValues.Add(value2);
            nameColumn.ColumnValues = columnsValues;
            ItemColumns.NameColumn = nameColumn;

            var actual = this.service.CheckItemsCount(ItemColumns);

            Assert.AreEqual(columnsValues.Count(), actual);
        }

        [Test]
        public void ConvertTableToItems_WhenAccountNumberIsOne_ReturnsTotalSumOfPersonalAccounts()
        {
            var ItemColumns = new ItemColumns();
            var columnName = "name";
            var nameColumn = new DBTableColumnDTO(columnName);
            var columnsValues = new List<string>();
            var value1 = "value1";
            var value2 = "value2";
            columnsValues.Add(value1);
            columnsValues.Add(value2);
            nameColumn.ColumnValues = columnsValues;
            ItemColumns.NameColumn = nameColumn;

            var actual = this.service.ConvertTableToItems(ItemColumns);

            Assert.AreEqual(columnsValues.Count(), actual.Count());
        }

        [Test]
        public void CheckTypes_WhenAccountNumberIsOne_ReturnsTotalSumOfPersonalAccounts()
        {
            var ItemColumns = new ItemColumns();
            var columnName = "name";
            var nameColumn = new DBTableColumnDTO(columnName);
            nameColumn.ColumnType = typeof(string);
            var columnsValues = new List<string>();
            var value1 = "value1";
            var value2 = "value2";
            columnsValues.Add(value1);
            columnsValues.Add(value2);
            nameColumn.ColumnValues = columnsValues;
            ItemColumns.NameColumn = nameColumn;

            var actual = this.service.CheckTypes(ItemColumns);

            Assert.IsTrue(actual);
        }
    }
}
