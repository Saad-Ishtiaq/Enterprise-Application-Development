using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PosReceiptBO
{
    //Receipt Class
    public class ReceiptBO
    {
        public static int receiptCounter = GetCounter()+1;

        public int ReceiptNo;
        public int SaleID;
        public string ReceiptDate { get; set; }
        public decimal Amount { get; set; }

        //Setting up Counter Value
        //Counts no of lines and then assigns id accordingly
        public static int GetCounter()
        {
            string filepath = Path.Combine(Environment.CurrentDirectory, "ReceiptDataBase.txt");
            StreamReader sr = new StreamReader(filepath);
            string line = String.Empty;
            int rc = 0;

            while ((line = sr.ReadLine()) != null)
            {
                rc++;
            }
            sr.Close();
            return rc;
        }
        

        public ReceiptBO()
        {
            ReceiptNo = receiptCounter;
            receiptCounter++;
        }





    }
}
