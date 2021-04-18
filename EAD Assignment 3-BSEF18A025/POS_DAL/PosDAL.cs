using PosCustomerBO;
using PosItemBO;
using PosReceiptBO;
using PosSaleBO;
using PosSaleLineItemBO;
using System;
using System.Collections.Generic;


namespace POS_DAL
{
    public class PosDAL : BaseDAL
    {
        //Functions to Manipulate Data in files                   (Chainging Objects to semicolon seperated strings and vice versa )
        //These functions includes actions like:-
        //1-Reading Form files
        //2-Writing to files
        //3-Overwriting on files



        public void AddItem(ItemBO newitem)
        {
            string text = $"{newitem.ItemID};{newitem.Description};{newitem.Price};{newitem.Quantity};{newitem.CreationDate}";
            Save(text, "ItemDataBase.txt");
        }


        public void AddCustomer(CustomerBO newCustomer)
        {
            string text = $"{newCustomer.CustomerID};{newCustomer.Name};{newCustomer.Address};{newCustomer.Phone};{newCustomer.Email};{newCustomer.AmountPayable};{newCustomer.SalesLimit}";
            Save(text, "CustomerDataBase.txt");
        }


        public List<ItemBO> ReadItem()
        {
            List<string> stringList = Read("ItemDataBase.txt");

            List<ItemBO> itemList = new List<ItemBO>();

            foreach (string s in stringList)
            {
                string[] data = s.Split(";");
                ItemBO e = new ItemBO();
                e.ItemID = System.Convert.ToInt32(data[0]);
                e.Description =data[1];
                e.Price = System.Convert.ToDecimal(data[2]);
                e.Quantity = System.Convert.ToInt32(data[3]);
                e.CreationDate = data[4];
                itemList.Add(e);
            }


            return itemList;

        }

        

        public List<ItemBO> updateDescriptionItem(string updateDescription, int itemID)
        {
            List<ItemBO> list = ReadItem();
            foreach(ItemBO s in list)
            {
                
                if(s.ItemID==itemID)
                {
                    s.Description =updateDescription;
                }
            }

            return list;
        }

        public List<CustomerBO> ReadCustomer()
        {
            List<string> stringList = Read("CustomerDataBase.txt");

            List<CustomerBO> customerList = new List<CustomerBO>();

            foreach (string s in stringList)
            {
                string[] data = s.Split(";");
                CustomerBO e = new CustomerBO();
                e.CustomerID = System.Convert.ToInt32(data[0]);
                e.Name = data[1];
                e.Address = data[2];
                e.Phone = data[3];
                e.Email = data[4];
                e.AmountPayable = System.Convert.ToDecimal(data[5]);
                e.SalesLimit = System.Convert.ToDecimal(data[6]);
                customerList.Add(e);
            }


            return customerList;
        }

        public List<SaleBO> ReadSales()
        {
            List<string> stringList = Read("SaleDataBase.txt");

            List<SaleBO> saleList = new List<SaleBO>();

            foreach (string s in stringList)
            {
                string[] data = s.Split(";");
                SaleBO e = new SaleBO();
                e.SaleID = System.Convert.ToInt32(data[0]);
                e.CustomerID = System.Convert.ToInt32(data[1]);
                e.SaleDate = System.Convert.ToString(data[2]);
                e.Status = System.Convert.ToBoolean(data[3]);
                saleList.Add(e);
            }
            return saleList;
        }

        public List<CustomerBO> updateCustomerPhone(string updatedCustomerPhone, int customerID)
        {
            List<CustomerBO> list = ReadCustomer();
            foreach (CustomerBO s in list)
            {

                if (s.CustomerID == customerID)
                {
                    s.Phone = updatedCustomerPhone;
                }
            }
            return list;
        }

        public List<CustomerBO> updateCustomerSalesLimit(string updatedCustomerSalesLimit, int customerID)
        {
            List<CustomerBO> list = ReadCustomer();
            foreach (CustomerBO s in list)
            {

                if (s.CustomerID == customerID)
                {
                    s.SalesLimit = System.Convert.ToDecimal(updatedCustomerSalesLimit);
                }
            }
            return list;
        }
        

        public List<ReceiptBO> ReadReceipt()
        {
            List<string> stringList = Read("ReceiptDataBase.txt");

            List<ReceiptBO> receiptList = new List<ReceiptBO>();

            foreach (string s in stringList)
            {
                string[] data = s.Split(";");
                ReceiptBO e = new ReceiptBO();
                e.ReceiptNo = System.Convert.ToInt32(data[0]);
                e.ReceiptDate = data[1];
                e.SaleID = System.Convert.ToInt32(data[2]);
                e.Amount = System.Convert.ToDecimal(data[3]);



                receiptList.Add(e);
            }


            return receiptList;
        }

        public List<CustomerBO> RemoveCustomer(string removeCustomerID)
        {
            List<CustomerBO> list = ReadCustomer();
            List<CustomerBO> newlist = new List<CustomerBO>();
            foreach (CustomerBO s in list)
            {
                if (s.CustomerID != System.Convert.ToInt32(removeCustomerID))
                {
                    newlist.Add(s);
                }
            }
            return newlist;
        }

        public void AddReceipt(ReceiptBO receipt)
        {
            string text = $"{receipt.ReceiptNo};{receipt.ReceiptDate};{receipt.SaleID};{receipt.Amount}";
            Save(text, "ReceiptDataBase.txt");
        }

        public List<SaleLineItemBO> ReadSaleLineItem()
        {
            List<string> stringList = Read("SaleLineItemDataBase.txt");

            List<SaleLineItemBO> salelineItemList = new List<SaleLineItemBO>();

            foreach (string s in stringList)
            {
                string[] data = s.Split(";");
                SaleLineItemBO e = new SaleLineItemBO();
                e.LineNo = System.Convert.ToInt32(data[0]);
                e.SaleID = System.Convert.ToInt32(data[1]);
                e.ItemID = System.Convert.ToInt32(data[2]);
                e.Quantity = System.Convert.ToInt32(data[3]);
                e.Amount = System.Convert.ToDecimal(data[4]);
                salelineItemList.Add(e);
            }
            return salelineItemList;
        }

        public List<CustomerBO> updateCustomerAmountPayable(decimal bill, int customerID)
        {
            List<CustomerBO> list = ReadCustomer();
            foreach (CustomerBO s in list)
            {

                if (s.CustomerID == customerID)
                {
                    s.AmountPayable = System.Convert.ToDecimal(bill);
                }
            }
            return list;
        }

        public void AddSaleLineItem(SaleLineItemBO newSaleLineItem)
        {
            string text = $"{newSaleLineItem.LineNo};{newSaleLineItem.SaleID};{newSaleLineItem.ItemID};{newSaleLineItem.Quantity};{newSaleLineItem.Amount}";
            Save(text, "SaleLineItemDataBase.txt");
        }

        public void AddSale(SaleBO newSale)
        {
            string text = $"{newSale.SaleID};{newSale.CustomerID};{newSale.SaleDate};{newSale.Status}";
            Save(text, "SaleDataBase.txt");
        }

        public List<CustomerBO> updateCustomerEmail(string updatedCustomerEmail, int customerID)
        {
            List<CustomerBO> list = ReadCustomer();
            foreach (CustomerBO s in list)
            {
                if (s.CustomerID == customerID)
                {
                    s.Email = updatedCustomerEmail;
                }
            }
            return list;
        }

        public List<ItemBO> updateQuantityItem(string updateQuantity, int itemID)
        {
            List<ItemBO> list = ReadItem();
            foreach (ItemBO s in list)
            {
                if (s.ItemID == itemID)
                {
                    s.Quantity =System.Convert.ToInt32(updateQuantity);
                }
            }

            return list;
        }

        public List<ItemBO> updatePriceItem(string updatePrice, int itemID)
        {
            List<ItemBO> list = ReadItem();
            foreach (ItemBO s in list)
            {
                
                if(s.ItemID==itemID)
                {
                    s.Price =System.Convert.ToDecimal(updatePrice);
                }
            }
            return list;
        }

        public void Overwrite(List<ItemBO> newitem)
        {
            string text;
            int i = 0;
            
            
            if(newitem.Count==0)
            {
                Empty("ItemDataBase.txt");
            }

            foreach (ItemBO s in newitem)
            {
                if(i==0)
                {
                    text = $"{s.ItemID};{s.Description};{s.Price};{s.Quantity};{s.CreationDate}";
                    overwrite(text, "ItemDataBase.txt");
                    i=1;
                }
                else 
                {
                    text = $"{s.ItemID};{s.Description};{s.Price};{s.Quantity};{s.CreationDate}";
                    Save(text, "ItemDataBase.txt");
                }
            }
        }
        public List<ItemBO> RemoveItem(string removeItemID)
        {
            List<ItemBO> list = ReadItem();
            List<ItemBO> newlist= new List<ItemBO>();
            foreach (ItemBO s in list)
            {
                if (s.ItemID != System.Convert.ToInt32(removeItemID))
                {
                    newlist.Add(s);
                }
            }
            return newlist;
        }

        public List<CustomerBO> updateCustomerName(string updatedCustomerName, int customerID)
        {
            List<CustomerBO> list = ReadCustomer();
            foreach (CustomerBO s in list)
            {

                if (s.CustomerID == customerID)
                {
                    s.Name = updatedCustomerName;
                }
            }

            return list;
        }

        public List<CustomerBO> updateCustomerAddress(string updatedCustomerAddress, int customerID)
        {
            List<CustomerBO> list = ReadCustomer();
            foreach (CustomerBO s in list)
            {

                if (s.CustomerID == customerID)
                {
                    s.Address = updatedCustomerAddress;
                }
            }
            return list;
        }
        public void OverwriteCustomer(List<CustomerBO> newCustomer)
        {
            string text;
            int i = 0;


            if (newCustomer.Count == 0)
            {
                Empty("CustomerDataBase.txt");
            }

            foreach (CustomerBO s in newCustomer)
            {
                if (i == 0)
                {
                    text = $"{s.CustomerID};{s.Name};{s.Address};{s.Phone};{s.Email};{s.AmountPayable};{s.SalesLimit}";
                    overwrite(text, "CustomerDataBase.txt");
                    i = 1;
                }
                else
                {
                    text = $"{s.CustomerID};{s.Name};{s.Address};{s.Phone}; {s.Email};{s.AmountPayable};{s.SalesLimit}";
                    Save(text, "CustomerDataBase.txt");
                }
            }
        }
    }
}
