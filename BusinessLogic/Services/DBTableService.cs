using BusinessLogic.BuisinessModels;
using BusinessLogic.DTO;
using BusinessLogic.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class DBTableService
    {
        public DBTableColumnDTO GetColumnByName(List<DBTableColumnDTO> columns, string name)
        {
            foreach(DBTableColumnDTO column in columns)
            { 
                if(column.Name == name)
                {
                    return column;
                }
            }
            return null;
        }

        public int CheckItemsCount(ItemColumns item)
        {
            int count = 0;
            if (item.NameColumn != null)
            {
                if (item.NameColumn.ColumnValues.Count() > 0)
                {
                    count = item.NameColumn.ColumnValues.Count();
                    return count;
                }
            }
            if (item.CodeColumn != null)
            {
                if (item.CodeColumn.ColumnValues.Count() > 0)
                {
                    count = item.CodeColumn.ColumnValues.Count();
                    return count;
                }
            }
            if (item.UnitColumn != null)
            {
                if (item.UnitColumn.ColumnValues.Count() > 0)
                {
                    count = item.UnitColumn.ColumnValues.Count();
                    return count;
                }
            }
            if (item.PriceColumn != null)
            {
                if (item.PriceColumn.ColumnValues.Count() > 0)
                {
                    count = item.PriceColumn.ColumnValues.Count();
                    return count;
                }
            }
            if (item.CategoryColumn != null)
            {
                if (item.CategoryColumn.ColumnValues.Count() > 0)
                {
                    count = item.CategoryColumn.ColumnValues.Count();
                    return count;
                }
            }
            if (item.DescriptionColumn != null)
            {
                if (item.DescriptionColumn.ColumnValues.Count() > 0)
                {
                    count = item.DescriptionColumn.ColumnValues.Count();
                    return count;
                }
            }
            if (item.QuantityColumn != null)
            {
                if (item.QuantityColumn.ColumnValues.Count() > 0)
                {
                    count = item.QuantityColumn.ColumnValues.Count();
                    return count;
                }
            }
            return count;
        }
    
        public List<WarehouseItemDTO> ConvertTableToItems(ItemColumns itemColumns)
        {
            List<WarehouseItemDTO> items = new List<WarehouseItemDTO>();
            int ItemCount = this.CheckItemsCount(itemColumns);
            for (int i = 0; i < ItemCount; i++)
            {
                items.Add(new WarehouseItemDTO());
                if (itemColumns.NameColumn != null)
                {
                    items[i].Name = itemColumns.NameColumn.ColumnValues[i];
                }
                else
                {
                    items[i].Name = "";
                }
                if (itemColumns.CodeColumn != null)
                {
                    items[i].Code = itemColumns.CodeColumn.ColumnValues[i];
                }
                else
                {
                    items[i].Code = "";
                }
                if (itemColumns.UnitColumn != null)
                {
                    items[i].Unit = itemColumns.UnitColumn.ColumnValues[i];
                }
                else
                {
                    items[i].Unit = "";
                }
                if (itemColumns.CategoryColumn != null)
                {
                    items[i].Category = itemColumns.CategoryColumn.ColumnValues[i];
                }
                else
                {
                    items[i].Category = "";
                }
                if (itemColumns.DescriptionColumn != null)
                {
                    items[i].Description = itemColumns.DescriptionColumn.ColumnValues[i];
                }
                else
                {
                    items[i].Description = "";
                }
                if (itemColumns.QuantityColumn != null)
                {
                    items[i].Quantity = double.Parse(itemColumns.QuantityColumn.ColumnValues[i]);
                }
                else
                {
                    items[i].Quantity = 0;
                }
                if (itemColumns.PriceColumn != null)
                {
                    items[i].Price = double.Parse(itemColumns.PriceColumn.ColumnValues[i]);
                }
                else
                {
                    items[i].Price = 0;
                }
            }
            return items;
        }

        public bool CheckTypes(ItemColumns itemColumns)
        {
            if (itemColumns.NameColumn != null)
            {
                if (!typeof(String).IsAssignableFrom(itemColumns.NameColumn.ColumnType))
                {
                    throw new BLException("Тип указаних даних для колони Назва не підходить", itemColumns.NameColumn.ColumnType.ToString());
                }
            }
            if (itemColumns.CodeColumn != null)
            {
                if (!typeof(String).IsAssignableFrom(itemColumns.CodeColumn.ColumnType))
                {
                    throw new BLException("Тип указаних даних для колони Код не підходить", itemColumns.CodeColumn.ColumnType.ToString());
                }
            }
            if (itemColumns.UnitColumn != null)
            {
                if (!typeof(String).IsAssignableFrom(itemColumns.UnitColumn.ColumnType))
                {
                    throw new BLException("Тип указаних даних для колони Одиниця вимірювання не підходить", itemColumns.UnitColumn.ColumnType.ToString());
                }
            }
            if (itemColumns.CategoryColumn != null)
            {
                if (!typeof(String).IsAssignableFrom(itemColumns.CategoryColumn.ColumnType))
                {
                    throw new BLException("Тип указаних даних для колони Назва не підходить", itemColumns.CategoryColumn.ColumnType.ToString());
                }
            }
            if (itemColumns.DescriptionColumn != null)
            {
                if (!typeof(String).IsAssignableFrom(itemColumns.DescriptionColumn.ColumnType))
                {
                    throw new BLException("Тип указаних даних для колони Назва не підходить", itemColumns.DescriptionColumn.ColumnType.ToString());
                }
            }
            if (itemColumns.QuantityColumn != null)
            {
                if (!(typeof(double).IsAssignableFrom(itemColumns.QuantityColumn.ColumnType) || itemColumns.QuantityColumn.ColumnType == typeof(System.Int32)))
                {
                    throw new BLException("Тип указаних даних для колони Назва не підходить", itemColumns.QuantityColumn.ColumnType.ToString());
                }
            }
            if (itemColumns.PriceColumn != null)
            {
                if (!(typeof(double).IsAssignableFrom(itemColumns.PriceColumn.ColumnType) || itemColumns.PriceColumn.ColumnType == typeof(System.Int32)))
                {
                    throw new BLException("Тип указаних даних для колони Назва не підходить", itemColumns.PriceColumn.ColumnType.ToString());
                }
            }
            return true;
        }
    }
}
