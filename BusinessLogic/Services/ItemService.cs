using BusinessLogic.BuisinessModels;
using BusinessLogic.DTO;
using BusinessLogic.Infrastructure;
using DataAccess.Entities;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ItemService
    {
        public IUnitOfWork Database {  get; set; }

        public ItemService(IUnitOfWork u)
        {
            //this.Database = new EFUnitOfWork();
            this.Database = u;
        }
        public ItemService()
        {
            this.Database = new EFUnitOfWork();
        }

        public List<WarehouseItemDTO> GetAllItems()
        {
            List<WarehouseItemDTO> items = new List<WarehouseItemDTO>();
            foreach (WarehouseItem item in Database.WarehouseItems.GetAll())
            {
                items.Add(this.ItemToItemDTO(item));
            }
            return items;
        }

        public WarehouseItemDTO GetItem(int id)
        {
            return this.ItemToItemDTO(this.Database.WarehouseItems.Get(id));
        }
        
        public bool AddItem(WarehouseItemDTO item)
        {
            this.Database.WarehouseItems.Create(new WarehouseItem 
            { 
                Name = item.Name,
                Category = item.Category,
                Unit = item.Unit, 
                Code = item.Code, 
                Description = item.Description, 
                Price = item.Price, 
                Quantity = item.Quantity
            });
            this.Database.Save();
            return true;
        }

        public bool ChangeItem(WarehouseItemDTO item)
        {
            this.Database.WarehouseItems.Update(this.ItemDTOToItem(item));
            this.Database.Save();
            return true;
        }

        public bool DeleteItem(int id)
        {
            this.Database.WarehouseItems.Delete(id);
            this.Database.Save();
            return true;
        }

        public bool ReduceItemQuantity(double quantity, WarehouseItemDTO item, UserDTO user)
        {
            if (quantity > 0)
            {
                WarehouseItem dbitem = this.Database.WarehouseItems.Get(item.Id);
                if (dbitem != null)
                {
                    if (dbitem.Quantity >= quantity)
                    {
                        dbitem.Quantity = dbitem.Quantity - quantity;
                        this.Database.WarehouseItems.Update(dbitem);
                        this.Database.Reports.Create(new Report
                        {
                            IsDelivery = true,
                            Price = dbitem.Price * quantity,
                            Quantity = dbitem.Quantity,
                            ReportTime = DateTime.Now,
                            UserId = user.Id,
                            WarehouseItemId = item.Id
                        });
                        this.Database.Save();
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IncreaseItemQuantity(double quantity, WarehouseItemDTO item, UserDTO user)
        {
            if (quantity > 0)
            {
                WarehouseItem dbitem = this.Database.WarehouseItems.Get(item.Id);
                if (dbitem != null)
                {

                    dbitem.Quantity = dbitem.Quantity + quantity;
                    this.Database.WarehouseItems.Update(dbitem);
                    this.Database.Reports.Create(new Report
                    {
                        IsDelivery = false,
                        Price = dbitem.Price * quantity,
                        Quantity = quantity,
                        ReportTime = DateTime.Now,
                        UserId = user.Id,
                        WarehouseItemId = item.Id
                    });
                    this.Database.Save();
                    return true;

                }
            }
            return false;
        }

        private WarehouseItem ItemDTOToItem(WarehouseItemDTO itemDTO)
        {
            return new WarehouseItem() 
            { 
                Quantity = itemDTO.Quantity, 
                Category = itemDTO.Category, 
                Unit = itemDTO.Unit, 
                Code = itemDTO.Code, 
                Description = itemDTO.Description, 
                Price = itemDTO.Price, 
                Id = itemDTO.Id, 
                Name = itemDTO.Name 
            };
        }

        private WarehouseItemDTO ItemToItemDTO(WarehouseItem item)
        {
            return new WarehouseItemDTO()
            {
                Id = item.Id,
                Name = item.Name,
                Quantity = item.Quantity,
                Category = item.Category,
                Unit = item.Unit,
                Code = item.Code,
                Description = item.Description,
                Price = item.Price
            };
        }
        
        public void Dispose()
        {
            Database.Dispose();
        }
            
        public void SaveItemsFromDB(List<WarehouseItemDTO> items)
        {

            foreach (WarehouseItemDTO item in items)
            {
                this.Database.WarehouseItems.Create(new WarehouseItem
                {
                    Name = item.Name,
                    Category = item.Category,
                    Unit = item.Unit,
                    Code = item.Code,
                    Description = item.Description,
                    Price = item.Price,
                    Quantity = item.Quantity
                });
                this.Database.Save();
            }
        }
    
        public List<WarehouseItemDTO> GetItemsByNameOrCategory(string name)
        {
            List<WarehouseItemDTO> items = new List<WarehouseItemDTO>();
            foreach (WarehouseItem item in Database.WarehouseItems.GetAll())
            {
                if (item.Name == name || item.Category == name)
                {
                    items.Add(this.ItemToItemDTO(item));
                }
            }
            return items;
        }

        public List<WarehouseItemDTO> GetItemsByCategory(string name)
        {
            List<WarehouseItemDTO> items = new List<WarehouseItemDTO>();
            foreach (WarehouseItem item in Database.WarehouseItems.GetAll())
            {
                if (item.Category == name)
                {
                    items.Add(this.ItemToItemDTO(item));
                }
            }
            return items;
        }

        public List<string> GetItemsNames()
        {
            List<string> items = new List<string>();
            foreach (WarehouseItem item in Database.WarehouseItems.GetAll())
            {
                items.Add(item.Name);
            }
            return items;
        }

        public List<string> GetItemsCategoryes()
        {
            List<string> items = new List<string>();
            foreach (WarehouseItem item in Database.WarehouseItems.GetAll())
            {
                items.Add(item.Category);
            }
            return items;
        }
    }
}
