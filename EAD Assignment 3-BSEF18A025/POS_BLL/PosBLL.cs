using System;
using PosItemBO;
using System.Collections.Generic;
using POS_DAL;
using PosCustomerBO;
using PosSaleBO;
using PosSaleLineItemBO;
using PosReceiptBO;

namespace POS_BLL
{
    public class PosBLL
    {

        
        //Functions Related to ManageItems
        public void AddItem()
        {
            Console.WriteLine("\n\n\nAdd New Item");
            ItemBO newItem = new ItemBO();
            Console.WriteLine($"ItemID:{newItem.ItemID}");

            //Setting Creation Date
            DateTime dt = DateTime.Now;

            Console.WriteLine($"\nDescription:");
            string itemDescription = Console.ReadLine();

            Console.WriteLine($"\nPrice:");
            decimal itemPrice = 0M;
            try
            {
                itemPrice = decimal.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Not Valid Price");
            }

            Console.WriteLine("\nQuantity:");
            int itemQuantity = 0;
            try
            {
                itemQuantity = System.Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Not Valid Quantity");
            }


            newItem.Description = itemDescription;
            newItem.Price = itemPrice;
            newItem.Quantity = itemQuantity;
            newItem.CreationDate = dt.ToShortDateString();

            Console.WriteLine($"\n\nItemId:{newItem.ItemID}" +
                              $"\nCreationDate:{newItem.CreationDate}" +
                              $"\n\nDescription:{newItem.Description}" +
                              $"\nPrice:{newItem.Price}" +
                              $"\nQuantity:{newItem.Quantity}");

            string confirm;
            Console.WriteLine("\nConfirm?:(y/n)");
            confirm = Console.ReadLine();
            if (confirm == "y")
            {
                PosBLL itemBLL = new PosBLL();
                itemBLL.addItemLogic(newItem);
            }
            if (confirm == "n")
            {
                ItemBO.itemCounter--;
            }
        }


        public void UpdateItem()
        {
            Console.WriteLine("\n\nEnter ItemID:");
            int updateItemID = 0;
            try
            {
                updateItemID = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Not Valid ID");
            }


            UpdateWithID(System.Convert.ToString(updateItemID));
        }

        public void UpdateWithID(string updateItemID)
        {
            PosBLL bll = new PosBLL();
            List<ItemBO> itemList = bll.AllItems();
            int k = 0;
            foreach (ItemBO s in itemList)
            {

                if (s.ItemID == System.Convert.ToInt32(updateItemID))
                {
                    k = 1;

                    Console.WriteLine("----------------------------------------------------------------------------------------");
                    Console.WriteLine("ItemID           Description        Price            Quantity      CreationDate ");
                    Console.WriteLine("----------------------------------------------------------------------------------------");

                    Console.WriteLine($"{s.ItemID,-10} " +
                                      $"{s.Description,18}" +
                                      $"{s.Price,15:C}" +
                                      $"{s.Quantity,15}" +
                                      $"{s.CreationDate,15}");
                    Console.WriteLine("----------------------------------------------------------------------------------------");


                    string updateDescription = null;
                    Console.WriteLine("\nUpdated Description:");
                    updateDescription = Console.ReadLine();

                    string updatePrice = null;
                    Console.WriteLine("\nUpdated Price:");
                    updatePrice = Console.ReadLine();

                    string updateQuantity = null;
                    Console.WriteLine("\nUpdated Quantity:");
                    updateQuantity = Console.ReadLine();


                    Console.WriteLine("---------------------------------------------Updated Description-------------------------------------------");

                    Console.WriteLine($"ItemID:  {s.ItemID,-10} ");

                    if (updateDescription != null && updateDescription.Length != 0)
                    {
                        Console.WriteLine($"Updated Description: {updateDescription,-18}");
                    }
                    else
                    {
                        Console.WriteLine($"Description: {s.Description,-18}");
                    }
                    if (updatePrice != null && updatePrice.Length != 0)
                    {
                        Console.WriteLine($"Updated Price: {updatePrice,-15:C}");
                    }
                    else
                    {
                        Console.WriteLine($"Price: {s.Price,15:C}");

                    }
                    if (updateQuantity != null && updateQuantity.Length != 0)
                    {
                        Console.WriteLine($"Updated Quantiity: {updateQuantity,-15}");
                    }
                    else
                    {
                        Console.WriteLine($"Quantity: {s.Quantity,-15}");

                    }


                    string confirm;
                    Console.WriteLine("\nConfirm?:(y/n)");
                    confirm = Console.ReadLine();
                    if (confirm == "y")
                    {
                        if (updateDescription != null && updateDescription.Length != 0)
                        {
                            PosBLL updateItem = new PosBLL();
                            updateItem.DescriptionUpdate(updateDescription, s.ItemID);
                        }

                        if (updatePrice != null && updatePrice.Length != 0)
                        {
                            PosBLL updateItem = new PosBLL();
                            updateItem.PriceUpdate(updatePrice, s.ItemID);
                        }

                        if (updateQuantity != null && updateQuantity.Length != 0)
                        {
                            PosBLL updateItem = new PosBLL();
                            updateItem.QuantityPrice(updateQuantity, s.ItemID);
                        }
                    }

                }
            }
            if (k == 0)
            {
                Console.WriteLine($"Oops!!!  Item With ItemID:{updateItemID} not Found.");
            }

        }





        public void FindItem()
        {
            Console.WriteLine("\n\nEnter ItemID:");
            int fID = 0;
            try
            {
                fID = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Not Valid ID");
            }
            string findItemID = System.Convert.ToString(fID);

            Console.WriteLine("\n\nEnter Item Description:");
            string findItemDescription = Console.ReadLine();



            Console.WriteLine("\n\nEnter Item Price:");
            decimal p = 0M;
            try
            {
                p = decimal.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Not Valid Price");
            }
            string findItemPrice = p.ToString();





            Console.WriteLine("\n\nEnter Item Quantity:");
            int fQuantity = 0;
            try
            {
                fQuantity = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Not Valid Quantity");
            }
            string findItemQuantity = fQuantity.ToString();

            Console.WriteLine("\n\nEnter Item CreationDate:");
            string findItemCreationDate = Console.ReadLine();



            if (findItemID != null && findItemID.Length != 0)
            {
                findItemWithID(findItemID);
            }

            if (findItemDescription != null && findItemDescription.Length != 0)
            {
                findItemWithDescription(findItemDescription);
            }

            if (findItemPrice != null && findItemPrice.Length != 0)
            {
                findItemWithPrice(findItemPrice);
            }

            if (findItemQuantity != null && findItemQuantity.Length != 0)
            {
                findItemWithQuantity(findItemQuantity);
            }

            if (findItemCreationDate != null && findItemCreationDate.Length != 0)
            {
                findItemWithCreationDate(findItemCreationDate);
            }
        }

        public void findItemWithCreationDate(string findItemCreationDate)
        {
            PosBLL bll = new PosBLL();
            List<ItemBO> itemList = bll.AllItems();
            int k = 0;
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("ItemID           Description        Price            Quantity      CreationDate ");
            Console.WriteLine("----------------------------------------------------------------------------------------");

            foreach (ItemBO s in itemList)
            {

                if (s.CreationDate.Contains(findItemCreationDate))
                {
                    k = 1;

                    Console.WriteLine($"{s.ItemID,-10} " +
                                      $"{s.Description,18}" +
                                      $"{s.Price,15:C}" +
                                      $"{s.Quantity,15}" +
                                      $"{s.CreationDate,15}");

                }
            }
            if (k == 0)
            {
                Console.WriteLine($"Oops!!!  Item With CreationDate:{findItemCreationDate} not Found.");
            }
            Console.WriteLine("----------------------------------------------------------------------------------------");
        }

        public void findItemWithQuantity(string findItemQuantity)
        {
            PosBLL bll = new PosBLL();
            List<ItemBO> itemList = bll.AllItems();
            int k = 0;
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("ItemID           Description        Price            Quantity      CreationDate ");
            Console.WriteLine("----------------------------------------------------------------------------------------");

            foreach (ItemBO s in itemList)
            {

                if (s.Quantity == System.Convert.ToInt32(findItemQuantity))
                {
                    k = 1;

                    Console.WriteLine($"{s.ItemID,-10} " +
                                      $"{s.Description,18}" +
                                      $"{s.Price,15:C}" +
                                      $"{s.Quantity,15}" +
                                      $"{s.CreationDate,15}");

                }
            }
            if (k == 0)
            {
                Console.WriteLine($"Oops!!!  Item With Quantity:{findItemQuantity} not Found.");
            }
            Console.WriteLine("----------------------------------------------------------------------------------------");
        }

        public void findItemWithPrice(string findItemPrice)
        {
            PosBLL bll = new PosBLL();
            List<ItemBO> itemList = bll.AllItems();
            int k = 0;
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("ItemID           Description        Price            Quantity      CreationDate ");
            Console.WriteLine("----------------------------------------------------------------------------------------");
            foreach (ItemBO s in itemList)
            {

                if (s.Price == System.Convert.ToDecimal(findItemPrice))
                {
                    k = 1;
                    Console.WriteLine($"{s.ItemID,-10} " +
                                      $"{s.Description,18}" +
                                      $"{s.Price,15:C}" +
                                      $"{s.Quantity,15}" +
                                      $"{s.CreationDate,15}");
                }
            }
            if (k == 0)
            {
                Console.WriteLine($"Oops!!!  Item With Price :{findItemPrice} not Found.");
            }
            Console.WriteLine("----------------------------------------------------------------------------------------");

        }

        public void findItemWithDescription(string findItemDescription)
        {
            PosBLL bll = new PosBLL();
            List<ItemBO> itemList = bll.AllItems();
            int k = 0;

            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("ItemID           Description        Price            Quantity      CreationDate ");
            Console.WriteLine("----------------------------------------------------------------------------------------");

            foreach (ItemBO s in itemList)
            {
                if (s.Description.EndsWith(findItemDescription))
                {
                    k = 1;
                    Console.WriteLine($"{s.ItemID,-10} " +
                                      $"{s.Description,18}" +
                                      $"{s.Price,15:C}" +
                                      $"{s.Quantity,15}" +
                                      $"{s.CreationDate,15}");

                }
            }
            if (k == 0)
            {
                Console.WriteLine($"Oops!!!  Item With Description: {findItemDescription} not Found.");
            }
            Console.WriteLine("----------------------------------------------------------------------------------------");
        }

        public void findItemWithID(string findItemID)
        {
            PosBLL bll = new PosBLL();
            List<ItemBO> itemList = bll.AllItems();
            int k = 0;
            foreach (ItemBO s in itemList)
            {

                if (s.ItemID == System.Convert.ToInt32(findItemID))
                {
                    k = 1;

                    Console.WriteLine("----------------------------------------------------------------------------------------");
                    Console.WriteLine("ItemID           Description        Price            Quantity      CreationDate ");
                    Console.WriteLine("----------------------------------------------------------------------------------------");

                    Console.WriteLine($"{s.ItemID,-10} " +
                                      $"{s.Description,18}" +
                                      $"{s.Price,15:C}" +
                                      $"{s.Quantity,15}" +
                                      $"{s.CreationDate,15}");
                    Console.WriteLine("----------------------------------------------------------------------------------------");

                }
            }
            if (k == 0)
            {
                Console.WriteLine($"Oops!!!  Item With ItemID:{findItemID} not Found.");
            }
        }



        public void RemoveItem()
        {
            Console.WriteLine("\n\nEnter ItemID:");
            string removeItemID = Console.ReadLine();

            if (removeItemID != null && removeItemID.Length != 0)
            {
                removeItemWithID(removeItemID);
            }

        }
        public void removeItemWithID(string removeItemID)
        {
            PosBLL bll = new PosBLL();
            List<ItemBO> itemList = bll.AllItems();


            int k = 0;
            foreach (ItemBO s in itemList)
            {

                if (s.ItemID == System.Convert.ToInt32(removeItemID))
                {
                    k = 1;

                    Console.WriteLine("---------------------------Remove Description-------------------------------------------");
                    Console.WriteLine("----------------------------------------------------------------------------------------");
                    Console.WriteLine("ItemID           Description        Price            Quantity      CreationDate ");
                    Console.WriteLine("----------------------------------------------------------------------------------------");

                    Console.WriteLine($"{s.ItemID,-10} " +
                                      $"{s.Description,18}" +
                                      $"{s.Price,15:C}" +
                                      $"{s.Quantity,15}" +
                                      $"{s.CreationDate,15}");
                    Console.WriteLine("----------------------------------------------------------------------------------------");


                    string confirm;
                    Console.WriteLine("\nConfirm?:(y/n)");
                    confirm = Console.ReadLine();
                    if (confirm == "y")
                    {
                        PosBLL removeItem = new PosBLL();
                        removeItem.RemoveWithID(removeItemID);


                    }

                }
            }
            if (k == 0)
            {
                Console.WriteLine($"Oops!!!  Item With ItemID:{removeItemID} not Found.");
            }

        }









        //Functions Related to ManageCustomer


        public void AddCustomer()
        {
            Console.WriteLine("\n\n\nAdd New Customer");
            CustomerBO newCustomer = new CustomerBO();
            Console.WriteLine($"CustomerID:{newCustomer.CustomerID}");

            //Setting Creation Date
            DateTime dt = DateTime.Now;

            Console.WriteLine($"\nName:");
            string customerName = Console.ReadLine();

            Console.WriteLine($"\nAddress:");
            string customerAddress = Console.ReadLine();

            Console.WriteLine($"\nPhone:");
            string customerPhone = Console.ReadLine();

            Console.WriteLine($"\nEmail:");
            string customerEmail = Console.ReadLine();

            Console.WriteLine("\nSalesLimit:");
            decimal customerSaleLimit = 0M;
            try
            {
                customerSaleLimit = decimal.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Note Valid SalesLimit");
            }

            newCustomer.Name = customerName;
            newCustomer.Address = customerAddress;
            newCustomer.Phone = customerPhone;
            newCustomer.Email = customerEmail;
            newCustomer.SalesLimit = customerSaleLimit;

            Console.WriteLine($"\n\nCustomerId:{newCustomer.CustomerID}" +
                              $"\n\nName:{newCustomer.Name}" +
                              $"\nAddress:{newCustomer.Address}" +
                              $"\nPhone:{newCustomer.Phone}" +
                              $"\nEmail:{newCustomer.Email}" +
                              $"\nSalesLimit:{newCustomer.SalesLimit:C}" +
                              $"\nAmmountPayable:{newCustomer.AmountPayable:C}");

            string confirm;
            Console.WriteLine("\nConfirm?:(y/n)");
            confirm = Console.ReadLine();
            if (confirm == "y")
            {
                PosBLL customerBLL = new PosBLL();
                customerBLL.addcustomerLogic(newCustomer);
            }
            if (confirm == "n")
            {
                CustomerBO.customerCounter--;
            }
        }




        public void UpdateCustomer()
        {
            Console.WriteLine("\n\nEnter CustomerID:");
            int uID = 0;
            try
            {
                uID = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Not Valid ID");
            }

            string updateCustomerID = uID.ToString();

            UpdateWithCustomerID(updateCustomerID);
        }



        public void UpdateWithCustomerID(string updateCustomerID)
        {
            PosBLL bll = new PosBLL();
            List<CustomerBO> customerList = bll.AllCustomer();
            int k = 0;
            foreach (CustomerBO s in customerList)
            {

                if (s.CustomerID == System.Convert.ToInt32(updateCustomerID))
                {
                    k = 1;

                    Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("CustomerID           Name           Address            Phone          Email          AmountPayable        SalesLimit");
                    Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");

                    Console.WriteLine($"{s.CustomerID,-10} " +
                                      $"{s.Name,18}" +
                                      $"{s.Address,15}" +
                                      $"{s.Phone,20}" +
                                      $"{s.Email,15}" +
                                      $"{s.AmountPayable,15:C}" +
                                      $"{s.SalesLimit,15:C}");

                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");


                    Console.WriteLine("\n\nUpdated Name:");
                    string updatedCustomerName = Console.ReadLine();
                    Console.WriteLine("\n\nUpdated Address:");
                    string updatedCustomerAddress = Console.ReadLine();
                    Console.WriteLine("\n\nUpdated Phone:");
                    string updatedCustomerPhone = Console.ReadLine();
                    Console.WriteLine("\n\nUpdated Email:");
                    string updatedCustomerEmail = Console.ReadLine();
                    Console.WriteLine("\n\nUpdated SalesLimit:");
                    string updatedCustomerSalesLimit = Console.ReadLine();



                    Console.WriteLine("---------------------------------------------Updated Description-------------------------------------------");

                    Console.WriteLine($"CustomerID:  {s.CustomerID,-10} ");

                    if (updatedCustomerName != null && updatedCustomerName.Length != 0)
                    {
                        Console.WriteLine($"Updated Name: {updatedCustomerName,-18}");
                    }
                    else
                    {
                        Console.WriteLine($"Name: {s.Name,-18}");
                    }
                    if (updatedCustomerAddress != null && updatedCustomerAddress.Length != 0)
                    {
                        Console.WriteLine($"Updated Address: {updatedCustomerAddress,-18}");
                    }
                    else
                    {
                        Console.WriteLine($"Address: {s.Address,-18}");
                    }
                    if (updatedCustomerPhone != null && updatedCustomerPhone.Length != 0)
                    {
                        Console.WriteLine($"Updated Phone: {updatedCustomerPhone,-18}");
                    }
                    else
                    {
                        Console.WriteLine($"Phone: {s.Phone,-18}");
                    }
                    if (updatedCustomerEmail != null && updatedCustomerEmail.Length != 0)
                    {
                        Console.WriteLine($"Updated Email: {updatedCustomerEmail,-18}");
                    }
                    else
                    {
                        Console.WriteLine($"Email: {s.Email,-18}");
                    }
                    if (updatedCustomerSalesLimit != null && updatedCustomerSalesLimit.Length != 0)
                    {
                        Console.WriteLine($"Updated SalesLimit: {updatedCustomerSalesLimit,-18}");
                    }
                    else
                    {
                        Console.WriteLine($"SalesLimit: {s.SalesLimit,-18}");
                    }

                    string confirm;
                    Console.WriteLine("\nConfirm?:(y/n)");
                    confirm = Console.ReadLine();
                    if (confirm == "y")
                    {
                        if (updatedCustomerName != null && updatedCustomerName.Length != 0)
                        {
                            PosBLL updateCustomer = new PosBLL();
                            updateCustomer.NameUpdate(updatedCustomerName, s.CustomerID);
                        }

                        if (updatedCustomerAddress != null && updatedCustomerAddress.Length != 0)
                        {
                            PosBLL updateCustomer = new PosBLL();
                            updateCustomer.AddressUpdate(updatedCustomerAddress, s.CustomerID);
                        }

                        if (updatedCustomerPhone != null && updatedCustomerPhone.Length != 0)
                        {
                            PosBLL updateCustomer = new PosBLL();
                            updateCustomer.PhoneUpdate(updatedCustomerPhone, s.CustomerID);
                        }

                        if (updatedCustomerEmail != null && updatedCustomerEmail.Length != 0)
                        {
                            PosBLL updateCustomer = new PosBLL();
                            updateCustomer.EmailUpdate(updatedCustomerEmail, s.CustomerID);
                        }

                        if (updatedCustomerSalesLimit != null && updatedCustomerSalesLimit.Length != 0)
                        {
                            PosBLL updateItem = new PosBLL();
                            updateItem.SalesLimitUpdate(updatedCustomerSalesLimit, s.CustomerID);
                        }

                    }

                }
            }
            if (k == 0)
            {
                Console.WriteLine($"Oops!!!  Item With ItemID:{updateCustomerID} not Found.");
            }

        }



        public void FindCustomer()
        {
            Console.WriteLine("\n\nEnter CustomerID:");
            string findCustomerID = Console.ReadLine();
            Console.WriteLine("\n\nEnter Name:");
            string findCustomerName = Console.ReadLine();
            Console.WriteLine("\n\nEnter Phone:");
            string findCustomerPhone = Console.ReadLine();
            Console.WriteLine("\n\nEnter Email:");
            string findCustomerEmail = Console.ReadLine();
            Console.WriteLine("\n\nEnter SalesLimit:");
            string findCustomerSalesLimit = Console.ReadLine();




            if (findCustomerID != null && findCustomerID.Length != 0)
            {
                findCustomerWithID(findCustomerID);
            }

            if (findCustomerName != null && findCustomerName.Length != 0)
            {
                findCustomerWithName(findCustomerName);
            }

            if (findCustomerPhone != null && findCustomerPhone.Length != 0)
            {
                findCustomerWithPhone(findCustomerPhone);
            }
            if (findCustomerEmail != null && findCustomerEmail.Length != 0)
            {
                findCustomerWithEmail(findCustomerEmail);
            }


            if (findCustomerSalesLimit != null && findCustomerSalesLimit.Length != 0)
            {
                findCustomerWithSalesLimit(findCustomerSalesLimit);
            }
        }



        public void findCustomerWithSalesLimit(string findCustomerSalesLimit)
        {
            PosBLL bll = new PosBLL();
            List<CustomerBO> customerList = bll.AllCustomer();
            int k = 0;
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("CustomerID           Name           Address            Phone          Email          AmountPayable        SalesLimit");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            foreach (CustomerBO s in customerList)
            {

                if (s.SalesLimit == System.Convert.ToDecimal(findCustomerSalesLimit))
                {
                    k = 1;
                    Console.WriteLine($"{s.CustomerID,-10} " +
                                      $"{s.Name,18}" +
                                      $"{s.Address,15}" +
                                      $"{s.Phone,20}" +
                                      $"{s.Email,15}" +
                                      $"{s.AmountPayable,15:C}" +
                                      $"{s.SalesLimit,15:C}");
                }
            }
            if (k == 0)
            {
                Console.WriteLine($"Oops!!!  Item With Price :{findCustomerSalesLimit} not Found.");
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");



        }

        public void findCustomerWithPhone(string findCustomerPhone)
        {
            PosBLL bll = new PosBLL();
            List<CustomerBO> customerList = bll.AllCustomer();
            int k = 0;

            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("CustomerID           Name           Address            Phone          Email          AmountPayable        SalesLimit");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");

            foreach (CustomerBO s in customerList)
            {
                if (s.Phone.EndsWith(findCustomerPhone))
                {
                    k = 1;
                    Console.WriteLine($"{s.CustomerID,-10} " +
                                      $"{s.Name,18}" +
                                      $"{s.Address,15}" +
                                      $"{s.Phone,20}" +
                                      $"{s.Email,15}" +
                                      $"{s.AmountPayable,15:C}" +
                                      $"{s.SalesLimit,15:C}");
                }
            }
            if (k == 0)
            {
                Console.WriteLine($"Oops!!!  Item With Description: {findCustomerPhone} not Found.");
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");

        }

        public void findCustomerWithEmail(string findCustomerEmail)
        {
            PosBLL bll = new PosBLL();
            List<CustomerBO> customerList = bll.AllCustomer();
            int k = 0;

            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("CustomerID           Name           Address            Phone          Email          AmountPayable        SalesLimit");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");

            foreach (CustomerBO s in customerList)
            {
                if (s.Email.EndsWith(findCustomerEmail))
                {
                    k = 1;
                    Console.WriteLine($"{s.CustomerID,-10} " +
                                      $"{s.Name,18}" +
                                      $"{s.Address,15}" +
                                      $"{s.Phone,20}" +
                                      $"{s.Email,15}" +
                                      $"{s.AmountPayable,15:C}" +
                                      $"{s.SalesLimit,15:C}");
                }
            }
            if (k == 0)
            {
                Console.WriteLine($"Oops!!!  Item With Description: {findCustomerEmail} not Found.");
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");

        }

        public void findCustomerWithName(string findCustomerName)
        {

            PosBLL bll = new PosBLL();
            List<CustomerBO> customerList = bll.AllCustomer();
            int k = 0;

            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("CustomerID           Name           Address            Phone          Email          AmountPayable        SalesLimit");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");

            foreach (CustomerBO s in customerList)
            {
                if (s.Name.EndsWith(findCustomerName))
                {
                    k = 1;
                    Console.WriteLine($"{s.CustomerID,-10} " +
                                      $"{s.Name,18}" +
                                      $"{s.Address,15}" +
                                      $"{s.Phone,20}" +
                                      $"{s.Email,15}" +
                                      $"{s.AmountPayable,15:C}" +
                                      $"{s.SalesLimit,15:C}");
                }
            }
            if (k == 0)
            {
                Console.WriteLine($"Oops!!!  Item With Description: {findCustomerName} not Found.");
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");

        }

        public void findCustomerWithID(string findCustomerID)
        {
            PosBLL bll = new PosBLL();
            List<CustomerBO> customerList = bll.AllCustomer();
            int k = 0;
            foreach (CustomerBO s in customerList)
            {

                if (s.CustomerID == System.Convert.ToInt32(findCustomerID))
                {
                    k = 1;

                    Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("CustomerID           Name           Address            Phone          Email          AmountPayable        SalesLimit");
                    Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");

                    Console.WriteLine($"{s.CustomerID,-10} " +
                                      $"{s.Name,18}" +
                                      $"{s.Address,15}" +
                                      $"{s.Phone,20}" +
                                      $"{s.Email,15}" +
                                      $"{s.AmountPayable,15:C}" +
                                      $"{s.SalesLimit,15:C}");
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");

                }
            }
            if (k == 0)
            {
                Console.WriteLine($"Oops!!!  Item With CustomerID:{findCustomerID} not Found.");
            }
        }

        public void RemoveCustomer()
        {

            Console.WriteLine("\n\nEnter ItemID:");
            string removeCustomerID = Console.ReadLine();

            if (removeCustomerID != null && removeCustomerID.Length != 0)
            {
                removeCustomerWithID(removeCustomerID);
            }
        }

        public void removeCustomerWithID(string removeCustomerID)
        {
            PosBLL bll = new PosBLL();
            List<CustomerBO> customerList = bll.AllCustomer();
            int k = 0;
            foreach (CustomerBO s in customerList)
            {

                if (s.CustomerID == System.Convert.ToInt32(removeCustomerID))
                {
                    if (s.AmountPayable == 0)
                    {

                        k = 1;


                        Console.WriteLine("---------------------------------------------Removal Description-------------------------------------------");

                        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine("CustomerID           Name           Address            Phone          Email          AmountPayable        SalesLimit");
                        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");

                        Console.WriteLine($"{s.CustomerID,-10} " +
                                          $"{s.Name,18}" +
                                          $"{s.Address,15}" +
                                          $"{s.Phone,20}" +
                                          $"{s.Email,15}" +
                                          $"{s.AmountPayable,15:C}" +
                                          $"{s.SalesLimit,15:C}");

                        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");



                        string confirm;
                        Console.WriteLine("\nConfirm?:(y/n)");
                        confirm = Console.ReadLine();
                        if (confirm == "y")
                        {
                            PosBLL removeCustomer = new PosBLL();
                            removeCustomer.RemoveCustomerWithID(removeCustomerID);
                        }
                    }
                    else
                    {
                        k = 1;
                        Console.WriteLine($"Customer {s.Name} cannot be removed because of debt : {s.AmountPayable}");
                    }

                }
            }
            if (k == 0)
            {
                Console.WriteLine($"Oops!!!  Item With ItemID:{removeCustomerID} not Found.");
            }
        }










        //Function to Make New Sale


        public void MakeNewSale()
        {
            Console.WriteLine("\n\n\nMake New Sale");
            SaleBO newSale = new SaleBO();
            Console.WriteLine($"Sale ID:{newSale.SaleID}");

            //Setting Creation Date
            DateTime dt = DateTime.Now;
            newSale.SaleDate = dt.ToShortDateString();
            Console.WriteLine($"Sale Date:{newSale.SaleDate}");

            int? newSaleCustomerID = null;
            Console.WriteLine($"\nEnter Customer ID:");
            try
            {
                newSaleCustomerID = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Enter Valid ID i.e number");
            }

            SaleLineItemBO newSaleLineItem = new SaleLineItemBO();
            newSaleLineItem.SaleID = newSale.SaleID;


            PosBLL bll = new PosBLL();
            List<CustomerBO> customerList = bll.AllCustomer();
            int k = 0;
            foreach (CustomerBO s in customerList)
            {
                if (s.CustomerID == (newSaleCustomerID))
                {
                    k = 1;

                    newSale.CustomerID = s.CustomerID;

                    List<SaleLineItemBO> itemlist = new List<SaleLineItemBO>() { newSaleLineItem };

                    AddItemToSale(newSaleLineItem);

                    decimal bill = 0;
                    foreach (SaleLineItemBO sli in itemlist)
                    {
                        bill = bill + sli.Amount;
                    }

                    if (s.SalesLimit >= s.AmountPayable)
                    {
                        if (s.SalesLimit < bill + s.AmountPayable)
                        {
                            Console.WriteLine("Amount Payable exceeds Sales Limit");
                            itemlist.RemoveAt(itemlist.Count - 1);
                        }
                        else
                        {
                            s.AmountPayable += bill;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nAmount Payable exceeds Sales Limit");
                        itemlist.RemoveAt(itemlist.Count - 1);
                    }

                    Console.WriteLine("\n\nPress 1 to Enter New Item");
                    Console.WriteLine("Press 2 to End Sale");
                    Console.WriteLine("Press 3 to Remove an existing Item from the current sale");
                    Console.WriteLine("Press 4 to Cancel Sale");

                    int saleChoice = 0;
                    try
                    {
                        saleChoice = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Enter Valid Value i.e number");
                    }
                    {
                        do
                        {
                            if (saleChoice == 1)
                            {
                                int addItemChoice = 1;
                                do
                                {
                                    Console.Write("\nNew Item");
                                    SaleLineItemBO newSaleLineItem2 = new SaleLineItemBO();
                                    newSaleLineItem2.SaleID = newSale.SaleID;
                                    SaleLineItemBO obj2 = AddItemToSale(newSaleLineItem2);

                                    s.AmountPayable -= bill;
                                    bill = 0;

                                    if (obj2 != null)
                                    {
                                        itemlist.Add(obj2);
                                        foreach (SaleLineItemBO sli in itemlist)
                                        {
                                            bill = bill + sli.Amount;
                                        }
                                        Console.WriteLine($"\nTotal Amount Payable {bill:c}");
                                        if (s.SalesLimit >= s.AmountPayable)
                                        {
                                            if (s.SalesLimit < bill)
                                            {

                                                Console.WriteLine("\nAmount Payable exceeds Sales Limit ");
                                                itemlist.RemoveAt(itemlist.Count - 1);
                                            }
                                            else
                                            {
                                                s.AmountPayable += bill;
                                            }
                                        }
                                        else
                                        {

                                            Console.WriteLine("\nAmount Payable exceeds Sales Limit");
                                            itemlist.RemoveAt(itemlist.Count - 1);
                                        }

                                        Console.WriteLine("\n\n\nPress 1 to Enter New Item");
                                        Console.WriteLine("Press 2 to End Sale");
                                        Console.WriteLine("Press 3 to Remove an existing Item from the current sale");
                                        Console.WriteLine("Press 4 to Cancel Sale");

                                        addItemChoice = System.Convert.ToInt32(Console.ReadLine());

                                        if (addItemChoice == 2)
                                        {
                                            saleChoice = 0;
                                        }
                                        else
                                        {
                                            saleChoice = addItemChoice;
                                        }
                                    }
                                    else
                                    {
                                        addItemChoice = 0;
                                    }


                                }
                                while (addItemChoice == 1);

                                if (addItemChoice == 2)
                                {
                                    Console.Write("\nEnd Sale");

                                    DisplayEndReceipt(newSale, itemlist, s);


                                    foreach (SaleLineItemBO item in itemlist)
                                    {
                                        SaveSaleLineItem(item);
                                    }
                                    PosBLL updateCustomer = new PosBLL();
                                    updateCustomer.AmountPayableUpdate(s.AmountPayable, s.CustomerID);
                                    SaveSale(newSale);

                                    saleChoice = 0;


                                }
                                if (addItemChoice == 3)
                                {
                                    Console.Write("\nRemove");

                                    DisplayEndReceipt(newSale, itemlist, s);


                                    Console.WriteLine("Remove Line No:");
                                    int remove = System.Convert.ToInt32(Console.ReadLine());


                                    itemlist.RemoveAt(remove - 1);
                                    PosBLL updateCustomer = new PosBLL();
                                    updateCustomer.AmountPayableUpdate(s.AmountPayable - bill, s.CustomerID);
                                    DisplayEndReceipt(newSale, itemlist, s);


                                    Console.WriteLine("Press 1 to Enter New Item");
                                    Console.WriteLine("Press 2 to End Sale");
                                    Console.WriteLine("Press 3 to Remove an existing Item from the current sale");
                                    Console.WriteLine("Press 4 to Cancel Sale");

                                    addItemChoice = System.Convert.ToInt32(Console.ReadLine());
                                    if (addItemChoice == 2)
                                    {
                                        saleChoice = 2;
                                    }
                                    else
                                    {
                                        saleChoice = addItemChoice;
                                    }
                                }
                                if (addItemChoice == 4)
                                {
                                    Console.Write("\n\nSale Cancelled");
                                    saleChoice = addItemChoice;
                                }

                            }


                            if (saleChoice == 2)
                            {
                                Console.Write("\nEnd Sale");

                                DisplayEndReceipt(newSale, itemlist, s);

                                if (itemlist != null)
                                {
                                    foreach (SaleLineItemBO item in itemlist)
                                    {
                                        SaveSaleLineItem(item);
                                    }
                                    PosBLL updateCustomer = new PosBLL();
                                    updateCustomer.AmountPayableUpdate(s.AmountPayable, s.CustomerID);
                                    SaveSale(newSale);
                                }

                                saleChoice = 0;

                            }
                            if (saleChoice == 3)
                            {
                                Console.Write("\nRemove");

                                DisplayEndReceipt(newSale, itemlist, s);


                                Console.WriteLine("Remove Line No:");
                                int remove = System.Convert.ToInt32(Console.ReadLine());


                                itemlist.RemoveAt(remove - 1);
                                PosBLL updateCustomer = new PosBLL();
                                updateCustomer.AmountPayableUpdate(s.AmountPayable - bill, s.CustomerID);
                                DisplayEndReceipt(newSale, itemlist, s);


                                Console.WriteLine("Press 1 to Enter New Item");
                                Console.WriteLine("Press 2 to End Sale");
                                Console.WriteLine("Press 3 to Remove an existing Item from the current sale");
                                Console.WriteLine("Press 4 to Cancel Sale");

                                saleChoice = System.Convert.ToInt32(Console.ReadLine());
                            }
                            if (saleChoice == 4)
                            {
                                Console.Write("\n\nSale Cancelled");
                                saleChoice = 0;
                            }
                            else if (saleChoice != 0)
                            {
                                Console.WriteLine("Press 1 to Enter New Item");
                                Console.WriteLine("Press 2 to End Sale");
                                Console.WriteLine("Press 3 to Remove an existing Item from the current sale");
                                Console.WriteLine("Press 4 to Cancel Sale");

                                saleChoice = System.Convert.ToInt32(Console.ReadLine());
                            }
                        }
                        while (saleChoice != 0);

                    }
                }
            }
            if (k == 0)
            {
                Console.WriteLine($"Oops!!!  Item With CustomerID:{newSaleCustomerID} not Found.");
            }

        }

        public void DisplayEndReceipt(SaleBO newSale, List<SaleLineItemBO> itemlist, CustomerBO customer)
        {
            PosBLL bll = new PosBLL();

            decimal bill = 0M;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"SalesId:{newSale.SaleID}                                CustomerID:{customer.CustomerID}");
            Console.WriteLine($"SalesDate:{newSale.SaleDate}                            Name:{customer.Name}");


            List<ItemBO> itemList = bll.AllItems();
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("ItemID           Description                  Quantity                        Amount    ");
            Console.WriteLine("----------------------------------------------------------------------------------------");

            foreach (SaleLineItemBO s in itemlist)
            {
                foreach (ItemBO i in itemList)
                {

                    if (s.ItemID == i.ItemID)
                    {

                        Console.WriteLine($"{s.ItemID,-7} " +
                                          $"{i.Description,22}" +
                                          $"{s.Quantity,20}" +
                                          $"{s.Amount,33}");
                        bill = bill + s.Amount;
                    }
                }
            }

            Console.WriteLine("----------------------------------------------------------------------------------------");

            Console.WriteLine($"                                                                    Total Sales:{bill} ");

            Console.WriteLine("----------------------------------------------------------------------------------------");


        }


        public SaleLineItemBO AddItemToSale(SaleLineItemBO newSaleLineItem)
        {
            PosBLL bll = new PosBLL();
            Console.WriteLine("\nItem ID: ");
            try
            {
                newSaleLineItem.ItemID = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Enter Valid ID i.e number");
            }

            List<ItemBO> itemList = bll.AllItems();
            int l = 0;
            foreach (ItemBO e in itemList)
            {

                if (e.ItemID == (newSaleLineItem.ItemID))
                {
                    l = 1;

                    Console.WriteLine($"\nDescription:{e.Description}" +
                                      $"\nPrice:{e.Price,13:C}");
                    Console.WriteLine("\nQuantity:");
                    try
                    {
                        newSaleLineItem.Quantity = int.Parse(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Enter Valid Quantity i.e number");
                    }

                    newSaleLineItem.Amount = newSaleLineItem.Quantity * e.Price;
                    Console.WriteLine($"\nSub Total:{newSaleLineItem.Amount,9:C}");

                    if (e.Quantity >= newSaleLineItem.Quantity)
                    {

                        //Updating Item Quantity 
                        PosBLL updateItem = new PosBLL();
                        updateItem.QuantityPrice((System.Convert.ToString(e.Quantity - newSaleLineItem.Quantity)), e.ItemID);
                        return (newSaleLineItem);

                    }
                    else
                    {
                        newSaleLineItem.Amount = 0;
                        Console.WriteLine("Required Quantity of Item is Greater Than Stock");
                        return null;
                    }

                }
            }
            if (l == 0)
            {
                Console.WriteLine($"Oops!!!  Item With ItemID:{newSaleLineItem.ItemID} not Found.");
            }
            return null;

        }













        //Function to Make Payments

        public void MakePayments()
        {
            Console.WriteLine("\nMake Payment");
            int checkSaleID = 0;
            Console.WriteLine("\nSaleID:");
            try
            {
                checkSaleID = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Not Valid ID");
            }
            PosBLL bll = new PosBLL();


            ReceiptBO receipt = new ReceiptBO();

            DateTime dt = DateTime.Now;
            receipt.ReceiptDate = dt.ToShortDateString();

            List<SaleBO> saleBOs = bll.AllSales();
            string cusname = null;

            decimal totalSalesAmount = 0M;
            foreach (SaleBO s in saleBOs)
            {
                if (s.SaleID == checkSaleID)
                {
                    receipt.SaleID = s.SaleID;
                    List<CustomerBO> cus = bll.AllCustomer();
                    foreach (CustomerBO c in cus)
                    {
                        if (s.CustomerID == c.CustomerID)
                        {

                            Console.WriteLine($"\nCustomer Name: {c.Name}");
                            cusname = c.Name;
                        }
                        List<SaleLineItemBO> sli = bll.AllSaleLineItem();
                        foreach (SaleLineItemBO si in sli)
                        {
                            if (s.SaleID == si.SaleID)
                            {
                                totalSalesAmount += si.Amount;
                            }
                        }

                    }

                }
            }

            List<ReceiptBO> receiptList = bll.AllReceipts();
            decimal amountPaid = 0M;
            foreach (ReceiptBO r in receiptList)
            {
                if (receipt.SaleID == checkSaleID)
                {
                    amountPaid += r.Amount;
                }
            }


            Console.WriteLine($"\nSaleID: {receipt.SaleID}");
            Console.WriteLine($"Total Sales Amount: {totalSalesAmount:C}");
            Console.WriteLine($"Amount Paid:{amountPaid:C}");
            Console.WriteLine($"Remaining Amount: {totalSalesAmount - amountPaid:C}");
            Console.WriteLine($"Amount To Be Paid: ");
            receipt.Amount = System.Convert.ToDecimal(Console.ReadLine());


            foreach (SaleBO s in saleBOs)
            {
                if (s.SaleID == checkSaleID)
                {
                    receipt.SaleID = s.SaleID;
                    List<CustomerBO> cus = bll.AllCustomer();
                    foreach (CustomerBO c in cus)
                    {
                        if (s.CustomerID == c.CustomerID)
                        {
                            c.AmountPayable -= receipt.Amount;
                            PosBLL updateCustomer = new PosBLL();
                            updateCustomer.AmountPayableUpdate(c.AmountPayable, s.CustomerID);
                        }
                    }

                }
            }


            string confirm;
            Console.WriteLine("\nConfirm?:(y/n)");
            confirm = Console.ReadLine();
            if (confirm == "y")
            {
                PosBLL receiptBLL = new PosBLL();
                receiptBLL.addReceiptLogic(receipt);
                foreach (SaleBO s in saleBOs)
                {
                    if (s.SaleID == checkSaleID)
                    {
                        receipt.SaleID = s.SaleID;
                        List<CustomerBO> cus = bll.AllCustomer();
                        foreach (CustomerBO c in cus)
                        {
                            if (s.CustomerID == c.CustomerID)
                            {
                                c.AmountPayable -= receipt.Amount;

                            }
                        }

                    }
                }

            }
            if (confirm == "n")
            {
                ReceiptBO.receiptCounter--;
            }
        }



        //Functions related to Reports      

        public void StockInHand()
        {
            int itemID = 0;
            Console.WriteLine();

            Console.WriteLine("ItemID:");
            try
            {
                itemID = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Enter Valid Input i.e number");
            }

            int itemID2 = 0;
            Console.WriteLine();

            Console.WriteLine("To ItemID:");
            try
            {
                itemID2 = int.Parse(Console.ReadLine()); 
            }
            catch
            {
                Console.WriteLine("Enter Valid Input i.e number");
            }



            DateTime dt = DateTime.Now;

            Console.WriteLine($"Date: {dt}");

            if (itemID != 0)
            {
                int i = itemID;
                Console.WriteLine("----------------------------------------------------------------------------------------");
                Console.WriteLine("ItemID           Description        Price            Quantity In Hand                   ");
                Console.WriteLine("----------------------------------------------------------------------------------------");
                while (i <= itemID2)
                {
                    PosBLL bll = new PosBLL();
                    List<ItemBO> itemList = bll.AllItems();
                    int k = 0;

                    foreach (ItemBO s in itemList)
                    {

                        if (s.ItemID == i)
                        {
                            k = 1;

                            Console.WriteLine($"{s.ItemID,-10} " +
                                              $"{s.Description,18}" +
                                              $"{s.Price,15:C}" +
                                              $"{s.Quantity,15}");

                        }
                    }
                    if (k == 0)
                    {
                        Console.WriteLine($"Oops!!!  Item With ItemID:{itemID} not Found.");
                    }
                    i++;
                }
                Console.WriteLine("----------------------------------------------------------------------------------------");
            }
        }

        public void CustomerBalance()
        {
            Console.WriteLine("\nCustomerBalance");

            int customerID = 0;
            Console.WriteLine();

            Console.WriteLine("Please Enter Customer ID:");
            try
            {
                customerID = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Enter Valid Input i.e number");
            }

            PosBLL bll = new PosBLL();
            List<CustomerBO> customerList = bll.AllCustomer();
            int k = 0;
            foreach (CustomerBO s in customerList)
            {

                if (s.CustomerID == customerID)
                {
                    k = 1;
                    Console.WriteLine($"Customer Name:{s.Name}");
                    Console.WriteLine($"Address: {s.Address}");
                    Console.WriteLine($"Phone:{s.Phone}");
                    Console.WriteLine($"Email:{s.Email}");
                    Console.WriteLine($"Balance:{s.AmountPayable:C}");
                }
            }
            if (k == 0)
            {
                Console.WriteLine($"Oops!!!  Item With CustomerID:{customerID} not Found.");
            }
        }





        public void SalesReport()
        {
            Console.WriteLine("\nSalesReports");

            Console.WriteLine();

            Console.WriteLine("Sales Report From:");
            DateTime dt1 = DateTime.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("To:");
            DateTime? dt2;
            try
            {
                dt2 = DateTime.Parse(Console.ReadLine());
            }
            catch
            {
                dt2 = null;
            }

            decimal totalSale = 0M;
            if (dt1 != null)
            {
                Console.WriteLine("----------------------------------------------------------------------------------------");
                Console.WriteLine("ItemID           Description         Quantity Sold           Amount                     ");
                Console.WriteLine("----------------------------------------------------------------------------------------");

                if (dt2 != null)
                {
                    while (dt1 <= dt2)
                    {
                        PosBLL bll = new PosBLL();
                        List<SaleBO> saleList = bll.AllSales();

                        foreach (SaleBO s in saleList)
                        {

                            if (System.Convert.ToDateTime(s.SaleDate) == dt1)
                            {
                                List<SaleLineItemBO> saleItemList = bll.AllSaleLineItem();
                                foreach (SaleLineItemBO sli in saleItemList)
                                {
                                    if (s.SaleID == sli.SaleID)
                                    {

                                        List<ItemBO> itemList = bll.AllItems();
                                        foreach (ItemBO ii in itemList)
                                        {
                                            if (ii.ItemID == sli.ItemID)
                                            {
                                                Console.WriteLine($"{sli.ItemID,-10}" +
                                                                  $"{ii.Description,18}" +
                                                                  $"{sli.Quantity,18}" +
                                                                  $"{sli.Amount,22:C}");
                                                totalSale += sli.Amount;

                                            }
                                        }

                                    }

                                }

                            }
                        }
                        dt1 = dt1.AddDays(1);
                    }
                    Console.WriteLine();
                    Console.WriteLine($"                                                  Total Sale:{totalSale:C}   ");
                }
                else
                {
                    PosBLL bll = new PosBLL();
                    List<SaleBO> saleList = bll.AllSales();
                    foreach (SaleBO s in saleList)
                    {

                        if (System.Convert.ToDateTime(s.SaleDate) == dt1)
                        {
                            List<SaleLineItemBO> saleItemList = bll.AllSaleLineItem();
                            foreach (SaleLineItemBO sli in saleItemList)
                            {
                                if (s.SaleID == sli.SaleID)
                                {

                                    List<ItemBO> itemList = bll.AllItems();
                                    foreach (ItemBO ii in itemList)
                                    {
                                        if (ii.ItemID == sli.ItemID)
                                        {
                                            Console.WriteLine($"{sli.ItemID,-10}" +
                                                              $"{ii.Description,18}" +
                                                              $"{sli.Quantity,18}" +
                                                              $"{sli.Amount,22:C}");
                                            totalSale += sli.Amount;

                                        }
                                    }

                                }

                            }

                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine($"                                                  Total Sale:{totalSale:C}   ");
                }
                Console.WriteLine("----------------------------------------------------------------------------------------");
            }
        }




        public void OutStandingReport()
        {
            Console.WriteLine("\nOutstanding Reports");

            Console.WriteLine();

            Console.WriteLine("From:");
            DateTime dt1 = DateTime.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("To:");
            DateTime? dt2;
            try
            {
                dt2 = DateTime.Parse(Console.ReadLine());
            }
            catch
            {
                dt2 = null;
            }
            decimal totalSalesAmount = 0M;
            decimal rAm = 0M;

            if (dt1 != null)
            {
                Console.WriteLine("----------------------------------------------------------------------------------------");
                Console.WriteLine("SaleID           Customer Name         Total Amount           Remaining Amount          ");
                Console.WriteLine("----------------------------------------------------------------------------------------");

                if (dt2 != null)
                {
                    while (dt1 <= dt2)
                    {
                        PosBLL bll = new PosBLL();
                        List<SaleBO> saleList = bll.AllSales();

                        foreach (SaleBO s in saleList)
                        {

                            if (System.Convert.ToDateTime(s.SaleDate) == dt1)
                            {
                                List<SaleLineItemBO> saleItemList = bll.AllSaleLineItem();
                                foreach (SaleLineItemBO sli in saleItemList)
                                {
                                    if (s.SaleID == sli.SaleID)
                                    {

                                        totalSalesAmount += sli.Amount;

                                        List<ReceiptBO> receiptList = bll.AllReceipts();
                                        decimal amountPaid = 0M;
                                        foreach (ReceiptBO r in receiptList)
                                        {
                                            if (s.SaleID == r.SaleID)
                                            {
                                                amountPaid += r.Amount;
                                            }
                                        }

                                        Console.WriteLine($"{sli.SaleID,-10}" +
                                                           $"{s.CustomerID,18}" +
                                                           $"{totalSalesAmount,22:C}" +
                                                           $"{totalSalesAmount - amountPaid,18}");
                                        rAm += (totalSalesAmount - amountPaid);
                                    }

                                }

                            }
                        }
                        dt1 = dt1.AddDays(1);
                    }
                    Console.WriteLine();
                    Console.WriteLine($"                                                  Total Sale:{rAm:C}   ");
                }
                else
                {
                    PosBLL bll = new PosBLL();
                    List<SaleBO> saleList = bll.AllSales();

                    foreach (SaleBO s in saleList)
                    {

                        if (System.Convert.ToDateTime(s.SaleDate) == dt1)
                        {
                            List<SaleLineItemBO> saleItemList = bll.AllSaleLineItem();
                            foreach (SaleLineItemBO sli in saleItemList)
                            {
                                if (s.SaleID == sli.SaleID)
                                {

                                    totalSalesAmount += sli.Amount;

                                    List<ReceiptBO> receiptList = bll.AllReceipts();
                                    decimal amountPaid = 0M;
                                    foreach (ReceiptBO r in receiptList)
                                    {
                                        if (s.SaleID == r.SaleID)
                                        {
                                            amountPaid += r.Amount;
                                        }
                                    }

                                    Console.WriteLine($"{sli.SaleID,-10}" +
                                                       $"{s.CustomerID,18}" +
                                                       $"{totalSalesAmount,22:C}" +
                                                       $"{totalSalesAmount - amountPaid,18}");
                                    rAm += (totalSalesAmount - amountPaid);

                                }

                            }

                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine($"                                                  Total Sale:{rAm:C}   ");
                }
                Console.WriteLine("----------------------------------------------------------------------------------------");
            }

        }

        //Helping Function Thses send and receive data from files i.e To access Data Access layer


        public void addItemLogic(ItemBO newitem)
        {
            PosDAL dal = new PosDAL();
            dal.AddItem(newitem);


        }
        public void addcustomerLogic(CustomerBO newCustomer)
        {
            PosDAL dal = new PosDAL();
            dal.AddCustomer(newCustomer);
        }

        public List<ItemBO> AllItems()
        {
            PosDAL dal = new PosDAL();
            return dal.ReadItem();
        }



        public void DescriptionUpdate(string updateDescription, int itemID)
        {
            PosDAL dal = new PosDAL();
            List <ItemBO>list= (dal.updateDescriptionItem(updateDescription, itemID));
            dal.Overwrite(list);

        }

        public void PriceUpdate(string updatePrice, int itemID)
        {
            PosDAL dal = new PosDAL();
            List<ItemBO> list = (dal.updatePriceItem(updatePrice, itemID));
            dal.Overwrite(list);
        }

        public void QuantityPrice(string updateQuantity, int itemID)
        {
            PosDAL dal = new PosDAL();
            List<ItemBO> list = (dal.updateQuantityItem(updateQuantity, itemID));
            dal.Overwrite(list);
        }

        public void RemoveWithID(string removeItemID)
        {
            PosDAL dal = new PosDAL();
            List<ItemBO> list = (dal.RemoveItem(removeItemID));
            dal.Overwrite(list);
        }

        public List<CustomerBO> AllCustomer()
        {
            PosDAL dal = new PosDAL();
            return dal.ReadCustomer();
        }

        public void NameUpdate(string updatedCustomerName, int customerID)
        {
            PosDAL dal = new PosDAL();
            List<CustomerBO> list = (dal.updateCustomerName(updatedCustomerName, customerID));
            dal.OverwriteCustomer(list);
        }

        public void AddressUpdate(string updatedCustomerAddress, int customerID)
        {
            PosDAL dal = new PosDAL();
            List<CustomerBO> list = (dal.updateCustomerAddress(updatedCustomerAddress, customerID));
            dal.OverwriteCustomer(list);
        }

        public List<SaleBO> AllSales()
        {
            PosDAL dal = new PosDAL();
            return dal.ReadSales();
        }
       
       

        public void PhoneUpdate(string updatedCustomerPhone, int customerID)
        {
            PosDAL dal = new PosDAL();
            List<CustomerBO> list = (dal.updateCustomerPhone(updatedCustomerPhone, customerID));
            dal.OverwriteCustomer(list);
        }

        public void EmailUpdate(string updatedCustomerEmail, int customerID)
        {
            PosDAL dal = new PosDAL();
            List<CustomerBO> list = (dal.updateCustomerEmail(updatedCustomerEmail, customerID));
            dal.OverwriteCustomer(list);
        }

        public void SalesLimitUpdate(string updatedCustomerSalesLimit, int customerID)
        {
            PosDAL dal = new PosDAL();
            List<CustomerBO> list = (dal.updateCustomerSalesLimit(updatedCustomerSalesLimit, customerID));
            dal.OverwriteCustomer(list);
        }

        public void RemoveCustomerWithID(string removeCustomerID)
        {
            PosDAL dal = new PosDAL();
            List<CustomerBO> list = (dal.RemoveCustomer(removeCustomerID));
            dal.OverwriteCustomer(list);
        }

        public List<ReceiptBO> AllReceipts()
        {
            PosDAL dal = new PosDAL();
            return dal.ReadReceipt();
        }

        public void addSaleLogic(SaleBO newSale)
        {
            PosDAL dal = new PosDAL();
            dal.AddSale(newSale);
        }

        public void addSaleLineItemLogic(SaleLineItemBO newSaleLineItem)
        {
            PosDAL dal = new PosDAL();
            dal.AddSaleLineItem(newSaleLineItem);
        }

        public List<SaleLineItemBO> AllSaleLineItem()
        {
            PosDAL dal = new PosDAL();
            return dal.ReadSaleLineItem();
        }

        public void addReceiptLogic(ReceiptBO receipt)
        {
            PosDAL dal = new PosDAL();
            dal.AddReceipt(receipt);
        }

        public void AmountPayableUpdate(decimal bill, int customerID)
        {
            PosDAL dal = new PosDAL();
            List<CustomerBO> list = (dal.updateCustomerAmountPayable(bill, customerID));
            dal.OverwriteCustomer(list);
        }


        public void SaveSaleLineItem(SaleLineItemBO newSaleLineItem)
        {
            PosBLL saleBLL = new PosBLL();
            saleBLL.addSaleLineItemLogic(newSaleLineItem);
        }

        public void SaveSale(SaleBO newSale)
        {
            PosBLL saleBLL = new PosBLL();
            saleBLL.addSaleLogic(newSale);

        }

    }
}


























