using POS_BLL;
using System;

namespace POS_VIEW
{
    public class PosVIEW
    {
        public void Start()
        {
            PosBLL bll = new PosBLL(); 
            int choice=0;
            do
            {
                Console.WriteLine("\n-----------Welcome to POS-------------");
                Console.WriteLine();
                Console.WriteLine("1- Manage Items");
                Console.WriteLine("2- Manage Customers");
                Console.WriteLine("3- Make New Sale");
                Console.WriteLine("4- Make Payments");
                Console.WriteLine("5- Print Reports");
                Console.WriteLine("6- Exit");

                Console.WriteLine();

                Console.WriteLine("Select an Option:");
                try 
                { 
                    choice = int.Parse(Console.ReadLine()); 
                }
                catch
                {
                    Console.WriteLine("Enter Valid Input i.e number");
                }
                if (choice == 1)
                {
                    //calling function
                    ManageItems();
                }
                else if(choice==2)
                {
                    //calling function
                    ManageCustomers();
                }
                else if(choice==3)
                {
                    //calling function
                    bll.MakeNewSale();
                }
                else if(choice==4)
                {
                    //calling function

                    bll.MakePayments();
                }
                else if(choice==5)
                {
                    //calling function

                    ViewReports();
                }

            } while (choice != 6);

            Console.WriteLine("-------Exiting POS Terminal------");
            Console.WriteLine("-----------Good Bye--------------");

        }



        /// <summary>
        /// ////////////////////////////////////////////////////////////////Items////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        private void ManageItems()
        {
            int itemMenuChoice = 0;

            //Making new PosBll object to access its functions
            PosBLL bll = new PosBLL();

            do
            {
                Console.WriteLine("\n\n1- Add New Item");
                Console.WriteLine("2- Update Item Details");
                Console.WriteLine("3- Find Items");
                Console.WriteLine("4- Remove Existing Item");
                Console.WriteLine("5- Back to Main Menu");

                Console.WriteLine("\nSelect an Option:");
                try
                {
                    itemMenuChoice = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Enter Valid Choice");
                }
                if (itemMenuChoice == 1)
                {
                    //Calling Additem Function
                    bll.AddItem();
                }
                if (itemMenuChoice == 2)
                {
                    //calling function

                    bll.UpdateItem();
                }
                if (itemMenuChoice == 3)
                {
                    //calling function

                    bll.FindItem();

                }
                if (itemMenuChoice == 4)
                {
                    //calling function

                    bll.RemoveItem();

                }
            }
            while (itemMenuChoice != 5);
        }




        /// <summary>
        /// /////////////////////////////////////////Customer////////////////////////////////////////////////////////
        /// </summary>
        /// 


        private void ManageCustomers()
        {
            //Making new PosBll object to access its functions

            PosBLL bll = new PosBLL();
            int customerMenuChoice = 0;
            do
            {
                Console.WriteLine("\n\n1- Add New Customer");
                Console.WriteLine("2- Update Customer Details");
                Console.WriteLine("3- Find Customer");
                Console.WriteLine("4- Remove Existing Customer");
                Console.WriteLine("5- Back to Main Menu");

                Console.WriteLine("\nSelect an Option:");
                try
                {
                    customerMenuChoice = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Enter Valid choice i.e number");
                }
                if (customerMenuChoice == 1)
                {
                    bll.AddCustomer();
                }
                if (customerMenuChoice == 2)
                {
                    bll.UpdateCustomer();
                }
                if (customerMenuChoice == 3)
                {
                    bll.FindCustomer();
                }
                if (customerMenuChoice == 4)
                {
                    bll.RemoveCustomer();
                }
            }
            while (customerMenuChoice != 5);
        }





        private void ViewReports()
        {
            //Making new PosBll object to access its functions

            PosBLL bll = new PosBLL();
            Console.WriteLine("\nViewReports");
            int viewReportChoice = 0;
            Console.WriteLine("6- Stock in Hand");
            Console.WriteLine("7- Customer Balance");
            Console.WriteLine("8- Sales Report (by Date)");
            Console.WriteLine("9- Outstanding Sales (by Date)");

            Console.WriteLine();

            Console.WriteLine("Select an Option:");
            try
            {
                viewReportChoice = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Enter Valid Input i.e number");
            }

            if(viewReportChoice==6)
            {
                bll.StockInHand();
            }
            if(viewReportChoice==7)
            {
                bll.CustomerBalance();
            }
            if(viewReportChoice==8)
            {
                bll.SalesReport();
            }
            if(viewReportChoice==9)
            {
                bll.OutStandingReport();
            }
        }
    }
}
