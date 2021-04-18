using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PosCustomerBO
{
    //Customer Class
    public class CustomerBO
    {
        public static int customerCounter = GetCounter();

        //Setting up Counter Value
        //Counts no of lines and then assigns id accordingly
        public static int GetCounter()
        {
            string filepath = Path.Combine(Environment.CurrentDirectory, "CustomerDataBase.txt");
            StreamReader sr = new StreamReader(filepath);
            string line = String.Empty;
            int rc = 1;

            while ((line = sr.ReadLine()) != null)
            {
                rc++;
            }
            sr.Close();
            return rc;
        }
        
        public int CustomerID;
        public CustomerBO()
        {
            CustomerID = customerCounter;
            AmountPayable = 0;
            customerCounter++;
        }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal AmountPayable { get; set; }
        public decimal SalesLimit { get; set; }


    }
}
